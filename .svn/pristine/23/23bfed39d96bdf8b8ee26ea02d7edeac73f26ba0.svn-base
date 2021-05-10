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
	/// TakeOutData 
	/// </summary>
	/* 2013-03-22: 김민우 DB 이전
	public class ElecApprove : IElecApprove
	{

		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ElecApprove));

        public ElecApprove()
		{
			//log4net.Config.DOMConfigurator.Configure();
        }

        public int insertElecApprove(ElecApproveInfo ElecApproveInfo)
        {
            log.Debug("=================START insertElecApprove=================");
            log.Debug("insertElecApprove = " + ElecApproveInfo.ToString());

            StringBuilder sql_insert = new StringBuilder();
            sql_insert.Append("INSERT INTO elecApprove");
            sql_insert.Append(" (elecApproveCode, approvalState) ");
            sql_insert.Append(" VALUES ");
            sql_insert.Append(" ('" + ElecApproveInfo.ElecApproveCode + "', 0)");
            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_insert.ToString(), null);

            log.Debug(@"=================END insertElecApprove=================");
            return result;
        }


        public ElecApproveInfo selectElecApproveStatus(String elecApproveCode)
        {
            ElecApproveInfo obj = new ElecApproveInfo();
            StringBuilder sql_select = new StringBuilder();

            sql_select.Append("SELECT approvalState " + "\n");
            sql_select.Append("  FROM elecApprove " + "\n");
            sql_select.Append(" WHERE elecApproveCode = '" + elecApproveCode + "'"+"\n");

            //Execute the query	
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
            {
                if (rdr.Read())
                {
                    obj = BindElecApproveObject(rdr, obj);
                }
            }
            return obj;
        }

        private ElecApproveInfo BindElecApproveObject(SqlDataReader rdr, ElecApproveInfo obj)
        {
            obj.ApprovalState = rdr.GetInt32(0);
            return obj;
        }



        #region IElecApprove 멤버

        public List<ElecStatusInfo> SelectStatus(string docCode)
        {
            StringBuilder sql_select = new StringBuilder();

            //sql_select.Append(@"EXEC EProc_ElecStatusSelect_text '" + docCode + "'");

            sql_select.Append("SELECT line_seq,user_opi,view_flag,view_date,decision,status,user_Title,DISPLAYNAME,user_depName " + "\n");
            sql_select.Append("  FROM Elec_Line_TB A,USERINFO_MTB B " + "\n");
            sql_select.Append(" WHERE A.doc_code = '" + docCode + "'" + "\n");
            sql_select.Append("   AND A.decision <> 'N' " + "\n");
            sql_select.Append("   AND B.REG_TYPE = '9' " + "\n");
            sql_select.Append("   AND A.user_id = B.UPNID " + "\n");

            List<ElecStatusInfo> list = new List<ElecStatusInfo>();

            //Execute the query	
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringElecApprove, CommandType.Text, sql_select.ToString(), null))
            {
                while (rdr.Read())
                {
                    ElecStatusInfo obj = new ElecStatusInfo();
                    obj = BindStatusObject(rdr, obj);

                    list.Add(obj);
                }
            }
            return list;
        }

        private ElecStatusInfo BindStatusObject(SqlDataReader rdr, ElecStatusInfo obj)
        {
            obj.LineSeq = rdr.GetInt16(0).ToString();

            if (rdr.IsDBNull(1)) obj.UserOpi = String.Empty;
            else obj.UserOpi = rdr.GetString(1);

            obj.ViewFlag = rdr.GetString(2);

            if (rdr.IsDBNull(3)) obj.ViewDate = String.Empty;
            else obj.ViewDate = rdr.GetDateTime(3).ToString();

            obj.Decision = rdr.GetString(4);
            obj.Status = rdr.GetString(5);
            obj.UserTitle = rdr.GetString(6);
            obj.UserName = rdr.GetString(7);
            obj.DepName = rdr.GetString(8);

            return obj;
        }

        #endregion
    }
    */
}
