using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using HanaMicron.COMS.Model;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.DBUtility;
using System.Configuration;
using log4net;

namespace HanaMicron.COMS.SQLServerDAL
{
	/// <summary>
	/// 임직원
	/// </summary>
    public class Employee : IEmployee
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Employee));

        public Employee()
		{
			log4net.Config.DOMConfigurator.Configure();
		}

        #region 직원관리

        /// <summary>
        /// free pass 등록을 위한 직원 정보 가져오기
        /// </summary>
        /// <param name="upnid"></param>
        /// <returns></returns>
        /// 
        public List<FreePassUserInfo> selectEmployeeForfreepass(String ename)
        {
            log.Debug(@"=================START selectEmployeeForfreepass=================");
            log.Debug(@"name = " + ename);

            List<FreePassUserInfo> list = new List<FreePassUserInfo>();
            StringBuilder sql_select = new StringBuilder();

            sql_select.Append(@"
                                SELECT	a.UPNID,a.displayName,b.dep_name
                                  FROM	GCM.dbo.UserInfo_MTB a ,GCM.dbo.DEPART_MTB b
                                 WHERE	a.department=b.dep_code
                                   AND a.reg_type = '9'
                                   AND a.displayName like '" + ename + "%'");

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    FreePassUserInfo obj = new FreePassUserInfo();
                    obj = bindEmployeeForFreePass(rdr, obj);
                    list.Add(obj);
                }
            }

            log.Debug(@"=================END listEmployee=================");

            return list;
        }

        /// <summary>
        /// 직원 정보 가져오기
        /// 예제
        /// EmployeeDao employeeDao = new EmployeeDao();
        /// Employee employee = new Employee();
        /// employee = employeeDao.selectEmployee(Request.QueryString["upnid"]);
        /// </summary>
        /// <param name="upnid"></param>
        /// <returns></returns>
        public EmployeeInfo selectEmployee(String upnid)
        {
            log.Debug(@"=================START selectEmployee=================");
            log.Debug(@"upnid = " + upnid);

            EmployeeInfo obj = new EmployeeInfo();

            StringBuilder sql_select = new StringBuilder();
            sql_select.Append(@"
                                SELECT	a.UPNID,a.sn,a.givenName,a.displayName,a.officeName,
                                        a.officePhoneNumber,a.emailAddress,a.homePage,a.country,
		                                a.city,a.state,a.address,a.zipcode,a.homePhoneNumber,
		                                a.mobilePhoneNumber,a.faxPhoneNumber,a.memo,a.title,
		                                a.department,a.company,a.mailBoxUrl,a.upnpwd,a.job_state,
		                                a.reg_type,a.reg_date,c.dep_name,b.title_name,a.description,
										ISNULL(d.upnid,0) as admin,d.managerLevel
                                FROM	GCM.dbo.UserInfo_MTB a LEFT OUTER JOIN Manager d ON a.upnid=d.upnid,GCM.dbo.TITLE_MTB b,GCM.dbo.DEPART_MTB c
                                WHERE	a.title=b.title_code
                                        AND a.department=c.dep_code
                                        AND a.upnid='" + upnid+"'");

            //Execute the query	
			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
            {
                if (rdr.Read())
                {
                    obj=bindEmployee(rdr, obj);
                }
            }

            log.Debug(@"=================END selectEmployee=================");

            return obj;

        }

        /// <summary>
        /// 존재하는 사번인가?
        /// </summary>
        /// <param name="upnid"></param>
        /// <param name="upnpw"></param>
        /// <returns></returns>
        public Boolean existsID(String upnid)
        {
            log.Debug(@"=================START existsID=================");
            log.Debug(@"upnid = " + upnid);

            Object existsID = null;
            StringBuilder sql_select = new StringBuilder();
            sql_select.Append("SELECT COUNT(*) ");
			sql_select.Append(" FROM GCM.dbo.UserInfo_MTB WHERE UPNid=N'" + upnid + "'");

			existsID = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null);
            if (Convert.ToInt32(existsID) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

            log.Debug(@"=================END existsID=================");

        }

        /// <summary>
        /// 사용자가 입력한 아이디,비밀번호가 맞는지 검사한다.
        /// </summary>
        /// <param name="upnid"></param>
        /// <param name="upnpw"></param>
        /// <returns></returns>
        public Boolean isPasswordMatch(String upnid,String upnpw)
        {
            log.Debug("=================START isPasswordMatch=================");
            log.Debug("upnid = " + upnid);
            log.Debug("upnpw = " + upnpw);

            Object existsCount = null;
            StringBuilder sql_select = new StringBuilder();
            sql_select.Append("SELECT COUNT(*) ");
			sql_select.Append(" FROM GCM.dbo.UserInfo_MTB WHERE UPNid=N'" + upnid + "' AND upnpwd=N'" + upnpw + "'");

			existsCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null);

            log.Debug(@"=================END isPasswordMatch=================");

            if (Convert.ToInt32(existsCount) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

		/// <summary>
		/// 부서원 가져오기
		/// </summary>
		/// <param name="dep_code"></param>
		/// <returns></returns>
		public List<EmployeeInfo> listEmployee(String department)
		{
            log.Debug("=================START listEmployee=================");
            log.Debug("department = " + department);

			List<EmployeeInfo> list = new List<EmployeeInfo>();

			StringBuilder sql_select = new StringBuilder();
			sql_select.Append("SELECT a.UPNID,a.sn,a.givenName,a.displayName,a.officeName,");
			sql_select.Append(" a.officePhoneNumber,a.emailAddress,a.homePage,a.country,");
			sql_select.Append(" a.city,a.state,a.address,a.zipcode,a.homePhoneNumber,");
			sql_select.Append(" a.mobilePhoneNumber,a.faxPhoneNumber,a.memo,a.title,");
			sql_select.Append(" a.department,a.company,a.mailBoxUrl,a.upnpwd,a.job_state,");
			sql_select.Append(" a.reg_type,a.reg_date,c.dep_name,b.title_name,a.description,ISNULL(d.upnid,0) as admin,d.managerLevel  ");
			sql_select.Append(" FROM	GCM.dbo.UserInfo_MTB a LEFT OUTER JOIN Manager d ON a.upnid=d.upnid,GCM.dbo.TITLE_MTB b,GCM.dbo.DEPART_MTB c");
			sql_select.Append(" WHERE	a.title=b.title_code");
			sql_select.Append(" AND a.department=c.dep_code AND department=N'" + department + "' AND REG_TYPE=9");
			sql_select.Append(" ORDER BY a.UPNid");

			//Execute the query against the database
			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
			{
				// Scroll through the results
				while (rdr.Read())
				{
					EmployeeInfo obj = new EmployeeInfo();
					obj = bindEmployee(rdr, obj);
					list.Add(obj);
				}
			}

            log.Debug(@"=================END listEmployee=================");

			return list;
		}

        /// <summary>
        /// RecordSet 과 Model Match
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private EmployeeInfo bindEmployee(SqlDataReader rdr, EmployeeInfo obj)
        {
            obj.Upnid = rdr.GetString(0);

            if (rdr.IsDBNull(1)) obj.Sn = "";
            else obj.Sn = rdr.GetString(1);

            if (rdr.IsDBNull(2)) obj.GivenName = "";
            else obj.GivenName = rdr.GetString(2);

            if (rdr.IsDBNull(3)) obj.DisplayName = "";
            else obj.DisplayName = rdr.GetString(3);

            if (rdr.IsDBNull(4)) obj.OfficeName = "";
            else obj.OfficeName = rdr.GetString(4);

            if (rdr.IsDBNull(5)) obj.OfficePhoneNumber = "";
            else obj.OfficePhoneNumber = rdr.GetString(5);

            if (rdr.IsDBNull(6)) obj.EmailAddress = "";
            else obj.EmailAddress = rdr.GetString(6);

            if (rdr.IsDBNull(7)) obj.HomePage = "";
            else obj.HomePage = rdr.GetString(7);

            if (rdr.IsDBNull(8)) obj.Country = "";
            else obj.Country = rdr.GetString(8);

            if (rdr.IsDBNull(9)) obj.City = "";
            else obj.City = rdr.GetString(9);

            if (rdr.IsDBNull(10)) obj.State = "";
            else obj.State = rdr.GetString(10);

            if (rdr.IsDBNull(10)) obj.State = "";
            else obj.State = rdr.GetString(10);

            if (rdr.IsDBNull(11)) obj.Address = "";
            else obj.Address = rdr.GetString(11);

            if (rdr.IsDBNull(12)) obj.Zipcode = "";
            else obj.Zipcode = rdr.GetString(12);

            if (rdr.IsDBNull(13)) obj.HomePhoneNumber = "";
            else obj.HomePhoneNumber = rdr.GetString(13);

            if (rdr.IsDBNull(14)) obj.MobilePhoneNumber = "";
            else obj.MobilePhoneNumber = rdr.GetString(14);

            if (rdr.IsDBNull(15)) obj.FaxPhoneNumber = "";
            else obj.FaxPhoneNumber = rdr.GetString(15);

            if (rdr.IsDBNull(16)) obj.Memo = "";
            else obj.Memo = rdr.GetString(16);

            if (rdr.IsDBNull(17)) obj.Title = "";
            else obj.Title = rdr.GetString(17);

            if (rdr.IsDBNull(18)) obj.Department = "";
            else obj.Department = rdr.GetString(18);

            if (rdr.IsDBNull(19)) obj.Company = "";
            else obj.Company = rdr.GetString(19);

            if (rdr.IsDBNull(20)) obj.MailBoxUrl = "";
            else obj.MailBoxUrl = rdr.GetString(20);

            if (rdr.IsDBNull(21)) obj.Upnpwd = "";
            else obj.Upnpwd = rdr.GetString(21);

            obj.Job_state = rdr.GetString(22);
            obj.Reg_type = rdr.GetString(23);

            obj.Reg_date = rdr.GetString(24);
            
            obj.Dep_name = rdr.GetString(25);
            obj.Title_name = rdr.GetString(26);

            if (rdr.IsDBNull(27)) obj.Description = "";
            else obj.Description = rdr.GetString(27);

			if (rdr.GetString(28).Equals("0")) obj.ISAdmin = false;
			else obj.ISAdmin = true;

			if (rdr.IsDBNull(29)) obj.ManagerLevel = 0;
			else obj.ManagerLevel = rdr.GetInt32(29);

            return obj;
        }
        // 2011-08-22-김민우
        /// <summary>
        /// RecordSet 과 Model Match
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private FreePassUserInfo bindEmployeeForFreePass(SqlDataReader rdr, FreePassUserInfo obj)
        {
            obj.Upnid = rdr.GetString(0);
            obj.DisplayName = rdr.GetString(1);
            obj.Dep_name = rdr.GetString(2);
            return obj;
        }


		/// <summary>
		/// 
		/// </summary>
		/// <param name="isVisit"></param>
		/// <param name="isTakeOut"></param>
		/// <returns></returns>
		public List<EmployeeInfo> listApprovor(string isVisit, string isTakeOut)
		{
            log.Debug("=================START listApprovor=================");
            log.Debug("isVisit = " + isVisit);
            log.Debug("isTakeOut = " + isTakeOut);

			List<EmployeeInfo> list = new List<EmployeeInfo>();

			StringBuilder sql_select = new StringBuilder();
			sql_select.Append("SELECT a.UPNID,a.sn,a.givenName,a.displayName,a.officeName,");
			sql_select.Append(" a.officePhoneNumber,a.emailAddress,a.homePage,a.country,");
			sql_select.Append(" a.city,a.state,a.address,a.zipcode,a.homePhoneNumber,");
			sql_select.Append(" a.mobilePhoneNumber,a.faxPhoneNumber,a.memo,a.title,");
			sql_select.Append(" a.department,a.company,a.mailBoxUrl,a.upnpwd,a.job_state,");
			sql_select.Append(" a.reg_type,a.reg_date,c.dep_name,b.title_name,a.description,ISNULL(e.upnid,0) as admin,e.managerLevel ");
			sql_select.Append(" FROM	GCM.dbo.UserInfo_MTB a LEFT OUTER JOIN Manager e ON a.upnid=e.upnid,GCM.dbo.TITLE_MTB b,GCM.dbo.DEPART_MTB c,ApprovalUser d");
			sql_select.Append(" WHERE	a.title=b.title_code");
			sql_select.Append(" AND a.department=c.dep_code");
			sql_select.Append(" AND a.UPNid=d.approvalUserCode");

			if (isVisit.Equals("1"))
			{
				sql_select.Append(" AND d.visit=1");
			}
			else if (isTakeOut.Equals("1"))
			{
				sql_select.Append(" AND d.takeOut=1");
			}
			sql_select.Append(" ORDER BY a.UPNid");


			//Execute the query against the database
			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
			{
				// Scroll through the results
				while (rdr.Read())
				{
					EmployeeInfo obj = new EmployeeInfo();
					obj = bindEmployee(rdr, obj);
					obj.DisplayName = obj.DisplayName + "(" + obj.Dep_name + ")";
					list.Add(obj);
				}
			}

            log.Debug(@"=================END listApprovor=================");

			return list;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="upnid"></param>
		/// <param name="isVisit"></param>
		/// <param name="isTakeOut"></param>
		/// <returns></returns>
		public bool existsApprovor(string upnid,String isVisit,String isTakeOut)
		{
            log.Debug("=================START existsApprovor=================");
            log.Debug("upnid = " + upnid);
            log.Debug("isVisit = " + isVisit);
            log.Debug("isTakeOut = " + isTakeOut);

			Object existsApprovor = null;
			StringBuilder sql_select = new StringBuilder();
			sql_select.Append("SELECT COUNT(*) ");
			sql_select.Append(" FROM ApprovalUser WHERE approvalUserCode='" + upnid + "'");

			if (isVisit.Equals("1"))
			{
				sql_select.Append(" AND visit=1");
			}
			else if (isTakeOut.Equals("1"))
			{
				sql_select.Append(" AND takeOut=1");
			}

			existsApprovor = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null);

            log.Debug(@"=================END existsApprovor=================");

            if (Convert.ToInt32(existsApprovor) == 0)
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
		/// <param name="employee"></param>
		/// <param name="isVisit"></param>
		/// <param name="isTakeOut"></param>
		/// <returns></returns>
		public int insertApprovor(EmployeeInfo employee, string isVisit, string isTakeOut)
		{
            log.Debug("=================START insertApprovor=================");
            log.Debug("employee = " + employee.ToString());
            log.Debug("isVisit = " + isVisit);
            log.Debug("isTakeOut = " + isTakeOut);

			StringBuilder sql_insert = new StringBuilder();
			sql_insert.Append("INSERT INTO ApprovalUser");
			sql_insert.Append("(approvalUserCode,visit,takeOut,regDate)");
			sql_insert.Append("VALUES");
			sql_insert.Append("(N'" + employee.Upnid + "',N'" + isVisit + "',N'" + isTakeOut + "',GETDATE())");

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_insert.ToString(), null);

            log.Debug(@"=================END insertApprovor=================");

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="employee"></param>
		/// <param name="isVisit"></param>
		/// <param name="isTakeOut"></param>
		/// <returns></returns>
		public int deleteApprovor(EmployeeInfo employee, string isVisit, string isTakeOut)
		{
            log.Debug("=================START deleteApprovor=================");
            log.Debug("employee = " + employee.ToString());
            log.Debug("isVisit = " + isVisit);
            log.Debug("isTakeOut = " + isTakeOut);

			StringBuilder sql_delete = new StringBuilder();
			sql_delete.Append("DELETE FROM ApprovalUser");
			sql_delete.Append(" WHERE approvalUserCode='" + employee.Upnid + "'");
			
			if (isVisit.Equals("1"))
			{
				sql_delete.Append(" AND visit=1");
			}
			else if (isTakeOut.Equals("1"))
			{
				sql_delete.Append(" AND takeOut=1");
			}

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_delete.ToString(), null);

            log.Debug(@"=================END deleteApprovor=================");

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="displayName"></param>
		/// <returns></returns>
		public List<EmployeeInfo> searchEmployeeList(String keyWord,String key)
		{
            log.Debug("=================START searchEmployeeList=================");
            log.Debug("keyWord = " + keyWord);
            log.Debug("key = " + key);

			List<EmployeeInfo> list = new List<EmployeeInfo>();

			StringBuilder sql_select = new StringBuilder();
			sql_select.Append("SELECT ");
			sql_select.Append(" a.UPNID,a.sn,a.givenName,a.displayName,a.officeName,");
			sql_select.Append(" a.officePhoneNumber,a.emailAddress,a.homePage,a.country,");
			sql_select.Append(" a.city,a.state,a.address,a.zipcode,a.homePhoneNumber,");
			sql_select.Append(" a.mobilePhoneNumber,a.faxPhoneNumber,a.memo,a.title,");
			sql_select.Append(" a.department,a.company,a.mailBoxUrl,a.upnpwd,a.job_state,");
			sql_select.Append(" a.reg_type,a.reg_date,c.dep_name,b.title_name,a.description,ISNULL(d.upnid,0) as admin,d.managerLevel  ");
			sql_select.Append(" FROM	GCM.dbo.UserInfo_MTB a LEFT OUTER JOIN Manager d ON a.upnid=d.upnid,GCM.dbo.TITLE_MTB b,GCM.dbo.DEPART_MTB c");
			sql_select.Append(" WHERE	a.title=b.title_code");
			sql_select.Append(" AND a.department=c.dep_code");
			sql_select.Append(" AND a.reg_type=9");
			if (!String.IsNullOrEmpty(key))
			{
				sql_select.Append(" AND " + keyWord + " LIKE '" + key + "%'");
			}
			sql_select.Append(" ORDER BY a.UPNid");

			//Execute the query against the database
			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
			{
				// Scroll through the results
				while (rdr.Read())
				{
					EmployeeInfo obj = new EmployeeInfo();
					obj = bindEmployee(rdr, obj);
					list.Add(obj);
				}
			}

            log.Debug(@"=================END searchEmployeeList=================");

			return list;
		}

		#endregion
	}
}
