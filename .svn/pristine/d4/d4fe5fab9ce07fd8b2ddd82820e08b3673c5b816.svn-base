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
	/// Unit 
	/// </summary>
	public class Unit : IUnit
	{

		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Unit));

		public Unit()
		{
			log4net.Config.DOMConfigurator.Configure();
		}
	
		#region IUnit 멤버

		/// <summary>
		/// 
		/// </summary>
		/// <param name="unitCode"></param>
		/// <returns></returns>
		public UnitInfo  selectUnit(string unitCode)
		{
			log.Debug("=================START selectUnit=================");
			log.Debug("unitCode = " + unitCode);

			UnitInfo obj = new UnitInfo();

			StringBuilder sql_select = new StringBuilder();
			sql_select.Append("SELECT * FROM Unit WHERE unitCode=" + unitCode);

			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
			{
				if (rdr.Read())
				{
					obj = bindObject(rdr, obj);
				}
			}

			log.Debug(@"=================END selectUnit=================");
			return obj;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public List<UnitInfo>  selectUnitList(string key)
		{
			log.Debug("=================START selectUnitList=================");
			log.Debug("key = " + key);

			List<UnitInfo> list = new List<UnitInfo>();

			StringBuilder sql_select = new StringBuilder();
			sql_select.Append("SELECT * FROM Unit ");

            if (!String.IsNullOrEmpty(key))
            {
                if (key.Equals("A"))
                {
                    sql_select.Append("  WHERE status = 'Y' " + "\n");
                }
                else
                {
                    sql_select.Append("WHERE codeName LIKE '%" + key + "%'");
                }

            }
			
			sql_select.Append("ORDER BY unitCode");

			//Execute the query against the database
			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
			{
				// Scroll through the results
				while (rdr.Read())
				{
					UnitInfo obj = new UnitInfo();
					obj = bindObject(rdr, obj);
					list.Add(obj);
				}
			}

			log.Debug(@"=================END selectUnitList=================");

			return list;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public int  selectUnitTotal(string key)
		{
			log.Debug("=================START selectUnitTotal=================");
			log.Debug("key = " + key);

			Object totalCount = null;
			StringBuilder sql_select_total = new StringBuilder();
			sql_select_total.Append("SELECT COUNT(*) ");
			sql_select_total.Append("FROM Unit ");
			if (!String.IsNullOrEmpty(key))
			{
				sql_select_total.Append(" WHERE codeName LIKE '%" + key + "%'");
			}


			totalCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_total.ToString(), null);

			log.Debug(@"=================END selectUnitTotal=================");

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
		/// 
		/// </summary>
		/// <param name="unitInfo"></param>
		/// <returns></returns>
		public int  updateUnit(UnitInfo unitInfo)
		{
			log.Debug("=================START updateUnit=================");
			log.Debug("unitInfo = " + unitInfo.ToString());

			StringBuilder sql_update = new StringBuilder();
            sql_update.Append("UPDATE Unit SET codeName=N'" + unitInfo.CodeName + "', status=N'" + unitInfo.Status + "' WHERE unitCode=" + unitInfo.UnitCode);

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

			log.Debug(@"=================END updateUnit=================");

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="unitInfo"></param>
		/// <returns></returns>
		public int  insertUnit(UnitInfo unitInfo)
		{
			log.Debug("=================START insertUnit=================");
			log.Debug("unitInfo = " + unitInfo.ToString());

			StringBuilder sql_insert = new StringBuilder();
			sql_insert.Append("INSERT INTO Unit");
            sql_insert.Append(" (codeName,regDate,status) ");
			sql_insert.Append(" VALUES ");
            sql_insert.Append(" (N'" + unitInfo.CodeName + "',GETDATE() ,N'" + unitInfo.Status + "') ");

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_insert.ToString(), null);

			log.Debug(@"=================END insertUnit=================");

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="unitInfo"></param>
		/// <returns></returns>
		public int  deleteUnit(UnitInfo unitInfo)
		{
			log.Debug("=================START deleteUnit=================");
			log.Debug("unitInfo = " + unitInfo.ToString());

			StringBuilder sql_delete = new StringBuilder();
			sql_delete.Append("DELETE FROM Unit WHERE unitCode=" + unitInfo.UnitCode);

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_delete.ToString(), null);

			log.Debug(@"=================END deleteUnit=================");

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rdr"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		private UnitInfo bindObject(SqlDataReader rdr, UnitInfo obj)
		{
			obj.UnitCode = rdr.GetInt32(0);
			obj.CodeName = rdr.GetString(1);
			obj.RegDate = rdr.GetDateTime(2);
            obj.Status = rdr.GetString(3);
			return obj;
		}

		#endregion
	}
}
