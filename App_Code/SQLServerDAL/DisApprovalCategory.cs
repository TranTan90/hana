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
	/// Office 
	/// </summary>
	public class DisApprovalCategory : IDisApprovalCategory
	{

		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(DisApprovalCategory));

		public DisApprovalCategory()
		{
			log4net.Config.DOMConfigurator.Configure();
		}

		#region IDisApprovalCategory 멤버

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disApprovalCategoryCode"></param>
		/// <returns></returns>
		public DisApprovalCategoryInfo selectDisApprovalCategory(string disApprovalCategoryCode)
		{
			log.Debug("=================START selectDisApprovalCategory=================");
			log.Debug("disApprovalCategoryCode = " + disApprovalCategoryCode);

			DisApprovalCategoryInfo obj = new DisApprovalCategoryInfo();

			StringBuilder sql_select = new StringBuilder();
			sql_select.Append("SELECT * FROM DisApprovalCategory WHERE disApprovalCategoryCode=" + disApprovalCategoryCode);

			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
			{
				if (rdr.Read())
				{
					obj = bindObject(rdr, obj);
				}
			}

			log.Debug(@"=================END selectDisApprovalCategory=================");
			return obj;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public List<DisApprovalCategoryInfo> selectDisApprovalCategoryList(string key)
		{
			log.Debug("=================START selectDisApprovalCategoryList=================");
			log.Debug("key = " + key);

			List<DisApprovalCategoryInfo> list = new List<DisApprovalCategoryInfo>();

			StringBuilder sql_select = new StringBuilder();
			sql_select.Append("SELECT * FROM DisApprovalCategory ");
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

            sql_select.Append("ORDER BY CodeName");

			//Execute the query against the database
			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
			{
				// Scroll through the results
				while (rdr.Read())
				{
					DisApprovalCategoryInfo obj = new DisApprovalCategoryInfo();
					obj = bindObject(rdr, obj);
					list.Add(obj);
				}
			}

			log.Debug(@"=================END selectDisApprovalCategoryList=================");

			return list;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public int selectDisApprovalCategoryTotal(string key)
		{
			log.Debug("=================START selectDisApprovalCategoryTotal=================");
			log.Debug("key = " + key);

			Object totalCount = null;
			StringBuilder sql_select_total = new StringBuilder();
			sql_select_total.Append("SELECT COUNT(*) ");
			sql_select_total.Append("FROM DisApprovalCategory ");
			if (!String.IsNullOrEmpty(key))
			{
				sql_select_total.Append(" WHERE codeName LIKE '%" + key + "%'");
			}


			totalCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_total.ToString(), null);

			log.Debug(@"=================END selectDisApprovalCategoryTotal=================");

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
		/// <param name="disApprovalCategoryInfo"></param>
		/// <returns></returns>
		public int updateDisApprovalCategory(DisApprovalCategoryInfo disApprovalCategoryInfo)
		{
			log.Debug("=================START updateDisApprovalCategory=================");
			log.Debug("disApprovalCategoryInfo = " + disApprovalCategoryInfo.ToString());

			StringBuilder sql_update = new StringBuilder();
            sql_update.Append("UPDATE DisApprovalCategory SET codeName=N'" + disApprovalCategoryInfo.CodeName + "', status=N'" + disApprovalCategoryInfo.Status + "' WHERE disApprovalCategoryCode=" + disApprovalCategoryInfo.DisApprovalCategoryCode);

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

			log.Debug(@"=================END updateDisApprovalCategory=================");

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disApprovalCategoryInfo"></param>
		/// <returns></returns>
		public int insertDisApprovalCategory(DisApprovalCategoryInfo disApprovalCategoryInfo)
		{
			log.Debug("=================START insertDisApprovalCategory=================");
			log.Debug("disApprovalCategoryInfo = " + disApprovalCategoryInfo.ToString());

			StringBuilder sql_insert = new StringBuilder();
			sql_insert.Append("INSERT INTO DisApprovalCategory");
			sql_insert.Append(" (codeName,regDate,status) ");
			sql_insert.Append(" VALUES ");
            sql_insert.Append(" (N'" + disApprovalCategoryInfo.CodeName + "',GETDATE(),N'" + disApprovalCategoryInfo.Status + "')");

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_insert.ToString(), null);

			log.Debug(@"=================END insertDisApprovalCategory=================");

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disApprovalCategoryInfo"></param>
		/// <returns></returns>
		public int deleteDisApprovalCategory(DisApprovalCategoryInfo disApprovalCategoryInfo)
		{
			log.Debug("=================START deleteDisApprovalCategory=================");
			log.Debug("disApprovalCategoryInfo = " + disApprovalCategoryInfo.ToString());

			StringBuilder sql_delete = new StringBuilder();
			sql_delete.Append("DELETE FROM DisApprovalCategory WHERE disApprovalCategoryCode=" + disApprovalCategoryInfo.DisApprovalCategoryCode);

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_delete.ToString(), null);

			log.Debug(@"=================END deleteDisApprovalCategory=================");

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rdr"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		private DisApprovalCategoryInfo bindObject(SqlDataReader rdr, DisApprovalCategoryInfo obj)
		{
			obj.DisApprovalCategoryCode = rdr.GetInt32(0);
			obj.CodeName = rdr.GetString(1);
			obj.RegDate = rdr.GetDateTime(2);
            obj.Status = rdr.GetString(3);
            return obj;
		}

		#endregion
	}
}
