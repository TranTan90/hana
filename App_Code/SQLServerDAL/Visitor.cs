using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using HanaMicron.COMS.DBUtility;
using HanaMicron.COMS.Model;
using HanaMicron.COMS.IDAL;
using System.Globalization;
using log4net;

/// MS SQL Data Access Layer
namespace HanaMicron.COMS.SQLServerDAL
{
	/// <summary>
	/// 내방객 DAL
	/// </summary>
    public class Visitor : IVisitor
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Visitor));

        public Visitor()
		{
			log4net.Config.DOMConfigurator.Configure();
		}

        #region 내방객 관리
        /// <summary>
        /// 내방객 정보 가져오기
        /// </summary>
        /// <param name="carCategoryID"></param>
        /// <returns></returns>
		public VisitorInfo getVisitor(String visitorCode)
        {
            log.Debug(@"=================START getVisitor=================");
            log.Debug(@"visitorCode = " + visitorCode);

			VisitorInfo obj = new VisitorInfo();

            StringBuilder sql_select_visitor = new StringBuilder();
            sql_select_visitor.Append("SELECT a.visitorCode,a.visitorName,a.visitorPhone1,a.visitorPhone2,a.visitorPhone3,");
            sql_select_visitor.Append("a.visitorRegNumber1,a.visitorRegNumber2,a.visitorPassportNumber,a.companyCode,a.reject,a.rejectContent,a.regDate,b.companyName,a.visitorFlag,a.esdFlag,a.esdDate");
            sql_select_visitor.Append(" FROM Visitor a LEFT OUTER JOIN Company b ON a.companyCode=b.companyCode");
            sql_select_visitor.Append(" WHERE visitorCode=" + visitorCode);

            //Execute the query	
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_visitor.ToString(), null))
            {
                if (rdr.Read())
                {
                    obj = bindVisitor(rdr, obj);
                }
            }

            log.Debug(@"=================END getVisitor=================");

            return obj;

        }

        /// <summary>
        /// 내방객 정보 가져오기(주민번호 이용)
        /// </summary>
        /// <param name="visitorRegNumber1"></param>
        /// <param name="visitorRegNumber2"></param>
        /// <returns></returns>
        public VisitorInfo getVisitor(string visitorRegNumber1, string visitorRegNumber2)
        {
            log.Debug(@"=================START getVisitor=================");
            log.Debug(@"visitorRegNumber1 = " + visitorRegNumber1);
            log.Debug(@"visitorRegNumber2 = " + visitorRegNumber2);

            VisitorInfo obj = new VisitorInfo();

            StringBuilder sql_select_visitor = new StringBuilder();
            sql_select_visitor.Append("SELECT a.visitorCode,a.visitorName,a.visitorPhone1,a.visitorPhone2,a.visitorPhone3,");
            sql_select_visitor.Append("a.visitorRegNumber1,a.visitorRegNumber2,a.visitorPassportNumber,a.companyCode,a.reject,a.rejectContent,a.regDate,b.companyName,a.visitorFlag,a.esdFlag,a.esdDate");
            sql_select_visitor.Append(" FROM Visitor a LEFT OUTER JOIN Company b ON a.companyCode=b.companyCode");
            sql_select_visitor.Append(" WHERE visitorRegNumber1='" + visitorRegNumber1 + "' AND visitorRegNumber2='" + visitorRegNumber2 + "'");

            //Execute the query	
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_visitor.ToString(), null))
            {
                if (rdr.Read())
                {
                    obj = bindVisitor(rdr, obj);
                }
            }

            log.Debug(@"=================END getVisitor=================");

            return obj;
        }

        /// <summary>
        /// 내방객 목록
        /// </summary>
        /// <param name="txtKey"></param>
        /// <returns></returns>
		public List<VisitorInfo> listVisitor(String keyWord, String key,Boolean reject)
        {
            log.Debug("=================START listVisitor=================");
            log.Debug("keyWord = " + keyWord);
			log.Debug("key = " + key);
			log.Debug("reject = " + reject);

			List<VisitorInfo> list = new List<VisitorInfo>();

            StringBuilder sql_select_list = new StringBuilder();
            sql_select_list.Append(" SELECT ");
            sql_select_list.Append(" a.visitorCode,a.visitorName,a.visitorPhone1,a.visitorPhone2,a.visitorPhone3,");
            sql_select_list.Append(" a.visitorRegNumber1,a.visitorRegNumber2,a.visitorPassportNumber,a.companyCode,a.reject,a.rejectContent,a.regDate,b.companyName,a.visitorFlag,a.esdFlag,a.esdDate ");
            sql_select_list.Append(" FROM Visitor a LEFT OUTER JOIN Company b ON a.companyCode=b.companyCode ");

			if (!String.IsNullOrEmpty(key))
			{
                sql_select_list.Append(" WHERE " + keyWord + " LIKE '%" + key + "%'");
                //sql_select_list.Append(" WHERE " + keyWord + " = '" + key + "'");
				if (reject == true)
				{
					sql_select_list.Append(" AND reject=1");
				}
			}
			else
			{
				if (reject == true)
				{
					sql_select_list.Append(" WHERE reject=1");
				}
			}

			

            sql_select_list.Append(" ORDER BY a.visitorCode DESC");
           
            

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_list.ToString(), null))
            {
                // Scroll through the results
                while (rdr.Read())
                {
					VisitorInfo obj = new VisitorInfo();
                    obj = bindVisitor(rdr, obj);
                    list.Add(obj);
                }
            }

            log.Debug(@"=================END listVisitor=================");

            return list;
        }

		/// <summary>
		/// 내방객 총 명수
		/// </summary>
		/// <param name="keyWord"></param>
		/// <param name="key"></param>
		/// <returns></returns>
        public Int32 totalVisitor(String keyWord,String key,Boolean reject)
        {
            log.Debug("=================START totalVisitor=================");
            log.Debug("keyWord = " + keyWord);
			log.Debug("key = " + key);
			log.Debug("reject = " + reject);

            Object totalCount=null;
            StringBuilder sql_select_total= new StringBuilder();
            sql_select_total.Append("SELECT COUNT(*) ");
            sql_select_total.Append("FROM Visitor a LEFT OUTER JOIN Company b ON a.companyCode=b.companyCode ");

			if (!String.IsNullOrEmpty(key))
			{
				sql_select_total.Append(" WHERE " + keyWord + " LIKE '%" + key + "%'");
				if (reject == true)
				{
					sql_select_total.Append(" AND reject=1");
				}
			}
			else
			{
				if (reject == true)
				{
					sql_select_total.Append(" WHERE reject=1");
				}
			}

            totalCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_total.ToString(), null);

            log.Debug(@"=================END totalVisitor=================");

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
		/// 내방객 수정
		/// </summary>
		/// <param name="visitor"></param>
		/// <returns></returns>
		public int updatetVisitor(VisitorInfo visitor)
        {
            log.Debug("=================START updatetVisitor=================");
            log.Debug("visitor = " + visitor.ToString());

            StringBuilder sql_update = new StringBuilder();
            sql_update.Append("UPDATE Visitor SET");
            sql_update.Append(" visitorName='" + visitor.VisitorName + "',");
            sql_update.Append("visitorPhone1='" + visitor.VisitorPhone1 + "',");
            sql_update.Append("visitorPhone2='" + visitor.VisitorPhone2 + "',");
            sql_update.Append("visitorPhone3='" + visitor.VisitorPhone3 + "',");
            sql_update.Append("visitorRegNumber1='" + visitor.VisitorRegNumber1 + "',");
            sql_update.Append("visitorRegNumber2='" + visitor.VisitorRegNumber2 + "',");
            sql_update.Append("visitorPassportNumber='" + visitor.VisitorPassportNumber + "',");
            sql_update.Append("companyCode='" + visitor.CompanyCode + "',");
            sql_update.Append("reject='" + visitor.Reject + "',");
            sql_update.Append("rejectContent='" + visitor.RejectContent + "',");
            sql_update.Append("visitorFlag=" + visitor.VisitorFlag);
            sql_update.Append(" WHERE	visitorCode=" + visitor.VisitorCode);

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

            log.Debug(@"=================END updatetVisitor=================");

            return result;
        }

		/// <summary>
		/// 내방객 저장
		/// </summary>
		/// <param name="visitor"></param>
		/// <returns></returns>
		public int insertVisitor(VisitorInfo visitor)
        {
            log.Debug("=================START insertVisitor=================");
            log.Debug("visitor = " + visitor.ToString());

            //free pass 내방객 주민등록 번호 생성 부분
            String freepassVisitorRegNum1 = DateTime.Now.ToString("yyMMdd");
            String freepassVisitorRegNum2 = HanaMicron.COMS.Utility.StringUtil.GetRandomNumber(7);
            
            StringBuilder sql_insert = new StringBuilder();
            sql_insert.Append("INSERT INTO Visitor");
            sql_insert.Append("(visitorName,visitorPhone1,visitorPhone2,visitorPhone3,visitorRegNumber1,visitorRegNumber2,visitorPassportNumber,companyCode,reject,rejectContent,regDate,visitorFlag)");
            sql_insert.Append("VALUES");

            // 내국인
            if (!String.IsNullOrEmpty(visitor.VisitorRegNumber1))
            {
                sql_insert.Append("(N'" + visitor.VisitorName + "','" + visitor.VisitorPhone1 + "','" + visitor.VisitorPhone2 + "','" + visitor.VisitorPhone3 + "','" + visitor.VisitorRegNumber1 + "','" + visitor.VisitorRegNumber2 + "','" + visitor.VisitorPassportNumber + "','" + visitor.CompanyCode + "',N'" + visitor.Reject + "',N'" + visitor.RejectContent + "',GETDATE()," + visitor.VisitorFlag + ")");
            }
            // 외국인 또는 free pass 인원
            else
            {
                // 외국인
                if (!String.IsNullOrEmpty(visitor.VisitorPassportNumber))
                {
                    sql_insert.Append("(N'" + visitor.VisitorName + "','" + visitor.VisitorPhone1 + "','" + visitor.VisitorPhone2 + "','" + visitor.VisitorPhone3 + "','000000','0000000','" + visitor.VisitorPassportNumber + "','" + visitor.CompanyCode + "',N'" + visitor.Reject + "',N'" + visitor.RejectContent + "',GETDATE()," + visitor.VisitorFlag + ")");
                }
                // free pass 인원
                else
                {
                    sql_insert.Append("(N'" + visitor.VisitorName + "','" + visitor.VisitorPhone1 + "','" + visitor.VisitorPhone2 + "','" + visitor.VisitorPhone3 + "','" + freepassVisitorRegNum1 + "','" + freepassVisitorRegNum2 + "','" + visitor.VisitorPassportNumber + "','" + visitor.CompanyCode + "',N'" + visitor.Reject + "',N'" + visitor.RejectContent + "',GETDATE()," + visitor.VisitorFlag + ")");
                }
            }

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_insert.ToString(), null);

            log.Debug(@"=================END insertVisitor=================");

            return result;
        }

		/// <summary>
		/// 내방객 삭제
		/// </summary>
		/// <param name="visitorCode"></param>
		/// <returns></returns>
        public int deleteVisitor(Int32 visitorCode)
        {
            log.Debug("=================START deleteVisitor=================");
            log.Debug("visitorCode = " + visitorCode.ToString());

            StringBuilder sql_delete=new StringBuilder();
            sql_delete.Append("DELETE FROM Visitor WHERE visitorCode=" + visitorCode);

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_delete.ToString(), null);

            log.Debug(@"=================END deleteVisitor=================");

            return result;
        }

		/// <summary>
		/// 이미 등록된 내방객인지 검사
		/// </summary>
		/// <param name="visitorRegNumber1"></param>
		/// <param name="visitorRegNumber2"></param>
		/// <returns></returns>

        /* 김민우
        public bool existsVisitor(String visitorRegNumber1, String visitorRegNumber2)
        {
            log.Debug("=================START existsVisitor=================");
            log.Debug("visitorRegNumber1 = " + visitorRegNumber1);
            log.Debug("visitorRegNumber2 = " + visitorRegNumber2);

            Object totalCount = null;
            StringBuilder sql_select_exists = new StringBuilder();
            sql_select_exists.Append("SELECT COUNT(*) FROM Visitor WHERE ");
            sql_select_exists.Append("(visitorRegNumber1='" + visitorRegNumber1 + "' AND visitorRegNumber2='" + visitorRegNumber2 + "')");

            totalCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_exists.ToString(), null);

            log.Debug(@"=================END existsVisitor=================");

            if (Convert.ToInt32(totalCount) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        */

        public bool existsVisitor(String visitorRegNumber1, String visitorName)
        {
            log.Debug("=================START existsVisitor=================");
            log.Debug("visitorRegNumber1 = " + visitorRegNumber1);
            log.Debug("visitorName = " + visitorName);

            Object totalCount = null;
            StringBuilder sql_select_exists = new StringBuilder();
            sql_select_exists.Append("SELECT COUNT(*) FROM Visitor WHERE ");
            sql_select_exists.Append("(visitorRegNumber1='" + visitorRegNumber1 + "' AND visitorName='" + visitorName + "')");

            totalCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_exists.ToString(), null);

            log.Debug(@"=================END existsVisitor=================");

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
        /// 이미 등록된 Free pass 내방객인지 검사
        /// </summary>
        /// <param name="visitorName"></param>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public bool existsFreepassVisitor(String visitorName, Int32 companyCode)
        {
            log.Debug("=================START existsFreepassVisitor=================");
            log.Debug("visitorName  = " + visitorName);
            log.Debug("companyCode = " + companyCode);

            Object totalCount = null;
            StringBuilder sql_select_exists = new StringBuilder();
            sql_select_exists.Append("SELECT COUNT(*) FROM Visitor WHERE ");
            sql_select_exists.Append("(visitorName='" + visitorName + "' AND companyCode=" + companyCode + ")");
            sql_select_exists.Append(" AND visitorFlag=2" );

            totalCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_exists.ToString(), null);

            log.Debug(@"=================END existsFreepassVisitor=================");

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
        /// free pass 내방객 유무 확인
        /// </summary>
        /// <param name="visitorCode"></param>
        /// <returns></returns>
        public bool existsFreepassVisitor(Int32 visitorCode)
        {
            log.Debug("=================START freepassVisitorCount=================");
            log.Debug("visitorCode  = " + visitorCode);
 
            Object totalCount = null;
            StringBuilder sql_select_exists = new StringBuilder();
            sql_select_exists.Append("SELECT COUNT(*) FROM Visitor WHERE ");
            sql_select_exists.Append("(visitorFlag= 2 AND visitorCode=" + visitorCode + ")");

            totalCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_exists.ToString(), null);

            log.Debug(@"=================END freepassVisitorCount=================");

            if (Convert.ToInt32(totalCount) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int updateEdsData(VisitorInfo visitor)
        {
            log.Debug("=================START updateEsdData=================");
            log.Debug("visitor = " + visitor.ToString());

            StringBuilder sql_update = new StringBuilder();
            sql_update.Append("UPDATE Visitor SET");
            sql_update.Append(" esdFlag = 'Y',");
            sql_update.Append(" esdDate = getdate()");
            sql_update.Append(" WHERE	visitorCode=" + visitor.VisitorCode);

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

            log.Debug(@"=================END updateEsdData=================");

            return result;            
        }

        private VisitorInfo bindVisitor(SqlDataReader rdr, VisitorInfo obj)
        {
            obj.VisitorCode = rdr.GetInt32(0);
            obj.VisitorName = rdr.GetString(1);
            obj.VisitorPhone1 = rdr.GetString(2);
            obj.VisitorPhone2 = rdr.GetString(3);
            obj.VisitorPhone3 = rdr.GetString(4);
            obj.VisitorRegNumber1 = rdr.GetString(5);
            obj.VisitorRegNumber2 = rdr.GetString(6);

            if (rdr.IsDBNull(7)) obj.VisitorPassportNumber = null;
            else obj.VisitorPassportNumber = rdr.GetString(7);

            if (rdr.IsDBNull(8)) obj.CompanyCode = 0;
            else obj.CompanyCode = rdr.GetInt32(8);

            obj.Reject = rdr.GetByte(9);

            if (rdr.IsDBNull(10)) obj.RejectContent = "";
            else obj.RejectContent = rdr.GetString(10);

            obj.RegDate = rdr.GetDateTime(11);

            if (rdr.IsDBNull(12)) obj.CompanyName = "";
            else obj.CompanyName = rdr.GetString(12);

            if (rdr.IsDBNull(13)) obj.VisitorFlag = 0;
            else obj.VisitorFlag = rdr.GetInt32(13);

            obj.EsdFlag = rdr.GetString(14);

            if (rdr.IsDBNull(15)) obj.EsdDate = new DateTime();
            else obj.EsdDate = rdr.GetDateTime(15);

            return obj;
        }
        #endregion

    }
}