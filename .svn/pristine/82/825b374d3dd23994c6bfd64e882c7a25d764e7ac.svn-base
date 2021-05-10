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

namespace HanaMicron.COMS.SQLServerDAL
{
	/// <summary>
	/// Manager 
	/// </summary>
	public class Manager :IManager 
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Manager));

        public Manager()
		{
			//log4net.Config.DOMConfigurator.Configure();
		}

		#region IManager 멤버

		/// <summary>
		/// 
		/// </summary>
		/// <param name="upnid"></param>
		/// <returns></returns>
		public ManagerInfo selectManager(string upnid)
		{
            log.Debug(@"=================START selectManager=================");
            log.Debug(@"upnid = " + upnid);

			ManagerInfo obj = new ManagerInfo();

			StringBuilder sql_select = new StringBuilder();
			sql_select.Append("SELECT a.upnid,b.displayName,a.managerLevel,a.regdate FROM  Manager a ,GCM.dbo.Userinfo_MTB b WHERE a.upnid=b.upnid AND upnid='" + upnid + "'");

			//Execute the query	
			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
			{
				if (rdr.Read())
				{
					obj = bindManager(rdr, obj);
				}
			}

            log.Debug(@"=================END selectManager=================");

			return obj;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<ManagerInfo> selectManagerList(int managerLevel)
		{
            log.Debug("=================START selectManagerList=================");
            log.Debug("managerLevel = " + managerLevel.ToString());

			List<ManagerInfo> list = new List<ManagerInfo>();

			StringBuilder sql_select = new StringBuilder();
			sql_select.Append("SELECT a.upnid,b.displayName,a.managerLevel,a.regdate FROM  Manager a ,GCM.dbo.Userinfo_MTB b WHERE a.upnid=b.upnid AND managerLevel = " + managerLevel + " ORDER BY a.regDate DESC");

			//Execute the query against the database
			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
			{
				// Scroll through the results
				while (rdr.Read())
				{
					ManagerInfo obj = new ManagerInfo();
					obj = bindManager(rdr, obj);
					list.Add(obj);
				}
			}

            log.Debug(@"=================END selectManagerList=================");

			return list;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="managerInfo"></param>
		/// <returns></returns>
		public int updateManager(ManagerInfo managerInfo)
		{
            log.Debug("=================START updateManager=================");
            log.Debug("managerInfo = " + managerInfo.ToString());

            log.Debug(@"=================END updateManager=================");

			return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="managerInfo"></param>
		/// <returns></returns>
		public int insertManager(ManagerInfo managerInfo)
		{
            log.Debug("=================START insertManager=================");
            log.Debug("managerInfo = " + managerInfo.ToString());

			StringBuilder sql_insert = new StringBuilder();
			sql_insert.Append("INSERT INTO Manager");
			sql_insert.Append("(upnid,managerLevel,regDate)");
			sql_insert.Append("VALUES");
			sql_insert.Append("(N'" + managerInfo.Upnid + "',N'"+managerInfo.ManagerLevel+"',GETDATE())");

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_insert.ToString(), null);

            log.Debug(@"=================END insertManager=================");

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="managerInfo"></param>
		/// <returns></returns>
		public int deleteManager(ManagerInfo managerInfo)
		{
            log.Debug("=================START deleteManager=================");
            log.Debug("managerInfo = " + managerInfo.ToString());

			StringBuilder sql_delete = new StringBuilder();
			sql_delete.Append("DELETE FROM Manager ");
			sql_delete.Append(" WHERE upnid='" + managerInfo.Upnid + "'");

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_delete.ToString(), null);

            log.Debug(@"=================END deleteManager=================");

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="managerInfo"></param>
		/// <returns></returns>
		public bool existsManager(ManagerInfo managerInfo)
		{
            log.Debug("=================START existsManager=================");
            log.Debug("managerInfo = " + managerInfo.ToString());

			Object exists = null;
			StringBuilder sql_select = new StringBuilder();
			sql_select.Append("SELECT COUNT(*) ");
			sql_select.Append(" FROM Manager WHERE upnid='" + managerInfo.Upnid + "'");

			exists = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null);

            log.Debug(@"=================END existsManager=================");

            if (Convert.ToInt32(exists) == 0)
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
		private ManagerInfo bindManager(SqlDataReader rdr, ManagerInfo obj)
		{
			obj.Upnid = rdr.GetString(0);
			obj.DisplayName = rdr.GetString(1);
			obj.ManagerLevel = rdr.GetInt32(2);
			obj.Regdate = rdr.GetDateTime(3);

			return obj;
		}
		#endregion
	}
}
