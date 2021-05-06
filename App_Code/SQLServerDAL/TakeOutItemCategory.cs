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
	public class TakeOutItemCategory : ITakeOutItemCategory
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(TakeOutItemCategory));

		public TakeOutItemCategory()
		{
			log4net.Config.DOMConfigurator.Configure();
		}
	
		#region ITakeOutItemCategory 멤버

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutItemCategoryCode"></param>
		/// <returns></returns>
		public TakeOutItemCategoryInfo selectTakeOutItemCategory(string takeOutItemCategoryCode)
		{
			log.Debug("=================START selectTakeOutItemCategory=================");
			log.Debug("takeOutItemCategoryCode = " + takeOutItemCategoryCode);

			TakeOutItemCategoryInfo obj = new TakeOutItemCategoryInfo();

			StringBuilder sql_select = new StringBuilder();
			sql_select.Append("SELECT * FROM TakeOutItemCategory WHERE takeOutItemCategoryCode=" + takeOutItemCategoryCode);

			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
			{
				if (rdr.Read())
				{
					obj = bindObject(rdr, obj);
				}
			}

			log.Debug(@"=================END selectTakeOutItemCategory=================");
			return obj;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="depthID"></param>
		/// <param name="groupID"></param>
		/// <returns></returns>
		public List<TakeOutItemCategoryInfo> selectTakeOutItemCategoryList(int depthID,int groupID)
		{
			log.Debug("=================START selectTakeOutItemCategoryList=================");
			log.Debug("depthID = " + depthID.ToString());
			log.Debug("groupID = " + groupID.ToString());

			List<TakeOutItemCategoryInfo> list = new List<TakeOutItemCategoryInfo>();

			StringBuilder sql_select = new StringBuilder();
            //sql_select.Append("SELECT * FROM TakeOutItemCategory WHERE depthID="+depthID);

            //if (depthID==2)
            //{
            //    sql_select.Append(" AND groupID="+groupID);
            //}
            //sql_select.Append(" ORDER BY takeOutItemCategoryCode");

            // 기타 가 맨 마지막으로 보여주기 위해 수정함.
            sql_select.Append("SELECT takeOutItemCategoryCode,codeName,regDate,depthID,groupID " + "\n");
            sql_select.Append("  FROM (" + "\n");
            sql_select.Append("         SELECT ROW_NUMBER() OVER(ORDER BY takeOutItemCategoryCode) AS NUM, * " + "\n");
            sql_select.Append("           FROM TakeOutItemCategory " + "\n");
            sql_select.Append("          WHERE depthID=" + depthID + "\n");

            if (depthID == 2)
            {
                sql_select.Append("            AND groupID=" + groupID + "\n");
                sql_select.Append("            AND NOT codeName='Khác(기타)' " + "\n");
            }
            else
            {
                sql_select.Append("            AND NOT codeName='Khác (기타)' " + "\n");
            }

            sql_select.Append("         UNION ALL " + "\n");
            sql_select.Append("         SELECT '999' AS NUM, * " + "\n");
            sql_select.Append("           FROM TakeOutItemCategory " + "\n");
            sql_select.Append("          WHERE depthID=" + depthID + "\n");

            if (depthID == 2)
            {
                sql_select.Append("            AND groupID=" + groupID + "\n");
                sql_select.Append("            AND codeName='Khác (기타)' " + "\n");
            }
            else
            {
                sql_select.Append("            AND codeName='Khác (기타)' " + "\n");
            }

            sql_select.Append("       ) a" + "\n");
            sql_select.Append("ORDER BY NUM" + "\n");

			//Execute the query against the database
			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
			{
				// Scroll through the results
				while (rdr.Read())
				{
					TakeOutItemCategoryInfo obj = new TakeOutItemCategoryInfo();
					obj = bindObject(rdr, obj);
					list.Add(obj);
				}
			}

			log.Debug(@"=================END selectTakeOutItemCategoryList=================");

			return list;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public int selectTakeOutItemCategoryTotal(string key)
		{
			log.Debug("=================START selectTakeOutItemCategoryTotal=================");
			log.Debug("key = " + key);

			Object totalCount = null;
			StringBuilder sql_select_total = new StringBuilder();
			sql_select_total.Append("SELECT COUNT(*) ");
			sql_select_total.Append("FROM TakeOutItemCategory ");
			if (!String.IsNullOrEmpty(key))
			{
				sql_select_total.Append(" WHERE codeName LIKE '%" + key + "%'");
			}


			totalCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_total.ToString(), null);

			log.Debug(@"=================END selectTakeOutItemCategoryTotal=================");

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
		/// <param name="takeOutItemCategoryInfo"></param>
		/// <returns></returns>
		public int updateTakeOutItemCategory(TakeOutItemCategoryInfo takeOutItemCategoryInfo)
		{
			log.Debug("=================START updateTakeOutItemCategory=================");
			log.Debug("takeOutItemCategoryInfo = " + takeOutItemCategoryInfo.ToString());

			StringBuilder sql_update = new StringBuilder();
			sql_update.Append("UPDATE TakeOutItemCategory SET codeName=N'" + takeOutItemCategoryInfo.CodeName + "' WHERE takeOutItemCategoryCode=" + takeOutItemCategoryInfo.TakeOutItemCategoryCode);

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

			log.Debug(@"=================END updateTakeOutItemCategory=================");

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutItemCategoryInfo"></param>
		/// <returns></returns>
		public int insertTakeOutItemCategory(TakeOutItemCategoryInfo takeOutItemCategoryInfo)
		{
			log.Debug("=================START insertTakeOutItemCategory=================");
			log.Debug("takeOutItemCategoryInfo = " + takeOutItemCategoryInfo.ToString());

			StringBuilder sql_insert = new StringBuilder();
			sql_insert.Append("INSERT INTO TakeOutItemCategory");
			sql_insert.Append(" (codeName,depthID,groupID,regDate) ");
			sql_insert.Append(" VALUES ");
			sql_insert.Append(" (N'" + takeOutItemCategoryInfo.CodeName + "',"+takeOutItemCategoryInfo.DepthID+","+takeOutItemCategoryInfo.GroupID+",GETDATE()) ");

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_insert.ToString(), null);

			log.Debug(@"=================END insertTakeOutItemCategory=================");

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutItemCategoryInfo"></param>
		/// <returns></returns>
		public int deleteTakeOutItemCategory(TakeOutItemCategoryInfo takeOutItemCategoryInfo)
		{
			log.Debug("=================START deleteTakeOutItemCategory=================");
			log.Debug("takeOutItemCategoryInfo = " + takeOutItemCategoryInfo.ToString());

			StringBuilder sql_delete = new StringBuilder();
			sql_delete.Append("DELETE FROM TakeOutItemCategory WHERE takeOutItemCategoryCode=" + takeOutItemCategoryInfo.TakeOutItemCategoryCode);

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_delete.ToString(), null);

			log.Debug(@"=================END deleteTakeOutItemCategory=================");

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rdr"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		private TakeOutItemCategoryInfo bindObject(SqlDataReader rdr, TakeOutItemCategoryInfo obj)
		{
			obj.TakeOutItemCategoryCode = rdr.GetInt32(0);
			obj.CodeName = rdr.GetString(1);
			obj.RegDate = rdr.GetDateTime(2);
			obj.DepthID = rdr.GetInt32(3);
			obj.GroupID = rdr.GetInt32(4);
			return obj;
		}

		#endregion
	}
}
