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
	/// TakeOutItemData 
	/// </summary>
	public class TakeOutItemData : ITakeOutItemData
	{

		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(TakeOutItemData));

		public TakeOutItemData()
		{
			//log4net.Config.DOMConfigurator.Configure();
		}
	
		#region ITakeOutItemData 멤버

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutItemDataCode"></param>
		/// <returns></returns>
		public TakeOutItemDataInfo  selectTakeOutItemData(string takeOutItemDataCode)
		{
			log.Debug("=================START selectTakeOutItemData=================");
			log.Debug("takeOutItemDataCode = " + takeOutItemDataCode);

			TakeOutItemDataInfo obj = new TakeOutItemDataInfo();

			StringBuilder sql_select = new StringBuilder();
			sql_select.Append(@"
							SELECT	a.takeOutItemDataCode as takeOutItemDataCode,
							a.takeOutDataCode as takeOutDataCode,
							c.takeOutItemCategoryCode as parentCategoryCode,
							c.codeNAme as parentCodeName,
							b.takeOutItemCategoryCode as subCategoryCode,
							b.codeNAme as subCodeName,
							a.takeOutItemName as takeOutItemName,
							a.takeOutItemType as takeOutItemType,
							a.account as account,
							a.unitCode as unitCode,
							d.codeName as unitName,
							a.regDate
					FROM	TakeOutItemData a,TakeOutItemCategory b ,TakeOutItemCategory c, Unit d
					WHERE	a.takeOutItemCategoryCode=b.takeOutItemCategoryCode
							AND b.groupID=c.takeOutItemCategoryCode
							AND a.unitCode=d.unitCode
							AND a.takeOutItemDataCode="+takeOutItemDataCode);

			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
			{
				if (rdr.Read())
				{
					obj = bindObject(rdr, obj);
				}
			}

			log.Debug(@"=================END selectTakeOutItemData=================");
			return obj;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutDataCode"></param>
		/// <returns></returns>
		public List<TakeOutItemDataInfo>  selectTakeOutItemDataList(string takeOutDataCode)
		{
			log.Debug("=================START selectTakeOutItemDataList=================");
			log.Debug("takeOutDataCode = " + takeOutDataCode);

			List<TakeOutItemDataInfo> list = new List<TakeOutItemDataInfo>();

			StringBuilder sql_select = new StringBuilder();
			sql_select.Append(@"
							SELECT	a.takeOutItemDataCode as takeOutItemDataCode,
									a.takeOutDataCode as takeOutDataCode,
									c.takeOutItemCategoryCode as parentCategoryCode,
									c.codeNAme as parentCodeName,
									b.takeOutItemCategoryCode as subCategoryCode,
									b.codeNAme as subCodeName,
									a.takeOutItemName as takeOutItemName,
									a.takeOutItemType as takeOutItemType,
									a.account as account,
									a.unitCode as unitCode,
									d.codeName as unitName,
									a.regDate
							FROM	TakeOutItemData a,TakeOutItemCategory b ,TakeOutItemCategory c, Unit d
							WHERE	a.takeOutItemCategoryCode=b.takeOutItemCategoryCode
									AND b.groupID=c.takeOutItemCategoryCode
									AND a.unitCode=d.unitCode
									AND a.takeOutDataCode='"+takeOutDataCode+"'");

			//Execute the query against the database
			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
			{
				// Scroll through the results
				while (rdr.Read())
				{
					TakeOutItemDataInfo obj = new TakeOutItemDataInfo();
					obj = bindObject(rdr, obj);
					list.Add(obj);
				}
			}

			log.Debug(@"=================END selectTakeOutItemDataList=================");

			return list;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutItemDataInfo"></param>
		/// <returns></returns>
		public int  insertTakeOutItemData(TakeOutItemDataInfo takeOutItemDataInfo)
		{
			log.Debug("=================START insertTakeOutItemData=================");
			log.Debug("takeOutItemDataInfo = " + takeOutItemDataInfo.ToString());

			StringBuilder sql_insert = new StringBuilder();
			sql_insert.Append("INSERT INTO TakeOutItemData");
			sql_insert.Append(" (takeOutDataCode,takeOutItemCategoryCode,takeOutItemName,takeOutItemType,account,unitCode,regDate) ");
			sql_insert.Append(" VALUES ");
			sql_insert.Append(" (N'" + takeOutItemDataInfo.TakeOutDataCode + "',"+takeOutItemDataInfo.SubCategoryCode+",N'"+takeOutItemDataInfo.TakeOutItemName+"',N'"+takeOutItemDataInfo.TakeOutItemType+"',N'"+takeOutItemDataInfo.Account+"',"+takeOutItemDataInfo.UnitCode+",GETDATE()) ");

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_insert.ToString(), null);

			log.Debug(@"=================END insertTakeOutItemData=================");

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutItemDataInfo"></param>
		/// <returns></returns>
		public int  deleteTakeOutItemData(TakeOutItemDataInfo takeOutItemDataInfo)
		{
			log.Debug("=================START deleteTakeOutItemData=================");
			log.Debug("takeOutItemDataInfo = " + takeOutItemDataInfo.ToString());

			StringBuilder sql_delete = new StringBuilder();
			sql_delete.Append("DELETE FROM TakeOutItemData WHERE takeOutItemDataCode=" + takeOutItemDataInfo.TakeOutItemDataCode);

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_delete.ToString(), null);

			log.Debug(@"=================END deleteTakeOutItemData=================");

			return result;
		}

        /// <summary>
        /// 반출 처리 (부분반출 없음. 동일 반출번호 일괄 반출처리)
        /// </summary>
        /// <param name="takeOutItemDataCode"></param>
        /// <param name="securityUserCode"></param>
        /// <returns></returns>
        public int updateOutTime(string takeOutDataCode, string securityUserCode)
        {
            log.Debug("=================START updateOutTime=================");
            log.Debug("takeOutDataCode = " + takeOutDataCode);
            log.Debug("securityUserCode = " + securityUserCode);

            StringBuilder sql_update = new StringBuilder();

            sql_update.Append("UPDATE TakeOutItemData SET takeOutTime=GETDATE(),outSecurityUserCode=N'" + securityUserCode + "' WHERE takeOutDataCode=N'" + takeOutDataCode + "'");

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

            log.Debug("=================END updateOutTime=================");

            return result;
        }

        /// <summary>
        /// 반입 처리
        /// </summary>
        /// <param name="takeOutItemDataCode"></param>
        /// <param name="securityUserCode"></param>
        /// <returns></returns>
        public int updateInTime(string takeOutItemDataCode, string securityUserCode)
        {
            log.Debug("=================START updateInTime=================");
            log.Debug("takeOutItemDataCode = " + takeOutItemDataCode);
            log.Debug("securityUserCode = " + securityUserCode);

            StringBuilder sql_update = new StringBuilder();

            sql_update.Append("UPDATE TakeOutItemData SET takeINTime=GETDATE(),inSecurityUserCode=N'" + securityUserCode + "' WHERE takeOutItemDataCode=N'" + takeOutItemDataCode + "'");

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

            log.Debug("=================END updateInTime=================");

            return result;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rdr"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		private TakeOutItemDataInfo bindObject(SqlDataReader rdr, TakeOutItemDataInfo obj)
		{
			obj.TakeOutItemDataCode = rdr.GetInt32(0);
			obj.TakeOutDataCode = rdr.GetString(1);
			obj.ParentCategoryCode = rdr.GetInt32(2);
			obj.ParentCodeName = rdr.GetString(3);
			obj.SubCategoryCode = rdr.GetInt32(4);
			obj.SubCodeName = rdr.GetString(5);
			obj.TakeOutItemName = rdr.GetString(6);
			obj.TakeOutItemType = rdr.GetString(7);
			obj.Account = rdr.GetInt32(8);
			obj.UnitCode = rdr.GetInt32(9);
			obj.UnitName = rdr.GetString(10);
			obj.RegDate = rdr.GetDateTime(11);
			return obj;
		}

		#endregion

    }
}
