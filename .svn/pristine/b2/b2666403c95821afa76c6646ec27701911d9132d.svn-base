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
	/// VisitObject 
	/// </summary>
	public class VisitObject : IVisitObject
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(VisitObject));

        public VisitObject()
		{
			//log4net.Config.DOMConfigurator.Configure();
		}

		#region IVisitObject 멤버

		/// <summary>
		/// 
		/// </summary>
		/// <param name="visitObjectCode"></param>
		/// <returns></returns>
		public VisitObjectInfo selectVisitObject(string visitObjectCode)
		{
            log.Debug("=================START selectVisitObject=================");
            log.Debug("visitObjectCode = " + visitObjectCode);

			VisitObjectInfo obj = new VisitObjectInfo();

			StringBuilder sql_select = new StringBuilder();
			sql_select.Append("SELECT * FROM VisitObject WHERE visitObjectCode=" + visitObjectCode);

			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
			{
				if (rdr.Read())
				{
					obj = bindVisitObject(rdr, obj);
				}
			}

            log.Debug("=================END selectVisitObject=================");

			return obj;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<VisitObjectInfo> selectVisitObjectList()
		{
            log.Debug("=================START selectVisitObjectList=================");

			List<VisitObjectInfo> list = new List<VisitObjectInfo>();

			StringBuilder sql_select = new StringBuilder();
			sql_select.Append("SELECT * FROM VisitObject ORDER BY visitObjectName");

			//Execute the query against the database
			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
			{
				// Scroll through the results
				while (rdr.Read())
				{
					VisitObjectInfo obj = new VisitObjectInfo();
					obj = bindVisitObject(rdr, obj);
					list.Add(obj);
				}
			}

            log.Debug("=================END selectVisitObjectList=================");

			return list;
		}

        public List<VisitObjectInfo> selectVisitObjectList(String a)
        {
            log.Debug("=================START selectVisitObjectList=================");

            List<VisitObjectInfo> list = new List<VisitObjectInfo>();

            StringBuilder sql_select = new StringBuilder();
            sql_select.Append("SELECT * FROM VisitObject WHERE STATUS = 'Y' ORDER BY visitObjectName");

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    VisitObjectInfo obj = new VisitObjectInfo();
                    obj = bindVisitObject(rdr, obj);
                    list.Add(obj);
                }
            }

            log.Debug("=================END selectVisitObjectList=================");

            return list;
        }


		/// <summary>
		/// 
		/// </summary>
		/// <param name="visitObjectInfo"></param>
		/// <returns></returns>
		public int updateVisitObject(VisitObjectInfo visitObjectInfo)
		{
            log.Debug("=================START updateVisitObject=================");
            log.Debug("visitObjectInfo = " + visitObjectInfo.ToString());

			StringBuilder sql_update = new StringBuilder();
            sql_update.Append("UPDATE VisitObject SET visitObjectName=N'" + visitObjectInfo.VisitObjectName + "', status=N'" + visitObjectInfo.Status + "' WHERE visitObjectCode=" + visitObjectInfo.VisitObjectCode);

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

            log.Debug("=================END updateVisitObject=================");

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="visitObjectInfo"></param>
		/// <returns></returns>
		public int insertVisitObject(VisitObjectInfo visitObjectInfo)
		{
            log.Debug("=================START insertVisitObject=================");
            log.Debug("visitObjectInfo = " + visitObjectInfo.ToString());

			StringBuilder sql_insert = new StringBuilder();
			sql_insert.Append("INSERT INTO VisitObject");
            sql_insert.Append(" (visitObjectName,regDate,status) ");
			sql_insert.Append(" VALUES ");
			sql_insert.Append(" (N'"+visitObjectInfo.VisitObjectName+"',GETDATE(), '" + visitObjectInfo.Status + "')");

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_insert.ToString(), null);

            log.Debug("=================END insertVisitObject=================");

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="visitObjectInfo"></param>
		/// <returns></returns>
		public int deleteVisitObject(VisitObjectInfo visitObjectInfo)
		{
            log.Debug("=================START deleteVisitObject=================");
            log.Debug("visitObjectInfo = " + visitObjectInfo.ToString());

			StringBuilder sql_delete = new StringBuilder();
			sql_delete.Append("DELETE FROM VisitObject WHERE visitObjectCode="+visitObjectInfo.VisitObjectCode);

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_delete.ToString(), null);

            log.Debug("=================END deleteVisitObject=================");

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rdr"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		private VisitObjectInfo bindVisitObject(SqlDataReader rdr, VisitObjectInfo obj)
		{
			obj.VisitObjectCode=rdr.GetInt32(0);
			obj.VisitObjectName = rdr.GetString(1);
			obj.RegDate = rdr.GetDateTime(2);
            obj.Status = rdr.GetString(3);

			return obj;
		}
		#endregion
	}
}
