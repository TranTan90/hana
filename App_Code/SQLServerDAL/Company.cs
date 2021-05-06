using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data;
using HanaMicron.COMS.DBUtility;
using HanaMicron.COMS.Model;
using HanaMicron.COMS.IDAL;
using System.Globalization;
using log4net;

namespace HanaMicron.COMS.SQLServerDAL
{
	/// <summary>
	/// 거래처 DAL
	/// </summary>
    public class Company : ICompany
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Company));

        public Company()
		{
			log4net.Config.DOMConfigurator.Configure();
		}
        



        // 김민우: 오토 메일 발송
        public void CreateHtml(CompanyInfo company)
        {
            StringBuilder sql = new StringBuilder();
            String a = "\"";
            StringBuilder html = new StringBuilder();

            
            // HTML 작성
            html.Append(@"
                <HTML>
                 <HEAD>
                  <TITLE>Xác nhận đăng ký công ty (업체 등록 확인) </TITLE>
                 </HEAD>
                 <BODY>
                 <table>
                    <tr>
		                <td>
				           Công ty mới đã được đăng ký. Hãy kiểm tra. (새로운 업체가 등록 신청 되었습니다. 확인 바랍니다).
                       </td> 
                    </tr>
                    <br>
                    <tr><td> Thông tin công ty (업체 정보)
                    </td></tr>            

                    <tr><td> Tên công ty (회사명): " + company.CompanyName + @"
                    </td></tr>            

                    <tr><td>Mã đăng ký kinh doanh (사업자 등록 번호): " + company.RegNumber1 + @" - " + company.RegNumber2 + @" - " + company.RegNumber3 + @" 
                    </td></tr>            

                    <tr><td> Số điện thoại (전화 번호): " + company.Phone1 + @" - " + company.Phone2 + @" - " + company.Phone3 + @" 
                    </td></tr>            

                    <tr><td>Tên người đại diện (대표자명): " + company.MasterName + @"
                    </td></tr>   
                    <tr><td> Địa chỉ (주소): " + company.Address + @"
                    </td></tr>          


                    <tr><td> Người đăng ký (등록자): " + company.EmployeeName + @" - "+ company.EmployeeDept + @"
                    </td></tr>           

                </table>
                </BODY>
                </HTML>
            
            ");
            OracleParameter param = new OracleParameter(":CONTENTS", OracleType.Clob);
            param.Value = Convert.ToString(html);

            sql.Append(@"
                INSERT INTO AM_MAIL_MESSAGE
                (AID, CONFIG_ID, SUBJECT, FROM_NAME, TO_LIST, CC_LIST, MAIL_PRIORITY, MAIL_ATTACH, CONTENTS, FLG_HTML, FLG_SEND, SCHEDULE_DATE)
                VALUES
                (SEQ_ALERT_MESSAGE.NEXTVAL, 9999, '[Visit System]A new company has been registered.', 'HmVinaMailMaster:hmvinamailmaster@hanamicronvina.com', 'softsong@hanamicron.co.kr,PartGA@hanamicronvina.com,ljw0304@hanamicron.co.kr,partit@hanamicronvina.com', ''
                 , 'N', '', :CONTENTS,'Y','N', SYSDATE)
                ");
            // 2021-03-24 Nguyen Van An: Database에 베트남어와 한국어가 깨져서 영어로 바꿈. (DB không đọc được tiếng việt và tiếng hàn nên thay đề mục hiển thị tiếng anh)
            //[Khách thăm ra/vào]Công ty mới đã được đăng ký ([내방반출입] 새로운 업체가 등록 신청 되었습니다.)
            OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionStringLocalTransactionAM, CommandType.Text, sql.ToString(), param);

        }


        #region 회사 관리
        /// <summary>
        /// 회사 정보 가져오기
        /// </summary>
        /// <param name="carCategoryID"></param>
        /// <returns></returns>
        public CompanyInfo getCompany(String companyCode)
        {
            log.Debug(@"=================START getCompany=================");
            log.Debug(@"companyCode = " + companyCode);

			CompanyInfo obj = new CompanyInfo() ;

            StringBuilder sql_select_company = new StringBuilder();
			sql_select_company.Append("SELECT a.companyCode,a.companyName,a.regNumber1,a.regNumber2,a.regNumber3");
			sql_select_company.Append("     , ISNULL(a.phone1,'') as phone1,ISNULL(a.phone2,' ') as phone2,ISNULL(a.phone3,' ') as phone3");
			sql_select_company.Append("     , ISNULL(a.masterName,' ') as masterName,ISNULL(a.address,' ') as address,a.regDate,a.approve,a.employeeCode,b.displayName as employeeName ");
            sql_select_company.Append("     , ISNULL(a.companyManagementNo,' ') as companyManagementNo,ISNULL(a.companyStartNo,' ') as companyStartNo");
            sql_select_company.Append(" FROM Company a,GCM.dbo.UserInfo_MTB b WHERE a.employeeCode=b.upnid AND a.companyCode="+companyCode);

            //Execute the query	
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_company.ToString(), null))
            {
				if (rdr.Read())
				{
					obj = bindCompany(rdr, obj);

				}
            }

            log.Debug(@"=================END getCompany=================");

            return obj;

        }

        /// <summary>
        /// 회사 목록
        /// </summary>
        /// <param name="txtKey"></param>
        /// <returns></returns>
		public List<CompanyInfo> getCompanyList(String keyWord, String key,int approve,String employeeCode)
		{
			log.Debug("=================START getCompanyList=================");
			log.Debug("keyWord = " + keyWord);
			log.Debug("key = " + key);

			List<CompanyInfo> list = new List<CompanyInfo>();

			StringBuilder sql_select_company_list = new StringBuilder();
			sql_select_company_list.Append("SELECT a.companyCode,companyName,a.regNumber1,a.regNumber2,a.regNumber3" + "\n");
            sql_select_company_list.Append("     , ISNULL(a.phone1,'') as phone1,ISNULL(a.phone2,' ') as phone2,ISNULL(a.phone3,' ') as phone3" + "\n");
            sql_select_company_list.Append("     , ISNULL(a.masterName,' ') as masterName,ISNULL(a.address,' ') as address,a.regDate,a.approve,a.employeeCode,b.displayName as employeeName" + "\n");
            sql_select_company_list.Append("     , ISNULL(a.companyManagementNo,' ') as companyManagementNo,ISNULL(a.companyStartNo,' ') as companyStartNo" + "\n");
			sql_select_company_list.Append("FROM Company a,GCM.dbo.UserInfo_MTB b WHERE a.employeeCode=b.upnid AND a.approve="+approve);

			if (!String.IsNullOrEmpty(key))
			{
				// 사업자 번호 검색
				if (keyWord.Equals("regNumber"))
				{
					sql_select_company_list.Append(" AND (a.regNumber1+a.regNumber2+a.regNumber3) LIKE '%" + key + "%'");
				}
				// 전화 번호 검색
				else if (keyWord.Equals("phone"))
				{
					sql_select_company_list.Append(" AND (a.phone1+a.phone2+a.phone3) LIKE '%" + key + "%'");
				}
				else
				{
					sql_select_company_list.Append(" AND " + keyWord + " LIKE '%" + key + "%' ");
				}
			}

			if (!String.IsNullOrEmpty(employeeCode))
			{
				sql_select_company_list.Append(" AND a.employeeCode='" + employeeCode + "'");
			}

			sql_select_company_list.Append(" ORDER BY a.companyCode DESC");


			//Execute the query against the database
			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_company_list.ToString(), null))
			{
				// Scroll through the results
				while (rdr.Read())
				{
					CompanyInfo obj = new CompanyInfo();
					obj = bindCompany(rdr, obj);
					list.Add(obj);
				}
			}
			log.Debug(@"=================END getCompanyList=================");

			return list;
		}

        /// <summary>
        /// 거래처 총 갯수
        /// </summary>
        /// <param name="txtKey"></param>
        /// <returns></returns>
		public Int32 getCompanyTotal(String keyWord, String key, int approve, String employeeCode)
        {
            log.Debug("=================START getCompanyTotal=================");
            log.Debug("keyWord = " + keyWord);
            log.Debug("key = " + key);

            Object totalCount=null;
            StringBuilder sql_select_company_total = new StringBuilder();
            sql_select_company_total.Append("SELECT COUNT(*) FROM Company ");
			sql_select_company_total.Append(" WHERE approve=" + approve);

			if (!String.IsNullOrEmpty(key))
			{
				// 사업자 번호 검색
				if (keyWord.Equals("regNumber"))
				{
					sql_select_company_total.Append(" AND (regNumber1+regNumber2+regNumber3) LIKE '%" + key + "%'");
				}
				// 전화 번호 검색
				else if (keyWord.Equals("phone"))
				{
					sql_select_company_total.Append(" AND (phone1+phone2+phone3) LIKE '%" + key + "%'");
				}
				else
				{
					sql_select_company_total.Append(" AND " + keyWord + " LIKE '%" + key + "%' ");
				}
			}

			if (!String.IsNullOrEmpty(employeeCode))
			{
				sql_select_company_total.Append(" AND employeeCode='" + employeeCode + "'");
			}


            totalCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_company_total.ToString(), null);

            log.Debug(@"=================END getCompanyTotal=================");

            if (totalCount == null)
            {
                return Convert.ToInt32("0");
            }
            else
            {
                return Convert.ToInt32(totalCount);
            }

        }

        /// <summary>
        /// 업체 수정
        /// </summary>
        /// <param name="carCategoryCode"></param>
        /// <param name="codeName"></param>
        /// <returns></returns>
		public int updateCompany(CompanyInfo company)
        {
            log.Debug("=================START updateCompany=================");
            log.Debug("company = " + company.ToString());

            StringBuilder sql_update = new StringBuilder();
            sql_update.Append("UPDATE Company SET");
	        sql_update.Append(" companyName=N'"+company.CompanyName+"',");
	        sql_update.Append("regNumber1='"+company.RegNumber1+"',");
	        sql_update.Append("regNumber2='"+company.RegNumber2+"',");
	        sql_update.Append("regNumber3='"+company.RegNumber3+"',");
	        sql_update.Append("phone1='"+company.Phone1+"',");
	        sql_update.Append("phone2='"+company.Phone2+"',");
	        sql_update.Append("phone3='"+company.Phone3+"',");
			sql_update.Append("masterName=N'" + company.MasterName + "',");
			sql_update.Append("approve=N'" + company.Approve+ "',");
	        sql_update.Append("address=N'"+company.Address+"',");
            sql_update.Append("companyManagementNo=N'" + company.CompanyManagementNo + "',");
            sql_update.Append("companyStartNo=N'" + company.CompanyStartNo + "'");
            sql_update.Append("WHERE	companyCode="+company.CompanyCode);

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

            log.Debug(@"=================END updateCompany=================");

            return result;
        }

        /// <summary>
        /// 업체 저장
        /// </summary>
        /// <param name="codeName"></param>
        /// <returns></returns>
		public int insertCompany(CompanyInfo company)
        {
            log.Debug("=================START insertCompany=================");
            log.Debug("company = " + company.ToString());

            StringBuilder sql_insert = new StringBuilder();
            sql_insert.Append("INSERT INTO Company");
            sql_insert.Append("(companyName,regNumber1,regNumber2,regNumber3,phone1,phone2,phone3,masterName,address,regDate,approve,employeeCode,companyManagementNo,companyStartNo)");
            sql_insert.Append("VALUES");
            sql_insert.Append("(N'"+company.CompanyName+"','"+company.RegNumber1+"','"+company.RegNumber2+"','"+company.RegNumber3+"',");
			sql_insert.Append("'"+company.Phone1+"','"+company.Phone2+"','"+company.Phone3+"',N'"+company.MasterName+"',N'"+company.Address+"',");
			sql_insert.Append("GETDATE(),"+company.Approve+",'"+company.EmployeeCode+"',N'"+company.CompanyManagementNo+"',N'"+company.CompanyStartNo+"')");

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_insert.ToString(), null);

            log.Debug(@"=================END insertCompany=================");

            return result;
        }

        /// <summary>
        /// 업체 삭제
        /// </summary>
        /// <param name="carCategoryCode"></param>
        /// <returns></returns>
        public int deleteCompany(Int32 companyCode)
        {
            log.Debug("=================START deleteCompany=================");
            log.Debug("companyCode = " + companyCode.ToString());

            StringBuilder sql_delete=new StringBuilder();
            sql_delete.Append("DELETE FROM Company WHERE companyCode="+companyCode);

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_delete.ToString(), null);

            log.Debug(@"=================END deleteCompany=================");

            return result;
        }

        /// <summary>
        /// 이미 등록여부 검사
        /// </summary>
        /// <param name="keyWord"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool existsComapny(String regNumber1,String regNumber2,String regNumber3, String companyName)
        {
            log.Debug("=================START existsComapny=================");
            log.Debug("regNumber1 = " + regNumber1);
            log.Debug("regNumber2 = " + regNumber2);
            log.Debug("regNumber3 = " + regNumber3);
            log.Debug("companyName = " + companyName);

            Object totalCount = null;
            StringBuilder sql_select_company_exists = new StringBuilder();
            sql_select_company_exists.Append("SELECT COUNT(*) FROM Company WHERE ");
            sql_select_company_exists.Append("(regNumber1='" + regNumber1 + "' AND regNumber2='" + regNumber2 + "' AND regNumber3='" + regNumber3 + "')");
            sql_select_company_exists.Append(" OR companyName='"+companyName+"'");



            totalCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_company_exists.ToString(), null);

            log.Debug(@"=================END existsComapny=================");

            if (Convert.ToInt32(totalCount) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rdr"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		private CompanyInfo bindCompany(SqlDataReader rdr, CompanyInfo obj)
		{
			obj.CompanyCode = rdr.GetInt32(0);
			obj.CompanyName = rdr.GetString(1);
			obj.RegNumber1 = rdr.GetString(2);
			obj.RegNumber2 = rdr.GetString(3);
			obj.RegNumber3 = rdr.GetString(4);
			obj.Phone1 = rdr.GetString(5);
			obj.Phone2 = rdr.GetString(6);
			obj.Phone3 = rdr.GetString(7);
			obj.MasterName = rdr.GetString(8);
			obj.Address = rdr.GetString(9);
			obj.RegDate = rdr.GetDateTime(10);
			obj.Approve = rdr.GetInt32(11);
			obj.EmployeeCode = rdr.GetString(12);
			obj.EmployeeName = rdr.GetString(13);
            obj.CompanyManagementNo = rdr.GetString(14);
            obj.CompanyStartNo = rdr.GetString(15);

			return obj;

		}
        #endregion

    }
}