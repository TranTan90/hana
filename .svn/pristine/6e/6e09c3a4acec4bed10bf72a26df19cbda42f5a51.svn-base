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
	/// VisitData 
	/// </summary>
	public class VisitorData : IVisitorData
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(VisitorData));

        public VisitorData()
		{
			log4net.Config.DOMConfigurator.Configure();
		}

		#region IVisitorData 멤버

		/// <summary>
		/// select
		/// </summary>
		/// <param name="visitorDataCode"></param>
		/// <returns></returns>
		public VisitorDataInfo selectVisitorData(string visitorDataCode)
		{
            log.Debug(@"=================START selectVisitorData=================");
            log.Debug(@"visitorDataCode = " + visitorDataCode);

			VisitorDataInfo obj = new VisitorDataInfo();

			StringBuilder sql_select = new StringBuilder();
			sql_select.Append(@"
								SELECT	VisitorData.visitorDataCode,
										VisitorData.visitDataCode,
										Visitor.visitorCode,
										Visitor.visitorName,
										Visitor.visitorPhone1,
										Visitor.visitorPhone2,
										Visitor.visitorPhone3,
										Visitor.visitorRegNumber1,
										Visitor.visitorRegNumber2,
                                        Visitor.visitorPassportNumber,
										Visitor.reject,
										Visitor.rejectContent,
										Visitor.companyCode,
										Company.companyName,
										VisitorData.visitDate,
										VisitorData.inTime,
										VisitorData.outTime,
										VisitorData.regDate
								FROM	Visitor LEFT OUTER JOIN Company ON Visitor.companyCode=Company.companyCode,VisitorData
								WHERE	Visitor.visitorCode=VisitorData.visitorCode
										AND visitorDataCode=" + visitorDataCode);

			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
			{
				if (rdr.Read())
				{
					obj = bindVisitorData(rdr, obj);
				}
			}

            log.Debug(@"=================END selectVisitorData=================");

			return obj;
		}

		/// <summary>
		/// List
		/// </summary>
		/// <param name="keyWord"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public List<VisitorDataInfo> selectVisitorDataList(string keyWord, string key)
		{
            log.Debug("=================START selectVisitorDataList=================");
            log.Debug("keyWord = " + keyWord);
            log.Debug("key = " + key);

			List<VisitorDataInfo> list = new List<VisitorDataInfo>();

			StringBuilder sql_select = new StringBuilder();

			sql_select.Append(@"
								SELECT	VisitorData.visitorDataCode,
										VisitorData.visitDataCode,
										Visitor.visitorCode,
										Visitor.visitorName,
										Visitor.visitorPhone1,
										Visitor.visitorPhone2,
										Visitor.visitorPhone3,
										Visitor.visitorRegNumber1,
										Visitor.visitorRegNumber2,
                                        Visitor.visitorPassportNumber,
										Visitor.reject,
										Visitor.rejectContent,
										Visitor.companyCode,
										Company.companyName,
										VisitorData.visitDate,
										VisitorData.inTime,
										VisitorData.outTime,
										VisitorData.regDate
								FROM	Visitor LEFT OUTER JOIN Company ON Visitor.companyCode=Company.companyCode,VisitorData
								WHERE	Visitor.visitorCode=VisitorData.visitorCode");

			if (!String.IsNullOrEmpty(key))
			{
				sql_select.Append("AND " + keyWord + " LIKE '%" + key + "%'");
			}
			sql_select.Append("ORDER BY visitorDataCode DESC");

			//Execute the query against the database
			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
			{
				// Scroll through the results
				while (rdr.Read())
				{
					VisitorDataInfo obj = new VisitorDataInfo();
					obj = bindVisitorData(rdr, obj);
					list.Add(obj);
				}
			}

            log.Debug(@"=================END selectVisitorDataList=================");

			return list;
		}

		/// <summary>
		/// List by visitDataCode
		/// </summary>
		/// <param name="visitDataCode"></param>
		/// <returns></returns>
		public List<VisitorDataInfo> selectVisitorDataList(string visitDataCode)
		{
            log.Debug("=================START selectVisitorDataList=================");
            log.Debug("visitDataCode = " + visitDataCode);

			List<VisitorDataInfo> list = new List<VisitorDataInfo>();

			StringBuilder sql_select = new StringBuilder();

			sql_select.Append(@"
								SELECT	VisitorData.visitorDataCode,
										VisitorData.visitDataCode,
										Visitor.visitorCode,
										Visitor.visitorName,
										Visitor.visitorPhone1,
										Visitor.visitorPhone2,
										Visitor.visitorPhone3,
										Visitor.visitorRegNumber1,
										Visitor.visitorRegNumber2,
                                        Visitor.visitorPassportNumber,
										Visitor.reject,
										Visitor.rejectContent,
										Visitor.companyCode,
										Company.companyName,
										VisitorData.visitDate,
										VisitorData.inTime,
										VisitorData.outTime,
										VisitorData.regDate
								FROM	Visitor LEFT OUTER JOIN Company ON Visitor.companyCode=Company.companyCode,VisitorData
								WHERE	Visitor.visitorCode=VisitorData.visitorCode
										AND visitDataCode=" + visitDataCode);

			//Execute the query against the database
			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
			{
				// Scroll through the results
				while (rdr.Read())
				{
					VisitorDataInfo obj = new VisitorDataInfo();
					obj = bindVisitorData(rdr, obj);
					list.Add(obj);
				}
			}

            log.Debug(@"=================END selectVisitorDataList=================");

			return list;
		}

		/// <summary>
		/// total
		/// </summary>
		/// <param name="keyWord"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public int selectVisitorDataTotal(string keyWord, string key)
		{
            log.Debug("=================START selectVisitorDataTotal=================");
            log.Debug("keyWord = " + keyWord);
            log.Debug("key = " + key);

			Object totalCount = null;
			StringBuilder sql_select_total = new StringBuilder();

			sql_select_total.Append(@"
								SELECT	COUNT(*)
								FROM	Visitor LEFT OUTER JOIN Company ON Visitor.companyCode=Company.companyCode,VisitorData
								WHERE	Visitor.visitorCode=VisitorData.visitorCode
									");

			if (!String.IsNullOrEmpty(key))
			{
				sql_select_total.Append(" AND " + keyWord + " LIKE '%" + key + "%'");
			}


			totalCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_total.ToString(), null);

            log.Debug(@"=================END selectVisitorDataTotal=================");

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
		/// update
		/// </summary>
		/// <param name="visitorDataInfo"></param>
		/// <returns></returns>
		public int updateVisitorData(VisitorDataInfo visitorDataInfo)
		{
            log.Debug("=================START updateVisitorData=================");
            log.Debug("visitorDataInfo = " + visitorDataInfo.ToString());

			StringBuilder sql_update = new StringBuilder();
			sql_update.Append(@"
								UPDATE VisitorData SET 
									,[visitDate] = "+visitorDataInfo.VisitDate+@"
									WHERE visitorDataCode="+visitorDataInfo.VisitorDataCode);

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

            log.Debug(@"=================END updateVisitorData=================");

			return result;
		}

		/// <summary>
		/// 입문 처리
		/// </summary>
		/// <param name="visitorDataInfo"></param>
		/// <returns></returns>
		//1212
        public int updateInTime(VisitorDataInfo visitorDataInfo)
		{
			log.Debug("=================START updateInTime=================");
			log.Debug("visitorDataInfo = " + visitorDataInfo.ToString());

			StringBuilder sql_update = new StringBuilder();
			sql_update.Append(@"
								UPDATE VisitorData SET 
									[inTime] = getdate() ,
                                    cardNo =N'" + visitorDataInfo.CardNo+@"(지급)'
									WHERE visitorDataCode=" + visitorDataInfo.VisitorDataCode);

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

			log.Debug(@"=================END updateInTime=================");

			return result;
		}

		/// <summary>
		/// 출문 처리
		/// </summary>
		/// <param name="visitorDataInfo"></param>
		/// <returns></returns>
		public int updateOutTime(VisitorDataInfo visitorDataInfo)
		{
			log.Debug("=================START updateInTime=================");
			log.Debug("visitorDataInfo = " + visitorDataInfo.ToString());

			StringBuilder sql_update = new StringBuilder();
            
			sql_update.Append(@"
								UPDATE VisitorData SET 
									[outTime] = getdate() ,
                                    cardNo =  substring(cardNo,1,CHARINDEX('(',cardNo)-1) + '(반납)'
                                    WHERE visitorDataCode=" + visitorDataInfo.VisitorDataCode);
            /*
            sql_update.Append(@"
								UPDATE VisitorData SET 
									[outTime] = getdate() 
                                    WHERE visitorDataCode=" + visitorDataInfo.VisitorDataCode);
            */
			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

			log.Debug(@"=================END updateInTime=================");

			return result;
		}

		/// <summary>
		///  insert
		/// </summary>
		/// <param name="visitorDataInfo"></param>
		/// <returns></returns>
		public int insertVisitorData(VisitorDataInfo visitorDataInfo)
		{
            log.Debug("=================START insertVisitorData=================");
            log.Debug("visitorDataInfo = " + visitorDataInfo.ToString());

			StringBuilder sql_insert = new StringBuilder();

			sql_insert.Append(@"
							INSERT INTO VisitorData
						   ([visitDataCode]
						   ,[visitorCode]
						   ,[visitDate]
						   ,[regDate])
					 VALUES
						   (" + visitorDataInfo.VisitDataCode+@"
						   ," + visitorDataInfo.VisitorInfo.VisitorCode + @"
						   ,N'" + visitorDataInfo.VisitDate +@"'
						   ,GETDATE())
						");
			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_insert.ToString(), null);

            log.Debug(@"=================END insertVisitorData=================");

			return result;
		}

		/// <summary>
		/// delete
		/// </summary>
		/// <param name="visitorDataInfo"></param>
		/// <returns></returns>
		public int deleteVisitorData(VisitorDataInfo visitorDataInfo)
		{
            log.Debug("=================START deleteVisitorData=================");
            log.Debug("visitorDataInfo = " + visitorDataInfo.ToString());

			StringBuilder sql_delete = new StringBuilder();
			sql_delete.Append("DELETE FROM VisitorData WHERE visitorDataCode=" + visitorDataInfo.VisitorDataCode);

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_delete.ToString(), null);

            log.Debug(@"=================END deleteVisitorData=================");

			return result;
		}

        /// <summary>
        /// visitorDataCode Max 값
        /// </summary>
        /// <returns></returns>
        public int selectMaxVisitorDataCode()
        {
            log.Debug("=================START selectMaxVisitorDataCode=================");

            Object maxID = null;
            StringBuilder sql_select_max = new StringBuilder();
            sql_select_max.Append(@"SELECT MAX(visitorDataCode) FROM VisitorData");

            maxID = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_max.ToString(), null);
            if (maxID == null)
            {
                return Convert.ToInt32("0");
            }
            else
            {
                return Convert.ToInt32(maxID);
            }

            log.Debug("=================END selectMaxVisitorDataCode=================");
        }

        /// <summary>
        /// 금일날짜 내방 정보중 출문미처리 된 내역
        /// </summary>
        /// <param name="visitDataCode"></param>
        /// <param name="visitorCode"></param>
        /// <returns></returns>
 
        public bool checkTodayVisitorData(string visitorCode)
        {
            log.Debug("=================START checkTodayVisitorData=================");
            log.Debug("visitorCode = " + visitorCode);

            Object totalCount = null;
            StringBuilder sql_select_checkToday = new StringBuilder();
            sql_select_checkToday.Append(@"
                                            SELECT  COUNT(*)
                                            FROM    VisitorData
                                            WHERE   visitorCode=" + visitorCode + @"
                                                AND CONVERT(VARCHAR(20),inTime,112) = CONVERT(VARCHAR(20),GETDATE(),112)
                                                AND outTime is null");

            totalCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_checkToday.ToString(), null);

            log.Debug(@"=================END checkTodayVisitorData=================");

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
		/// bind
		/// </summary>
		/// <param name="rdr"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		private VisitorDataInfo bindVisitorData(SqlDataReader rdr, VisitorDataInfo obj)
		{
			obj.CompanyInfo = new CompanyInfo(); // 내방객 회사 정보
			obj.VisitorInfo = new VisitorInfo(); // 내방객 정보

			obj.VisitorDataCode = rdr.GetInt32(0);
			obj.VisitDataCode = rdr.GetInt32(1);

			obj.VisitorInfo.VisitorCode = rdr.GetInt32(2);
			obj.VisitorInfo.VisitorName = rdr.GetString(3);
			obj.VisitorInfo.VisitorPhone1 = rdr.GetString(4);
			obj.VisitorInfo.VisitorPhone2 = rdr.GetString(5);
			obj.VisitorInfo.VisitorPhone3 = rdr.GetString(6);
			obj.VisitorInfo.VisitorRegNumber1 = rdr.GetString(7);
			obj.VisitorInfo.VisitorRegNumber2 = rdr.GetString(8);

            if (rdr.IsDBNull(9)) obj.VisitorInfo.VisitorPassportNumber = null;
            else obj.VisitorInfo.VisitorPassportNumber = rdr.GetString(9);

			obj.VisitorInfo.Reject = rdr.GetByte(10);
			obj.VisitorInfo.RejectContent = rdr.GetString(11);
			obj.CompanyInfo.CompanyCode = rdr.GetInt32(12);
			obj.CompanyInfo.CompanyName = rdr.GetString(13);

			if (rdr.IsDBNull(14)) obj.VisitDate = "-";
			else obj.VisitDate = rdr.GetDateTime(14).ToString("yyyy.MM.dd");

            if (rdr.IsDBNull(15)) obj.InTime = "-";
            else obj.InTime = HanaMicron.COMS.Utility.DateUtility.getDateFormatColon(rdr.GetDateTime(15));
            //else obj.InTime = rdr.GetDateTime(15).ToString("HH시 mm분 ss초");

			if (rdr.IsDBNull(16)) obj.OutTime = "-";
            else obj.OutTime = HanaMicron.COMS.Utility.DateUtility.getDateFormatColon(rdr.GetDateTime(16));
            //else obj.OutTime = rdr.GetDateTime(16).ToString("HH시 mm분 ss초");

			obj.RegDate = rdr.GetDateTime(17);

			return obj;
		}
		#endregion

    }
}
