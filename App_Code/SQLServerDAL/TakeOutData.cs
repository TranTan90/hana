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
    public class TakeOutData : ITakeOutData
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(TakeOutData));

        public TakeOutData()
        {
            log4net.Config.DOMConfigurator.Configure();
        }

        #region ITakeOutData 멤버

        public TakeOutDataInfo selectTakeOutData(string takeOutDataCode)
        {
            log.Debug("=================START selectTakeOutData=================");
            log.Debug("takeOutDataCode = " + takeOutDataCode);

            TakeOutDataInfo obj = new TakeOutDataInfo();

            StringBuilder sql_select = new StringBuilder();
            sql_select.Append(@"
								SELECT	a.takeOutDataCode as takeOutDataCode,
										a.companyCode as companyCode,
										h.companyName as companyName,
										a.recieveName as recieveName,
										a.requestUserCode as requestUserCode,
										i.dep_name as requestUserDepartment,
										b.displayName as requestUserDisplayName,
										a.requireIN as requireIN,
                                        d.takeOutItemDataCode as takeOutItemDataCode,
                                        o.itemCategory as itemCategory,
                                        o.subCategory as subCategory,
                                        d.takeOutItemName as takeOutItemName,
                                        d.takeOutITemType as takeOutITemType,	
                                        d.account as account,
                                        p.codeName as unit,
										a.objectContents as objectContents,
										a.scheduleInDate as scheduleInDate,
                                        a.scheduleOutDate as scheduleOutDate,
										a.takeOutStateCode as takeOutStateCode,
										a.regDate as regDate,
										a.takeOutObjectCode as takeOutObjectCode,
										c.codeName as takeOutObjectName,
										a.approvalState as approvalState,
										a.takeOutPathStartCode as takeOutPathStartCode,
										e.takeOutPathStartName as takeOutPathStartName,
										a.takeOutPathEndCode as takeOutPathEndCode,
										f.takeOutPathEndName as takeOutPathEndName,
										a.disApprovalCategoryCode as disApprovalCategoryCode,
										g.codeName as disApprovalCategoryName,
										a.disApprovalCategoryDetail as disApprovalCategoryDetail,
										d.takeInTime as takeINTime,
										d.takeOutTime as takeOutTime,
										a.approveTime as approveTime,
										j.carCode as carCode,
										j.header + ' ' + j.number as carNumber,
										k.title_name as requestUserTitleName,
										b.officeName as officeName,
                                        l.upnid as inSecurityUserCode,
                                        l.displayName as inSecurityUserName,
                                        m.upnid as outSecurityUserCode,
                                        m.displayName as outSecurityUserName,
                                        a.elecApproveCode as elecApproveCode,
                                        a.userFile1 as userFile1,
		                                a.userFile2 as userFile2,
		                                a.userFile3 as userFile3,
                                        a.note as note
								FROM	TakeOutData a LEFT OUTER JOIN carData j ON a.carCode=j.carCode,
                                        GCM.dbo.UserInfo_MTB b,
                                        TakeOutObject c,
                                        TakeOutItemData d,
                                        TakeOutPathStart e,
										TakeOutPathEnd f,
                                        (
		                                SELECT	TakeOutData.takeOutDataCode,
				                                ut.codeName,
				                                TakeOutData.disApprovalCategoryDetail
		                                FROM TakeOutData LEFT OUTER JOIN DisApprovalCategory ut ON TakeOutData.disApprovalCategoryCode=ut.disApprovalCategoryCode
		                                ) g,
                                        Company h,
                                        GCM.dbo.DEPART_MTB i,
										GCM.dbo.TITLE_MTB k,
                                        (
									    SELECT	TakeOutData.takeOutDataCode,
											    ut.upnid,
											    ut.displayName
									    FROM TakeOutData LEFT OUTER JOIN (
                                                                            SELECT	ITM.takeOutDataCode,
													                                USR.upnid,
													                                USR.displayName
											                                FROM TakeOutItemData ITM,
												                                 GCM.dbo.UserInfo_MTB USR
											                                WHERE ITM.inSecurityUserCode=USR.upnid
                                                                            GROUP BY ITM.takeOutDataCode,USR.upnid,USR.displayName
                                                                        ) ut ON TakeOutData.takeOutDataCode=ut.takeOutDataCode
									    ) l,
									    (
									    SELECT	TakeOutData.takeOutDataCode,
											    ut.upnid,
											    ut.displayName
									    FROM TakeOutData LEFT OUTER JOIN (
                                                                            SELECT	ITM.takeOutDataCode,
													                                USR.upnid,
													                                USR.displayName
											                                FROM TakeOutItemData ITM,
												                                 GCM.dbo.UserInfo_MTB USR
											                                WHERE ITM.outSecurityUserCode=USR.upnid
                                                                            GROUP BY ITM.takeOutDataCode,USR.upnid,USR.displayName
                                                                        ) ut ON TakeOutData.takeOutDataCode=ut.takeOutDataCode
									    ) m,
                                        (
                                        SELECT a.codeName AS ItemCategory,
                                               b.codeName AS subCategory,
                                               b.takeOutItemCategoryCode
                                          FROM (
                                                 SELECT * FROM TakeOutItemCategory WHERE depthID=1
                                               ) a,
                                               (
                                                 SELECT * FROM TakeOutItemCategory WHERE depthID=2
                                               ) b
                                         WHERE a.takeOutItemCategoryCode=b.groupID
                                        ) o,
                                        Unit p
								WHERE	a.requestUserCode=b.upnid
                                        AND a.takeOutObjectCode=c.takeOutObjectCode
										AND a.takeOutDataCode=d.takeOutDataCode										
										AND a.takeOutPathStartCode=e.takeOutPathStartCode
										AND a.takeOutPathEndCode=f.takeOutPathEndCode
										AND a.takeOutDataCode=g.takeOutDataCode
										AND a.companyCode=h.companyCode
										AND b.department=i.dep_code
										AND k.title_code=b.title
                                        AND a.takeOutDataCode=l.takeOutDataCode
									    AND a.takeOutDataCode=m.takeOutDataCode
                                        AND d.takeOutItemCategoryCode=o.takeOutItemCategoryCode
                                        AND d.unitCode=p.unitCode
										AND a.takeOutDataCode='" + takeOutDataCode + "'" + @"
                               ORDER BY takeInTime, takeOutitemDataCode");

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
            {
                if (rdr.Read())
                {
                    obj = bindObject(rdr, obj);
                }
            }

            log.Debug("=================END selectTakeOutData=================");
            return obj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyWord"></param>
        /// <param name="key"></param>
        /// <param name="searchStartDate"></param>
        /// <param name="searchEndDate"></param>
        /// <param name="approveUserCode"></param>
        /// <param name="requestUserCode"></param>
        /// <returns></returns>
        public List<TakeOutDataInfo> selectTakeOutDataList(string keyWord, string key, string searchStartDate, string searchEndDate, string dateType, string requestUserCode, string pageType, bool check)
        {
            log.Debug("=================START selectTakeOutDataList=================");
            log.Debug("startTime = " + DateTime.Now);
            log.Debug("keyWord = " + keyWord);
            log.Debug("key = " + key);
            log.Debug("searchStartDate = " + searchStartDate);
            log.Debug("searchEndDate = " + searchEndDate);
            log.Debug("dateType = " + dateType);
            log.Debug("requestUserCode = " + requestUserCode);
            log.Debug("pageType = " + pageType);
            log.Debug("check = " + check);

            List<TakeOutDataInfo> list = new List<TakeOutDataInfo>();

            StringBuilder strSqlString = new StringBuilder();
            //            strSqlString.Append(@"
            //							SELECT	a.takeOutDataCode as takeOutDataCode,
            //									a.companyCode as companyCode,
            //									h.companyName as companyName,
            //									a.recieveName as recieveName,
            //									a.requestUserCode as requestUserCode,
            //									i.dep_name as requestUserDepartment,
            //									b.displayName as requestUserDisplayName,
            //									a.requireIN as requireIN,
            //                                    d.takeOutItemDataCode as takeOutItemDataCode,
            //                                    o.itemCategory as itemCategory,
            //                                    o.subCategory as subCategory,
            //                                    d.takeOutItemName as takeOutItemName,
            //                                    d.takeOutITemType as takeOutITemType,	
            //                                    d.account as account,
            //                                    p.codeName as unit,
            //									a.objectContents as objectContents,
            //									a.scheduleInDate as scheduleInDate,
            //                                    a.scheduleOutDate as scheduleOutDate,
            //									a.takeOutStateCode as takeOutStateCode,
            //									a.regDate as regDate,
            //									a.takeOutObjectCode as takeOutObjectCode,
            //									c.codeName as takeOutObjectName,
            //									a.approvalState as approvalState,
            //									a.takeOutPathStartCode as takeOutPathStartCode,
            //									e.takeOutPathStartName as takeOutPathStartName,
            //									a.takeOutPathEndCode as takeOutPathEndCode,
            //									f.takeOutPathEndName as takeOutPathEndName,
            //									a.disApprovalCategoryCode as disApprovalCategoryCode,
            //									g.codeName as disApprovalCategoryName,
            //									a.disApprovalCategoryDetail as disApprovalCategoryDetail,
            //									d.takeInTime as takeInTime,
            //									d.takeOutTime as takeOutTime,
            //									a.approveTime as approveTime,
            //									j.carCode as carCode,
            //									j.header + ' ' + j.number as carNumber,
            //									k.title_name AS requestUserTitleName,
            //									b.officeName as officeName,
            //                                    l.upnid as inSecurityUserCode,
            //                                    l.displayName as inSecurityUserName,
            //                                    m.upnid as outSecurityUserCode,
            //                                    m.displayName as outSecurityUserName,
            //                                    a.elecApproveCode as elecApproveCode,
            //                                    a.userFile1 as userFile1,
            //	                                a.userFile2 as userFile2,
            //	                                a.userFile3 as userFile3
            //							FROM	TakeOutData a LEFT OUTER JOIN carData j ON a.carCode=j.carCode,
            //                                    GCM.dbo.UserInfo_MTB b,
            //                                    TakeOutObject c,
            //                                    TakeOutItemData d,
            //                                    TakeOutPathStart e,
            //									TakeOutPathEnd f,
            //                                    (
            //		                            SELECT TakeOutData.takeOutDataCode,
            //				                           ut.codeName,
            //				                           TakeOutData.disApprovalCategoryDetail
            //		                              FROM TakeOutData LEFT OUTER JOIN DisApprovalCategory ut ON TakeOutData.disApprovalCategoryCode=ut.disApprovalCategoryCode
            //		                            ) g,
            //                                    Company h,
            //                                    GCM.dbo.DEPART_MTB i,
            //									GCM.dbo.TITLE_MTB k,
            //                                    (
            //									SELECT TakeOutData.takeOutDataCode,
            //										   ut.upnid,
            //										   ut.displayName
            //									  FROM TakeOutData LEFT OUTER JOIN (
            //                                                                        SELECT ITM.takeOutDataCode,
            //													                           USR.upnid,
            //													                           USR.displayName
            //											                              FROM TakeOutItemData ITM,
            //												                               GCM.dbo.UserInfo_MTB USR
            //											                             WHERE ITM.inSecurityUserCode=USR.upnid
            //                                                                        GROUP BY ITM.takeOutDataCode,USR.upnid,USR.displayName
            //                                                                    ) ut ON TakeOutData.takeOutDataCode=ut.takeOutDataCode
            //									) l,
            //									(
            //									SELECT TakeOutData.takeOutDataCode,
            //										   ut.upnid,
            //										   ut.displayName
            //									  FROM TakeOutData LEFT OUTER JOIN (
            //                                                                        SELECT ITM.takeOutDataCode,
            //													                           USR.upnid,
            //													                           USR.displayName
            //											                              FROM TakeOutItemData ITM,
            //												                               GCM.dbo.UserInfo_MTB USR
            //											                             WHERE ITM.outSecurityUserCode=USR.upnid
            //                                                                        GROUP BY ITM.takeOutDataCode,USR.upnid,USR.displayName
            //                                                                    ) ut ON TakeOutData.takeOutDataCode=ut.takeOutDataCode
            //									) m,
            //                                    (
            //                                    SELECT a.codeName AS ItemCategory,
            //                                           b.codeName AS subCategory,
            //                                           b.takeOutItemCategoryCode
            //                                      FROM (
            //                                             SELECT * FROM TakeOutItemCategory WHERE depthID=1
            //                                           ) a,
            //                                           (
            //                                             SELECT * FROM TakeOutItemCategory WHERE depthID=2
            //                                           ) b
            //                                     WHERE a.takeOutItemCategoryCode=b.groupID
            //                                    ) o,
            //                                    Unit p
            //							WHERE	a.requestUserCode=b.upnid									
            //									AND a.takeOutObjectCode=c.takeOutObjectCode
            //                                    AND a.takeOutDataCode=d.takeOutDataCode
            //									AND a.takeOutPathStartCode=e.takeOutPathStartCode
            //									AND a.takeOutPathEndCode=f.takeOutPathEndCode
            //									AND a.takeOutDataCode=g.takeOutDataCode
            //									AND a.companyCode=h.companyCode
            //									AND b.department=i.dep_code
            //									AND k.title_code=b.title
            //                                    AND a.takeOutDataCode=l.takeOutDataCode
            //									AND a.takeOutDataCode=m.takeOutDataCode
            //                                    AND d.takeOutItemCategoryCode=o.takeOutItemCategoryCode
            //                                    AND d.unitCode=p.unitCode
            //                                    AND b.reg_type=9");

            // 검색

            strSqlString.Append("SELECT	a.takeOutDataCode as takeOutDataCode," + "\n");
            strSqlString.Append("		a.companyCode as companyCode," + "\n");
            strSqlString.Append("		h.companyName as companyName," + "\n");
            strSqlString.Append("		a.recieveName as recieveName," + "\n");
            strSqlString.Append("		a.requestUserCode as requestUserCode," + "\n");
            strSqlString.Append("		i.dep_name as requestUserDepartment," + "\n");
            strSqlString.Append("		b.displayName as requestUserDisplayName," + "\n");
            strSqlString.Append("		a.requireIN as requireIN," + "\n");
            strSqlString.Append("       d.takeOutItemDataCode as takeOutItemDataCode," + "\n");
            strSqlString.Append("       o.itemCategory as itemCategory," + "\n");
            strSqlString.Append("       o.subCategory as subCategory," + "\n");
            strSqlString.Append("       d.takeOutItemName as takeOutItemName," + "\n");
            strSqlString.Append("       d.takeOutITemType as takeOutITemType,	" + "\n");
            strSqlString.Append("       d.account as account," + "\n");
            strSqlString.Append("       p.codeName as unit," + "\n");
            strSqlString.Append("		a.objectContents as objectContents," + "\n");
            strSqlString.Append("		a.scheduleInDate as scheduleInDate," + "\n");
            strSqlString.Append("       a.scheduleOutDate as scheduleOutDate," + "\n");
            strSqlString.Append("		a.takeOutStateCode as takeOutStateCode," + "\n");
            strSqlString.Append("		a.regDate as regDate," + "\n");
            strSqlString.Append("		a.takeOutObjectCode as takeOutObjectCode," + "\n");
            strSqlString.Append("		c.codeName as takeOutObjectName," + "\n");
            strSqlString.Append("		a.approvalState as approvalState," + "\n");
            strSqlString.Append("		a.takeOutPathStartCode as takeOutPathStartCode," + "\n");
            strSqlString.Append("		e.takeOutPathStartName as takeOutPathStartName," + "\n");
            strSqlString.Append("		a.takeOutPathEndCode as takeOutPathEndCode," + "\n");
            strSqlString.Append("		f.takeOutPathEndName as takeOutPathEndName," + "\n");
            strSqlString.Append("		a.disApprovalCategoryCode as disApprovalCategoryCode," + "\n");
            strSqlString.Append("		g.codeName as disApprovalCategoryName," + "\n");
            strSqlString.Append("		a.disApprovalCategoryDetail as disApprovalCategoryDetail," + "\n");
            strSqlString.Append("		d.takeInTime as takeInTime," + "\n");
            strSqlString.Append("		d.takeOutTime as takeOutTime," + "\n");
            strSqlString.Append("		a.approveTime as approveTime," + "\n");
            strSqlString.Append("		j.carCode as carCode," + "\n");
            strSqlString.Append("		j.header + ' ' + j.number as carNumber," + "\n");
            strSqlString.Append("		k.title_name AS requestUserTitleName," + "\n");
            strSqlString.Append("		b.officeName as officeName," + "\n");
            //strSqlString.Append("       l.upnid as inSecurityUserCode," + "\n");
            //strSqlString.Append("       l.displayName as inSecurityUserName," + "\n");
            //strSqlString.Append("       m.upnid as outSecurityUserCode," + "\n");
            //strSqlString.Append("       m.displayName as outSecurityUserName," + "\n");
            strSqlString.Append("       '' as inSecurityUserCode," + "\n");
            strSqlString.Append("       '' as inSecurityUserName," + "\n");
            strSqlString.Append("       '' as outSecurityUserCode," + "\n");
            strSqlString.Append("       '' as outSecurityUserName," + "\n");
            strSqlString.Append("       a.elecApproveCode as elecApproveCode," + "\n");
            strSqlString.Append("       a.userFile1 as userFile1," + "\n");
            strSqlString.Append("       a.userFile2 as userFile2," + "\n");
            strSqlString.Append("       a.userFile3 as userFile3," + "\n");
            strSqlString.Append("       a.note as note" + "\n");
            strSqlString.Append("  FROM	TakeOutData a LEFT OUTER JOIN carData j ON a.carCode=j.carCode," + "\n");
            strSqlString.Append("       GCM.dbo.UserInfo_MTB b," + "\n");
            strSqlString.Append("       TakeOutObject c," + "\n");
            strSqlString.Append("       TakeOutItemData d," + "\n");
            strSqlString.Append("       TakeOutPathStart e," + "\n");
            strSqlString.Append("		TakeOutPathEnd f," + "\n");
            strSqlString.Append("       (" + "\n");
            strSqlString.Append("         SELECT TakeOutData.takeOutDataCode," + "\n");
            strSqlString.Append("                ut.codeName," + "\n");
            strSqlString.Append("                TakeOutData.disApprovalCategoryDetail" + "\n");
            strSqlString.Append("           FROM TakeOutData LEFT OUTER JOIN DisApprovalCategory ut ON TakeOutData.disApprovalCategoryCode=ut.disApprovalCategoryCode" + "\n");
            strSqlString.Append("        ) g," + "\n");
            strSqlString.Append("        Company h," + "\n");
            strSqlString.Append("        GCM.dbo.DEPART_MTB i," + "\n");
            strSqlString.Append("		 GCM.dbo.TITLE_MTB k," + "\n");
            //strSqlString.Append("        (" + "\n");
            //strSqlString.Append("		       SELECT TakeOutData.takeOutDataCode," + "\n");
            //strSqlString.Append("			          ut.upnid," + "\n");
            //strSqlString.Append("			          ut.displayName" + "\n");
            //strSqlString.Append("		         FROM TakeOutData LEFT OUTER JOIN (" + "\n");
            //strSqlString.Append("                                                   SELECT ITM.takeOutItemDataCode," + "\n");
            //strSqlString.Append("						                                   USR.upnid," + "\n");
            //strSqlString.Append("						                                   USR.displayName" + "\n");
            //strSqlString.Append("				                                      FROM TakeOutItemData ITM," + "\n");
            //strSqlString.Append("					                                       GCM.dbo.UserInfo_MTB USR" + "\n");
            //strSqlString.Append("				                                     WHERE ITM.inSecurityUserCode=USR.upnid" + "\n");
            //strSqlString.Append("                                                   GROUP BY ITM.takeOutDataCode,USR.upnid,USR.displayName" + "\n");
            //strSqlString.Append("                                                 ) ut ON TakeOutData.takeOutDataCode=ut.takeOutDataCode" + "\n");
            //strSqlString.Append("		  ) l," + "\n");
            //strSqlString.Append("		  (" + "\n");
            //strSqlString.Append("		    SELECT TakeOutData.takeOutDataCode," + "\n");
            //strSqlString.Append("			       ut.upnid," + "\n");
            //strSqlString.Append("			       ut.displayName" + "\n");
            //strSqlString.Append("		      FROM TakeOutData LEFT OUTER JOIN (" + "\n");
            //strSqlString.Append("                                               SELECT ITM.takeOutItemDataCode," + "\n");
            //strSqlString.Append("						                               USR.upnid," + "\n");
            //strSqlString.Append("						                               USR.displayName" + "\n");
            //strSqlString.Append("				                                  FROM TakeOutItemData ITM," + "\n");
            //strSqlString.Append("					                                   GCM.dbo.UserInfo_MTB USR" + "\n");
            //strSqlString.Append("				                                 WHERE ITM.outSecurityUserCode=USR.upnid" + "\n");
            //strSqlString.Append("                                               GROUP BY ITM.takeOutDataCode,USR.upnid,USR.displayName" + "\n");
            //strSqlString.Append("                                              ) ut ON TakeOutData.takeOutDataCode=ut.takeOutDataCode" + "\n");
            //strSqlString.Append("		 ) m," + "\n");
            strSqlString.Append("        (" + "\n");
            strSqlString.Append("          SELECT a.codeName AS ItemCategory," + "\n");
            strSqlString.Append("                 b.codeName AS subCategory," + "\n");
            strSqlString.Append("                 b.takeOutItemCategoryCode" + "\n");
            strSqlString.Append("            FROM (" + "\n");
            strSqlString.Append("                   SELECT * FROM TakeOutItemCategory WHERE depthID=1" + "\n");
            strSqlString.Append("                  ) a," + "\n");
            strSqlString.Append("                 (" + "\n");
            strSqlString.Append("                    SELECT * FROM TakeOutItemCategory WHERE depthID=2" + "\n");
            strSqlString.Append("                  ) b" + "\n");
            strSqlString.Append("            WHERE a.takeOutItemCategoryCode=b.groupID" + "\n");
            strSqlString.Append("         ) o," + "\n");
            strSqlString.Append("         Unit p" + "\n");
            strSqlString.Append(" WHERE	a.requestUserCode=b.upnid									" + "\n");
            strSqlString.Append("	AND a.takeOutObjectCode=c.takeOutObjectCode" + "\n");
            strSqlString.Append("   AND a.takeOutDataCode=d.takeOutDataCode" + "\n");
            strSqlString.Append("	AND a.takeOutPathStartCode=e.takeOutPathStartCode" + "\n");
            strSqlString.Append("	AND a.takeOutPathEndCode=f.takeOutPathEndCode" + "\n");
            strSqlString.Append("	AND a.takeOutDataCode=g.takeOutDataCode" + "\n");
            strSqlString.Append("	AND a.companyCode=h.companyCode" + "\n");
            strSqlString.Append("	AND b.department=i.dep_code" + "\n");
            strSqlString.Append("	AND k.title_code=b.title" + "\n");
            //strSqlString.Append("   AND a.takeOutDataCode=l.takeOutDataCode" + "\n");
            //strSqlString.Append("	AND a.takeOutDataCode=m.takeOutDataCode" + "\n");
            //strSqlString.Append("   AND d.takeOutItemDataCode=l.takeOutItemDataCode" + "\n");
            //strSqlString.Append("	AND d.takeOutItemDataCode=m.takeOutItemDataCode" + "\n");
            strSqlString.Append("   AND d.takeOutItemCategoryCode=o.takeOutItemCategoryCode" + "\n");
            strSqlString.Append("   AND d.unitCode=p.unitCode" + "\n");
            //2012-03-23: 퇴사자 가 신청한 정보도 보이도록
            //strSqlString.Append("   AND b.reg_type=9" + "\n");

            if (!String.IsNullOrEmpty(key))
            {
                strSqlString.Append("   AND " + keyWord + " LIKE '%" + key + "%'" + "\n");
            }

            // 신청내역
            if (!String.IsNullOrEmpty(requestUserCode))
            {
                if (!String.IsNullOrEmpty(pageType)) //팀별로 볼때
                {
                    strSqlString.Append("   AND a.requestUserCode in (SELECT UPNID " + "\n");
                    strSqlString.Append("                               FROM GCM.dbo.UserInfo_MTB " + "\n");
                    strSqlString.Append("                              WHERE DEPARTMENT = (SELECT DEPARTMENT FROM GCM.dbo.UserInfo_MTB WHERE UPNID='" + requestUserCode + "')" + "\n");
                    strSqlString.Append("                             )" + "\n");
                }
                else //개인 볼때
                {
                    strSqlString.Append("   AND a.requestUserCode='" + requestUserCode + "'" + "\n");
                }
            }


            // 날짜 검색
            //if (!dateType.Equals("-"))
            if (dateType != null)
            {
                if (!String.IsNullOrEmpty(searchStartDate) && !String.IsNullOrEmpty(searchEndDate))
                {
                    strSqlString.Append("   AND " + dateType + " BETWEEN '" + searchStartDate + "' AND '" + searchEndDate + "'" + "\n");
                }
            }

            // 미반입 조회 (2009.08.27 임종우)
            if (check)
            {
                strSqlString.Append("   AND a.requireIN=1 " + "\n");
                strSqlString.Append("   AND d.takeOutTime IS NOT NULL " + "\n");
                strSqlString.Append("   AND d.takeInTime IS NULL " + "\n");
                strSqlString.Append("   AND a.scheduleInDate < SUBSTRING(CONVERT(VARCHAR,GETDATE(),120),1,10) " + "\n");
            }

            strSqlString.Append("ORDER BY a.takeOutDataCode DESC");

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSqlString.ToString(), null))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    TakeOutDataInfo obj = new TakeOutDataInfo();
                    obj = bindObject(rdr, obj);
                    list.Add(obj);
                }
            }

            log.Debug("endTime = " + DateTime.Now);
            log.Debug("=================END selectTakeOutDataList=================");

            return list;
        }
        // 2011-04-20-김민우: 반출입 조회 시 반출목적 검색 조건 추가
        public List<TakeOutDataInfo> selectTakeOutDataList(string keyWord, string key, string searchStartDate, string searchEndDate, string dateType, string requestUserCode, string pageType, bool check, string visitPurpose)
        {
            log.Debug("=================START selectTakeOutDataList=================");
            log.Debug("startTime = " + DateTime.Now);
            log.Debug("keyWord = " + keyWord);
            log.Debug("key = " + key);
            log.Debug("searchStartDate = " + searchStartDate);
            log.Debug("searchEndDate = " + searchEndDate);
            log.Debug("dateType = " + dateType);
            log.Debug("requestUserCode = " + requestUserCode);
            log.Debug("pageType = " + pageType);
            log.Debug("check = " + check);
            log.Debug("visitPurpose = " + visitPurpose);

            List<TakeOutDataInfo> list = new List<TakeOutDataInfo>();

            StringBuilder strSqlString = new StringBuilder();

            strSqlString.Append("SELECT	a.takeOutDataCode as takeOutDataCode," + "\n");
            strSqlString.Append("		a.companyCode as companyCode," + "\n");
            strSqlString.Append("		h.companyName as companyName," + "\n");
            strSqlString.Append("		a.recieveName as recieveName," + "\n");
            strSqlString.Append("		a.requestUserCode as requestUserCode," + "\n");
            strSqlString.Append("		i.dep_name as requestUserDepartment," + "\n");
            strSqlString.Append("		b.displayName as requestUserDisplayName," + "\n");
            strSqlString.Append("		a.requireIN as requireIN," + "\n");
            strSqlString.Append("       d.takeOutItemDataCode as takeOutItemDataCode," + "\n");
            strSqlString.Append("       o.itemCategory as itemCategory," + "\n");
            strSqlString.Append("       o.subCategory as subCategory," + "\n");
            strSqlString.Append("       d.takeOutItemName as takeOutItemName," + "\n");
            strSqlString.Append("       d.takeOutITemType as takeOutITemType,	" + "\n");
            strSqlString.Append("       d.account as account," + "\n");
            strSqlString.Append("       p.codeName as unit," + "\n");
            strSqlString.Append("		a.objectContents as objectContents," + "\n");
            strSqlString.Append("		a.scheduleInDate as scheduleInDate," + "\n");
            strSqlString.Append("       a.scheduleOutDate as scheduleOutDate," + "\n");
            strSqlString.Append("		a.takeOutStateCode as takeOutStateCode," + "\n");
            strSqlString.Append("		a.regDate as regDate," + "\n");
            strSqlString.Append("		a.takeOutObjectCode as takeOutObjectCode," + "\n");
            strSqlString.Append("		c.codeName as takeOutObjectName," + "\n");
            strSqlString.Append("		a.approvalState as approvalState," + "\n");
            strSqlString.Append("		a.takeOutPathStartCode as takeOutPathStartCode," + "\n");
            strSqlString.Append("		e.takeOutPathStartName as takeOutPathStartName," + "\n");
            strSqlString.Append("		a.takeOutPathEndCode as takeOutPathEndCode," + "\n");
            strSqlString.Append("		f.takeOutPathEndName as takeOutPathEndName," + "\n");
            strSqlString.Append("		a.disApprovalCategoryCode as disApprovalCategoryCode," + "\n");
            strSqlString.Append("		g.codeName as disApprovalCategoryName," + "\n");
            strSqlString.Append("		a.disApprovalCategoryDetail as disApprovalCategoryDetail," + "\n");
            strSqlString.Append("		d.takeInTime as takeInTime," + "\n");
            strSqlString.Append("		d.takeOutTime as takeOutTime," + "\n");
            strSqlString.Append("		a.approveTime as approveTime," + "\n");
            strSqlString.Append("		j.carCode as carCode," + "\n");
            strSqlString.Append("		j.header + ' ' + j.number as carNumber," + "\n");
            strSqlString.Append("		k.title_name AS requestUserTitleName," + "\n");
            strSqlString.Append("		b.officeName as officeName," + "\n");
            strSqlString.Append("       '' as inSecurityUserCode," + "\n");
            strSqlString.Append("       '' as inSecurityUserName," + "\n");
            strSqlString.Append("       '' as outSecurityUserCode," + "\n");
            strSqlString.Append("       '' as outSecurityUserName," + "\n");
            strSqlString.Append("       a.elecApproveCode as elecApproveCode," + "\n");
            strSqlString.Append("       a.userFile1 as userFile1," + "\n");
            strSqlString.Append("       a.userFile2 as userFile2," + "\n");
            strSqlString.Append("       a.userFile3 as userFile3," + "\n");
            strSqlString.Append("       a.note as note" + "\n");
            strSqlString.Append("  FROM	TakeOutData a LEFT OUTER JOIN carData j ON a.carCode=j.carCode," + "\n");
            strSqlString.Append("       GCM.dbo.UserInfo_MTB b," + "\n");
            strSqlString.Append("       TakeOutObject c," + "\n");
            strSqlString.Append("       TakeOutItemData d," + "\n");
            strSqlString.Append("       TakeOutPathStart e," + "\n");
            strSqlString.Append("		TakeOutPathEnd f," + "\n");
            strSqlString.Append("       (" + "\n");
            strSqlString.Append("         SELECT TakeOutData.takeOutDataCode," + "\n");
            strSqlString.Append("                ut.codeName," + "\n");
            strSqlString.Append("                TakeOutData.disApprovalCategoryDetail" + "\n");
            strSqlString.Append("           FROM TakeOutData LEFT OUTER JOIN DisApprovalCategory ut ON TakeOutData.disApprovalCategoryCode=ut.disApprovalCategoryCode" + "\n");
            strSqlString.Append("        ) g," + "\n");
            strSqlString.Append("        Company h," + "\n");
            strSqlString.Append("        GCM.dbo.DEPART_MTB i," + "\n");
            strSqlString.Append("		 GCM.dbo.TITLE_MTB k," + "\n");
            strSqlString.Append("        (" + "\n");
            strSqlString.Append("          SELECT a.codeName AS ItemCategory," + "\n");
            strSqlString.Append("                 b.codeName AS subCategory," + "\n");
            strSqlString.Append("                 b.takeOutItemCategoryCode" + "\n");
            strSqlString.Append("            FROM (" + "\n");
            strSqlString.Append("                   SELECT * FROM TakeOutItemCategory WHERE depthID=1" + "\n");
            strSqlString.Append("                  ) a," + "\n");
            strSqlString.Append("                 (" + "\n");
            strSqlString.Append("                    SELECT * FROM TakeOutItemCategory WHERE depthID=2" + "\n");
            strSqlString.Append("                  ) b" + "\n");
            strSqlString.Append("            WHERE a.takeOutItemCategoryCode=b.groupID" + "\n");
            strSqlString.Append("         ) o," + "\n");
            strSqlString.Append("         Unit p" + "\n");
            strSqlString.Append(" WHERE	a.requestUserCode=b.upnid									" + "\n");
            strSqlString.Append("	AND a.takeOutObjectCode=c.takeOutObjectCode" + "\n");
            strSqlString.Append("   AND a.takeOutDataCode=d.takeOutDataCode" + "\n");
            strSqlString.Append("	AND a.takeOutPathStartCode=e.takeOutPathStartCode" + "\n");
            strSqlString.Append("	AND a.takeOutPathEndCode=f.takeOutPathEndCode" + "\n");
            strSqlString.Append("	AND a.takeOutDataCode=g.takeOutDataCode" + "\n");
            strSqlString.Append("	AND a.companyCode=h.companyCode" + "\n");
            strSqlString.Append("	AND b.department=i.dep_code" + "\n");
            strSqlString.Append("	AND k.title_code=b.title" + "\n");
            strSqlString.Append("   AND d.takeOutItemCategoryCode=o.takeOutItemCategoryCode" + "\n");
            strSqlString.Append("   AND d.unitCode=p.unitCode" + "\n");
            //2012-03-23: 퇴사자 가 신청한 정보도 보이도록
            //strSqlString.Append("   AND b.reg_type=9" + "\n");

            if (!visitPurpose.Equals("21"))
            {
                strSqlString.Append("   AND a.takeOutObjectCode ='" + visitPurpose + "'" + "\n");
            }

            if (!String.IsNullOrEmpty(key))
            {
                strSqlString.Append("   AND " + keyWord + " LIKE '%" + key + "%'" + "\n");
            }

            // 신청내역
            if (!String.IsNullOrEmpty(requestUserCode))
            {
                if (!String.IsNullOrEmpty(pageType)) //팀별로 볼때
                {
                    strSqlString.Append("   AND a.requestUserCode in (SELECT UPNID " + "\n");
                    strSqlString.Append("                               FROM GCM.dbo.UserInfo_MTB " + "\n");
                    strSqlString.Append("                              WHERE DEPARTMENT = (SELECT DEPARTMENT FROM GCM.dbo.UserInfo_MTB WHERE UPNID='" + requestUserCode + "')" + "\n");
                    strSqlString.Append("                             )" + "\n");
                }
                else //개인 볼때
                {
                    strSqlString.Append("   AND a.requestUserCode='" + requestUserCode + "'" + "\n");
                }
            }


            // 날짜 검색
            if (!dateType.Equals("-"))
            //if (dateType != null)
            {
                if (!String.IsNullOrEmpty(searchStartDate) && !String.IsNullOrEmpty(searchEndDate))
                {
                    strSqlString.Append("   AND " + dateType + " BETWEEN '" + searchStartDate + "' AND '" + searchEndDate + "'" + "\n");
                }
            }

            // 미반입 조회 (2009.08.27 임종우)
            if (check)
            {
                strSqlString.Append("   AND a.requireIN=1 " + "\n");
                strSqlString.Append("   AND d.takeOutTime IS NOT NULL " + "\n");
                strSqlString.Append("   AND d.takeInTime IS NULL " + "\n");
                strSqlString.Append("   AND a.scheduleInDate < SUBSTRING(CONVERT(VARCHAR,GETDATE(),120),1,10) " + "\n");
            }

            strSqlString.Append("ORDER BY a.takeOutDataCode DESC");

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSqlString.ToString(), null))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    TakeOutDataInfo obj = new TakeOutDataInfo();
                    obj = bindObject(rdr, obj);
                    list.Add(obj);
                }
            }

            log.Debug("endTime = " + DateTime.Now);
            log.Debug("=================END selectTakeOutDataList=================");

            return list;
        }

        public int selectTakeOutDataTotal(string keyWord, string key, string searchStartDate, string searchEndDate, string approveUserCode, string requestUserCode)
        {
            log.Debug("=================START selectTakeOutDataTotal=================");
            log.Debug("keyWord = " + keyWord);
            log.Debug("key = " + key);
            log.Debug("searchStartDate = " + searchStartDate);
            log.Debug("searchEndDate = " + searchEndDate);
            log.Debug("approveUserCode = " + approveUserCode);
            log.Debug("requestUserCode = " + requestUserCode);

            Object totalCount = null;
            StringBuilder sql_select_total = new StringBuilder();
            sql_select_total.Append(@"
							SELECT	COUNT(*)
							FROM	TakeOutData a,GCM.dbo.UserInfo_MTB b,TakeOutObject c,GCM.dbo.UserInfo_MTB d,TakeOutPathStart e,
									TakeOutPathEnd f,DisApprovalCategory g,Company h,GCM.dbo.DEPART_MTB i
							WHERE	a.requestUserCode=b.upnid
									AND a.approvalUserCode=d.upnid
									AND a.takeOutObjectCode=c.takeOutObjectCode
									AND a.takeOutPathStartCode=e.takeOutPathStartCode
									AND a.takeOutPathEndCode=f.takeOutPathEndCode
									AND a.disApprovalCategoryCode=g.disApprovalCategoryCode
									AND a.companyCode=h.companyCode
									AND b.department=i.dep_code");
            // 검색
            if (!String.IsNullOrEmpty(key))
            {
                sql_select_total.Append(" AND " + keyWord + " LIKE '%" + key + "%'");
            }

            // 신청내역
            if (!String.IsNullOrEmpty(requestUserCode))
            {
                sql_select_total.Append(" AND a.requestUserCode='" + requestUserCode + "'");
            }

            // 결재
            if (!String.IsNullOrEmpty(approveUserCode))
            {
                sql_select_total.Append(" AND a.approveUserCode='" + approveUserCode + "'");
            }

            // 날짜 검색
            if (!String.IsNullOrEmpty(searchStartDate) && !String.IsNullOrEmpty(searchEndDate))
            {
                sql_select_total.Append(" AND a.takeOutTime BETWEEN '" + searchStartDate + "' AND '" + searchEndDate + "'");
            }


            totalCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_total.ToString(), null);

            log.Debug("total = " + totalCount.ToString());

            log.Debug("=================END selectTakeOutDataTotal=================");

            if (totalCount == null)
            {
                return Convert.ToInt32("0");
            }
            else
            {
                return Convert.ToInt32(totalCount);
            }
        }

        public int updateTakeOutData(TakeOutDataInfo takeOutDataInfo)
        {
            log.Debug("=================START updateTakeOutData=================");
            log.Debug("takeOutDataInfo = " + takeOutDataInfo.ToString());

            StringBuilder sql_update = new StringBuilder();
            sql_update.Append(@"
							UPDATE TakeOutData SET 
								takeOutDataCode='" + takeOutDataInfo.TakeOutDataCode + @"',
								companyCode='" + takeOutDataInfo.CompanyCode + @"',
								recieveName=N'" + takeOutDataInfo.RecieveName + @"',
								requestUserCode='" + takeOutDataInfo.RequestUserCode + @"',
								requireIN=N'" + takeOutDataInfo.RequireIN + @"',
								objectContents=N'" + takeOutDataInfo.ObjectContents + @"',
								scheduleInDate='" + takeOutDataInfo.ScheduleInDate + @"',
                                scheduleOutDate='" + takeOutDataInfo.ScheduleOutDate + @"',
								takeOutStateCode='" + takeOutDataInfo.TakeOutStateCode + @"',
								takeOutObjectCode='" + takeOutDataInfo.TakeOutObjectCode + @"',
								approvalState='" + takeOutDataInfo.ApprovalState + @"',
								takeOutPathEndCode='" + takeOutDataInfo.TakeOutPathEndCode + @"',
								takeOutPathStartCode='" + takeOutDataInfo.TakeOutPathStartCode + @"',
								disApprovalCategoryCode='" + takeOutDataInfo.DisApprovalCategoryCode + @"',
								disApprovalCategoryDetail=N'" + takeOutDataInfo.DisApprovalCategoryDetail + @"',
								carCode='" + takeOutDataInfo.CarCode + @"',
								elecApproveCode='" + takeOutDataInfo.ElecApproveCode + @"',
                                userFile1='" + takeOutDataInfo.UserFile1 + @"',
								userFile2='" + takeOutDataInfo.UserFile2 + @"',
								userFile3='" + takeOutDataInfo.UserFile3 + @"',
                                note=N'" + takeOutDataInfo.Note + @"'
							WHERE takeOutDataCode='" + takeOutDataInfo.TakeOutDataCode + "'");

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

            log.Debug(@"=================END updateTakeOutData=================");

            return result;
        }

        //관리자 반출 정보 수정 (2009.09.23 임종우)
        public int updateTakeOutData(string[] dataList)
        {
            log.Debug("=================START updateTakeOutData=================");
            log.Debug("dataList = " + dataList.ToString());

            StringBuilder sql_update = new StringBuilder();
            sql_update.Append(@"
           			     UPDATE TakeOutData SET 
								requireIN=N'" + dataList[2] + @"',
								scheduleInDate=N'" + dataList[1] + @"',
                                note=N'" + dataList[3] + @"'
							WHERE takeOutDataCode=N'" + dataList[0] + "'");

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

            log.Debug(@"=================END updateTakeOutData=================");

            return result;
        }

        public int insertTakeOutData(TakeOutDataInfo takeOutDataInfo)
        {
            log.Debug("=================START insertTakeOutData=================");
            log.Debug("takeOutDataInfo = " + takeOutDataInfo.ToString());

            StringBuilder sql_insert = new StringBuilder();
            sql_insert.Append("INSERT INTO TakeOutData");
            sql_insert.Append(" (takeOutDataCode,companyCode,recieveName,requestUserCode, ");
            sql_insert.Append(" requireIN,objectContents,scheduleInDate,scheduleOutDate, ");
            sql_insert.Append(" takeOutStateCode,regDate,takeOutObjectCode,approvalState, ");
            sql_insert.Append(" takeOutPathEndCode,takeOutPathStartCode,disApprovalCategoryCode,disApprovalCategoryDetail, ");
            sql_insert.Append(" elecApproveCode,carCode,userFile1,userFile2,userFile3,note) ");
            sql_insert.Append(" VALUES ");
            sql_insert.Append(" ('" + takeOutDataInfo.TakeOutDataCode + "'," + takeOutDataInfo.CompanyCode + ",N'" + takeOutDataInfo.RecieveName + "','" + takeOutDataInfo.RequestUserCode + "', ");
            sql_insert.Append("N'" + takeOutDataInfo.RequireIN + "',N'" + takeOutDataInfo.ObjectContents + "','" + takeOutDataInfo.ScheduleInDate + "','" + takeOutDataInfo.ScheduleOutDate + "', ");
            sql_insert.Append("'" + takeOutDataInfo.TakeOutStateCode + "', GETDATE(),'" + takeOutDataInfo.TakeOutObjectCode + "',N'" + takeOutDataInfo.ApprovalState + "',");
            sql_insert.Append("'" + takeOutDataInfo.TakeOutPathEndCode + "','" + takeOutDataInfo.TakeOutPathStartCode + "'," + takeOutDataInfo.DisApprovalCategoryCode + ",N'" + takeOutDataInfo.DisApprovalCategoryDetail + "',");
            sql_insert.Append("'" + takeOutDataInfo.ElecApproveCode + "','" + takeOutDataInfo.CarCode + "',");
            sql_insert.Append("N'" + takeOutDataInfo.UserFile1 + "',N'" + takeOutDataInfo.UserFile2 + "',N'" + takeOutDataInfo.UserFile3 + "',N'" + takeOutDataInfo.Note + "')");

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_insert.ToString(), null);

            log.Debug(@"=================END insertTakeOutData=================");

            return result;
        }

        public int deleteTakeOutData(TakeOutDataInfo takeOutDataInfo)
        {
            log.Debug("=================START deleteTakeOutData=================");
            log.Debug("takeOutDataInfo = " + takeOutDataInfo.ToString());

            StringBuilder sql_delete = new StringBuilder();
            sql_delete.Append("DELETE FROM TakeOutData WHERE takeOutDataCode='" + takeOutDataInfo.TakeOutDataCode + "'");

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_delete.ToString(), null);

            log.Debug(@"=================END deleteTakeOutData=================");

            return result;
        }

        public String selectNextTakeOutDataCode()
        {
            log.Debug("=================START selectNextTakeOutDataCode=================");

            Object nextCode = null;
            StringBuilder sql_select_next_code = new StringBuilder();
            sql_select_next_code.Append(@"
							SELECT ISNULL(
										RIGHT(CONVERT(VARCHAR(8),GETDATE(),112),6)+RIGHT('0000'+CONVERT(VARCHAR(4),MAX(RIGHT(takeOutDataCode,4))+1),4),
										RIGHT(CONVERT(VARCHAR(8),GETDATE(),112),6)+'0001'
										) FROM TakeOutData WHERE LEFT(takeOutDataCode,6)=RIGHT(CONVERT(VARCHAR(8),GETDATE(),112),6)");

            nextCode = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_next_code.ToString(), null);

            log.Debug("nextCode = " + nextCode);

            log.Debug(@"=================END selectNextTakeOutDataCode=================");

            return nextCode.ToString();
        }

        public int updateApprove(string takeOutDataCode, string approveState, string approveContents)
        {
            log.Debug("=================START updateApprove=================");
            log.Debug("takeOutDataCode = " + takeOutDataCode);
            log.Debug("approveState = " + approveState);
            log.Debug("approveContents = " + approveContents);

            StringBuilder sql_update = new StringBuilder();

            if (approveState.Equals("1"))
            {
                sql_update.Append("UPDATE TakeOutData SET approvalState=1,approveTime=GETDATE() WHERE takeOutDataCode='" + takeOutDataCode + "'");
            }
            else
            {
                sql_update.Append("UPDATE TakeOutData SET approvalState=2 WHERE takeOutDataCode='" + takeOutDataCode + "'");
                //sql_update.Append("UPDATE TakeOutData SET approvalState=2,approveContents='" + StringUtil.ConvertDatabaseString(approveContents) + "' WHERE takeOutDataCode='" + takeOutDataCode + "'");
            }

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

            log.Debug("=================END updateApprove=================");

            return result;
        }

        /// <summary>
        /// 사용자 업로드 파일 삭제
        /// </summary>
        /// <param name="visitDataCode"></param>
        /// <param name="fileNumber"></param>
        /// <returns></returns>
        public int DeleteUserFile(String takeOutDataCode, String fileNumber)
        {
            log.Debug("=================START DeleteUserFile=================");
            log.Debug("takeOutDataCode = " + takeOutDataCode);
            log.Debug("fileNumber = " + fileNumber);

            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE TakeOutData SET ");

            if (fileNumber.Equals("1")) sql.Append(" userFile1='' ");
            if (fileNumber.Equals("2")) sql.Append(" userFile2='' ");
            if (fileNumber.Equals("3")) sql.Append(" userFile3='' ");

            sql.Append(" WHERE takeOutDataCode='" + takeOutDataCode + "'");

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql.ToString(), null);

            log.Debug("=================END DeleteUserFile=================");

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private TakeOutDataInfo bindObject(SqlDataReader rdr, TakeOutDataInfo obj)
        {
            obj.TakeOutItemDataList = new List<TakeOutItemDataInfo>();

            obj.TakeOutItemDataList.Add(new TakeOutItemDataInfo());

            obj.TakeOutDataCode = rdr.GetString(0);
            obj.CompanyCode = rdr.GetInt32(1);
            obj.CompanyName = rdr.GetString(2);
            obj.RecieveName = rdr.GetString(3);
            obj.RequestUserCode = rdr.GetString(4);
            obj.RequestUserDepartment = rdr.GetString(5);
            obj.RequestUserDisplayName = rdr.GetString(6);
            obj.RequireIN = rdr.GetInt32(7);
            obj.TakeOutItemDataList[0].TakeOutItemDataCode = rdr.GetInt32(8);
            obj.TakeOutItemDataList[0].ParentCodeName = rdr.GetString(9);
            obj.TakeOutItemDataList[0].SubCodeName = rdr.GetString(10);
            obj.TakeOutItemDataList[0].TakeOutItemName = rdr.GetString(11);
            obj.TakeOutItemDataList[0].TakeOutItemType = rdr.GetString(12);
            obj.TakeOutItemDataList[0].Account = rdr.GetInt32(13);
            obj.TakeOutItemDataList[0].UnitName = rdr.GetString(14);
            obj.ObjectContents = rdr.GetString(15);
            obj.ScheduleInDate = rdr.GetString(16);
            obj.ScheduleOutDate = rdr.GetString(17);
            obj.TakeOutStateCode = rdr.GetInt32(18);
            obj.RegDate = rdr.GetDateTime(19);

            obj.TakeOutObjectCode = rdr.GetInt32(20);
            obj.TakeOutObjectName = rdr.GetString(21);
            obj.ApprovalState = rdr.GetInt32(22);
            obj.TakeOutPathStartCode = rdr.GetInt32(23);
            obj.TakeOutPathStartName = rdr.GetString(24);
            obj.TakeOutPathEndCode = rdr.GetInt32(25);
            obj.TakeOutPathEndName = rdr.GetString(26);
            obj.DisApprovalCategoryCode = rdr.GetInt32(27);

            if (rdr.IsDBNull(28)) obj.DisApprovalCategoryName = null;
            else obj.DisApprovalCategoryName = rdr.GetString(28);

            if (rdr.IsDBNull(29)) obj.DisApprovalCategoryDetail = null;
            else obj.DisApprovalCategoryDetail = rdr.GetString(29);

            if (rdr.IsDBNull(30)) obj.TakeOutItemDataList[0].TakeINTime = "-";
            else obj.TakeOutItemDataList[0].TakeINTime = rdr.GetDateTime(30).ToString();
            //else obj.TakeOutItemDataList[0].TakeINTime = HanaMicron.COMS.Utility.DateUtility.getDateFormatColon(rdr.GetDateTime(25));

            if (rdr.IsDBNull(31)) obj.TakeOutItemDataList[0].TakeOutTime = "-";
            else obj.TakeOutItemDataList[0].TakeOutTime = rdr.GetDateTime(31).ToString();

            if (rdr.IsDBNull(32)) obj.ApproveTime = new DateTime();
            else obj.ApproveTime = rdr.GetDateTime(32);

            if (rdr.IsDBNull(33)) obj.CarCode = 0;
            else obj.CarCode = rdr.GetInt32(33);

            if (rdr.IsDBNull(34)) obj.CarNumber = null;
            else obj.CarNumber = rdr.GetString(34);

            obj.RequestUserTitleName = rdr.GetString(35);

            if (rdr.IsDBNull(36)) obj.RequestUserOfficeName = null;
            else obj.RequestUserOfficeName = rdr.GetString(36);

            if (rdr.IsDBNull(37)) obj.TakeOutItemDataList[0].INSecurityUserCode = null;
            else obj.TakeOutItemDataList[0].INSecurityUserCode = rdr.GetString(37);

            if (rdr.IsDBNull(38)) obj.TakeOutItemDataList[0].INSecurityUserName = null;
            else obj.TakeOutItemDataList[0].INSecurityUserName = rdr.GetString(38);

            if (rdr.IsDBNull(39)) obj.TakeOutItemDataList[0].OutSecurityUserCode = null;
            else obj.TakeOutItemDataList[0].OutSecurityUserCode = rdr.GetString(39);

            if (rdr.IsDBNull(40)) obj.TakeOutItemDataList[0].OutSecurityUserName = null;
            else obj.TakeOutItemDataList[0].OutSecurityUserName = rdr.GetString(40);

            obj.ElecApproveCode = rdr.GetString(41);

            if (rdr.IsDBNull(42)) obj.UserFile1 = null;
            else obj.UserFile1 = rdr.GetString(42);

            if (rdr.IsDBNull(43)) obj.UserFile1 = null;
            else obj.UserFile2 = rdr.GetString(43);

            if (rdr.IsDBNull(44)) obj.UserFile1 = null;
            else obj.UserFile3 = rdr.GetString(44);

            if (rdr.IsDBNull(45)) obj.Note = null;
            else obj.Note = rdr.GetString(45);

            return obj;
        }
        #endregion

    }
}
