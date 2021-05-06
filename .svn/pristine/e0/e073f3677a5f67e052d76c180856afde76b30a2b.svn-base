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
using HanaMicron.COMS.Utility;


namespace HanaMicron.COMS.SQLServerDAL
{
    /// <summary>
    /// SecCardData 
    /// </summary>
    public class SecCardData : ISecCardData
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(SecCardData));

        public SecCardData()
        {
            log4net.Config.DOMConfigurator.Configure();
        }

        #region ISecCardData 멤버

        public int insertSecCardData(SecCardDataInfo SecCardDataInfo)
        {
            log.Debug("=================START insertSecCardData=================");
            log.Debug("SecCardDataInfo = " + SecCardDataInfo.ToString());

            StringBuilder sql_insert = new StringBuilder();
            sql_insert.Append("INSERT INTO SecCardData");
            sql_insert.Append(" (regDate,requestUserCode ,requestUserName, ");
            sql_insert.Append(" requestDepCode ,requestDepDesc ,roleCode ,roleDesc, ");
            sql_insert.Append(" officePhone ,comment ,reqDateFrom ,reqDateEnd, ");
            sql_insert.Append(" flag,approvalState,approveTime,elecApproveCode) ");
            sql_insert.Append(" VALUES ");
            sql_insert.Append(" ('" + SecCardDataInfo.RegDate + "','" + SecCardDataInfo.RequestUserCode + "','" + SecCardDataInfo.RequestUserName + "', ");
            sql_insert.Append("'" + SecCardDataInfo.RequestDepCode + "','" + SecCardDataInfo.RequestDepDesc + "','" + SecCardDataInfo.RoleCode + "','" + SecCardDataInfo.RoleDesc + "', ");
            sql_insert.Append("'" + SecCardDataInfo.OfficePhone + "',N'" + SecCardDataInfo.Comment + "','" + SecCardDataInfo.ReqDateFrom + "','" + SecCardDataInfo.ReqDateEnd + "',");
            sql_insert.Append("" + SecCardDataInfo.Flag + "," + SecCardDataInfo.ApprovalState + ", GETDATE(),'" + SecCardDataInfo.ElecApproveCode + "')");

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_insert.ToString(), null);

            log.Debug(@"=================END insertSecCardData=================");

            return result;
        }

        public int updateSecCardData(SecCardDataInfo SecCardDataInfo)
        {
            log.Debug("=================START insertSecCardData=================");
            log.Debug("SecCardDataInfo = " + SecCardDataInfo.ToString());

            StringBuilder sql_update = new StringBuilder();
            sql_update.Append("UPDATE SecCardData SET");
            sql_update.Append(@"		
									    regDate='" + SecCardDataInfo.RegDate + @"',
                                        officePhone='" + SecCardDataInfo.OfficePhone + @"',
										comment=N'" + SecCardDataInfo.Comment + @"',
										reqDateFrom='" + SecCardDataInfo.ReqDateFrom + @"',
										reqDateEnd='" + SecCardDataInfo.ReqDateEnd + @"',
									    flag='" + SecCardDataInfo.Flag + @"'
								WHERE	secDataCode=" + SecCardDataInfo.SecDataCode);

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

            log.Debug("=================END updateSecCardData=================");

            return result;
        }
       
        public int deleteSecCardData(String secCardDataCode)
        {
            log.Debug("=================START deleteSecCardData=================");
            log.Debug("secCardDataCode = " + secCardDataCode);

            StringBuilder sql_delete = new StringBuilder();
            sql_delete.Append("DELETE FROM SecCardData WHERE secDataCode=" + secCardDataCode);

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_delete.ToString(), null);

            log.Debug("=================END deleteSecCardData=================");

            return result;

        }
       
        public SecCardDataInfo selectSecCardData(String secCardDataCode)
        {
            log.Debug(@"=================START selectSecCardData=================");
            log.Debug(@"secCardDataCode = " + secCardDataCode);
            SecCardDataInfo obj = new SecCardDataInfo();

            StringBuilder sql_select = new StringBuilder();
            sql_select.Append(@"
								SELECT secDataCode, regDate, requestUserCode, requestUserNAme, requestDepCode, requestDepDesc, roleCode, roleDesc,officePhone,comment
                                     , reqDateFrom, reqDateEnd, flag, approvalState, approveTime, elecApproveCode 
                                  FROM secCardData
							     WHERE secDataCode =" + secCardDataCode);

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
            {
                if (rdr.Read())
                {
                    obj = bindSecCardData(rdr, obj);
                }
            }

            log.Debug(@"=================END selectSecCardData=================");

            return obj;
        }

        /// <summary>
        /// list
        /// 2009.09.21 임종우
        /// 예약일 기준으로 정렬, 예약일이 오늘인것까지 보여주기로 수정
        /// </summary>
        /// <param name="keyWord"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<SecCardDataInfo> selectSecCardDataList(String keyWord, String key, String searchStartDate, String searchEndDate, String upnid, String approveUserCode, String type)
        {
            log.Debug("=================START selectVisitDataList=================");
            log.Info("start time = " + DateTime.Now);
            log.Debug("keyWord = " + keyWord);
            log.Debug("key = " + key);
            log.Debug("searchStartDate = " + searchStartDate);
            log.Debug("searchEndDate = " + searchEndDate);

            List<SecCardDataInfo> list = new List<SecCardDataInfo>();

            StringBuilder sql_select = new StringBuilder();
            sql_select.Append(@"
								SELECT secDataCode, regDate, requestUserCode, requestUserNAme, requestDepCode, requestDepDesc, roleCode, roleDesc,officePhone,comment
                                     , reqDateFrom, reqDateEnd, flag, elec.approvalState, elec.approveTime, elec.elecApproveCode  
                                  FROM SecCardData card, elecApprove elec
                                 WHERE card.elecApproveCode = elec.elecApproveCode
                               
                             ");

            if (type == "admin") // 보안실,관리자화면
            {

            }
            else
            {
                if (!String.IsNullOrEmpty(upnid))
                {   // 사용자 화면일때
                    sql_select.Append(" AND requestUserCode='" + upnid + "'");
                }
            }

            if (!String.IsNullOrEmpty(key))
            {
                sql_select.Append(" AND " + keyWord + " LIKE '%" + key + "%'");
            }
           
            if (!String.IsNullOrEmpty(searchStartDate))
            {
                sql_select.Append(" AND CONVERT(VARCHAR, CONVERT(datetime,regDate),23) >= '" + searchStartDate + "'");
            }
            if (!String.IsNullOrEmpty(searchEndDate))
            {
                sql_select.Append(" AND CONVERT(VARCHAR, CONVERT(datetime,regDate),23) <= '" + searchEndDate + "'");
            }
            if (type == "admin") // 보안실,관리자화면
            {
                sql_select.Append("ORDER BY regDate,requestUserName");
            }
            else
            {
                sql_select.Append("ORDER BY secDataCode");
            }
            
              
          
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    SecCardDataInfo obj = new SecCardDataInfo();
                    obj = bindSecCardData(rdr, obj);
                    list.Add(obj);
                }
            }

            log.Info("end time = " + DateTime.Now);
            log.Debug("=================END selectSecCardData=================");
            return list;
        }

        public int selectMaxCode()
        {
            log.Debug("=================START selectMaxCode=================");

            Object maxID = null;
            StringBuilder sql_select_max = new StringBuilder();
            sql_select_max.Append(@"SELECT MAX(secDataCode) FROM SecCardData");

            maxID = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_max.ToString(), null);
            if (maxID == null)
            {
                return Convert.ToInt32("0");
            }
            else
            {
                return Convert.ToInt32(maxID);
            }

            log.Debug("=================END selectMaxCode=================");
        }

        /// <summary>
        /// 결재
        /// </summary>
        /// <param name="visitDateCode"></param>
        /// <param name="approveStat"></param>
        /// <returns></returns>
        public int updateApprove(String secCardDataCode, String approveState, String approveContents)
        {
            log.Debug("=================START updateApprove=================");
            log.Debug("elecApproveCode = " + secCardDataCode);
            log.Debug("approveState = " + approveState);
            log.Debug("approveContents = " + approveContents);

            StringBuilder sql_update = new StringBuilder();

            if (approveState.Equals("1"))
            {
                sql_update.Append("UPDATE elecApprove SET approvalState=1,approveTime=GETDATE() WHERE elecApproveCode=" + secCardDataCode);
            }
           
            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

            log.Debug("=================END updateApprove=================");

            return result;
        }


        /// <summary>
        /// bind
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private SecCardDataInfo bindSecCardData(SqlDataReader rdr, SecCardDataInfo obj)
        {

            obj.SecDataCode = rdr.GetInt32(0);
            obj.RegDate = rdr.GetString(1);
            obj.RequestUserCode = rdr.GetString(2);
            obj.RequestUserName = rdr.GetString(3);
            obj.RequestDepCode = rdr.GetString(4);
            obj.RequestDepDesc = rdr.GetString(5);
            obj.RoleCode = rdr.GetString(6);
            obj.RoleDesc = rdr.GetString(7);
            obj.OfficePhone = rdr.GetString(8);
            obj.Comment = rdr.GetString(9);
            obj.ReqDateFrom = rdr.GetString(10);
            obj.ReqDateEnd = rdr.GetString(11);
            obj.Flag = rdr.GetInt32(12);
            obj.ApprovalState = rdr.GetInt32(13);
            if (rdr.IsDBNull(14)) obj.ApproveTime = new DateTime();
            else obj.ApproveTime = rdr.GetDateTime(14);
            obj.ElecApproveCode = rdr.GetString(15);

            /*
            obj.RegDate = rdr.GetString(0);
            obj.RequestDepDesc = rdr.GetString(1);
            obj.RequestUserName = rdr.GetString(2);
            obj.RoleDesc = rdr.GetString(3);
            obj.ApprovalState = rdr.GetInt32(4);
            */

            return obj;
        }

        #endregion
       
    }
}
