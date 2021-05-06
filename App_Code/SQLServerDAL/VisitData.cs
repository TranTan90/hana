using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using HanaMicron.COMS.DBUtility;
using HanaMicron.COMS.Model;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Utility;
using System.Globalization;
using log4net;

namespace HanaMicron.COMS.SQLServerDAL
{
    /// <summary>
    /// VisitData 
    /// </summary>
    public class VisitData : IVisitData
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(VisitData));

        /// <summary>
        /// 
        /// </summary>
        public VisitData()
        {
            log4net.Config.DOMConfigurator.Configure();
        }

        #region IVisitData 멤버

        /// <summary>
        /// select
        /// </summary>
        /// <param name="visitDataCode"></param>
        /// <returns></returns>
        public VisitDataInfo selectVisitData(String visitDataCode)
        {
            log.Debug(@"=================START selectVisitData=================");
            log.Debug(@"visitDataCode = " + visitDataCode);
            VisitDataInfo obj = new VisitDataInfo();

            StringBuilder sql_select = new StringBuilder();
            sql_select.Append(@"
								SELECT	VisitData.visitDataCode,
										VisitData.regDate,
										VisitData.elecApproveCode AS elecApproveCode,
										VisitData.userFile1 AS userFile1,
										VisitData.userFile2 AS userFile2,
										VisitData.userFile3 AS userFile3,
										VisitObject.visitObjectCode,
										VisitObject.visitObjectName,
										VisitData.visitObjectContents,
										VisitData.approvalState,
										VisitData.approveTime,
										office.officeCode,
										office.officeName,
										VisitData.officeContents,
										reqUser.upnid AS requestUserCode,
										reqUser.displayName AS requestUserName,
										reqUser.mobilePhoneNumber AS requestUserPhone,
										TITLE_MTB.title_name AS requestTitleUserName,
										DEPART_MTB.dep_name AS reqDepartmentName,
										interviewUser.upnid AS interviewUserCode,
										interviewUser.displayName AS interviewUserName,
										carData.carCode,
										carData.header,
										carData.number,
										carData.codeName AS carCodeName,
										inSecurity.upnid AS inSecurityUserCode,
										inSecurity.displayName AS inSecurityUserName,
										outSecurity.upnid AS outSecurityUserCode,
										outSecurity.displayName AS outSecurityUserName,
                                        VisitData.visitFlag,
                                        VisitData.startDate,
                                        VisitData.endDate
								FROM	VisitData LEFT OUTER JOIN 
										(
											SELECT	CarCategory.codeName,
													CarData.carCode,CarData.header,CarData.number 
											FROM	CarData ,CarCategory 
											WHERE	CarData.carCategoryCode=CarCategory.carCategoryCode
										) AS carData
										ON VisitData.carCode=carData.carCode,
										VisitObject,
										Office, 
										GCM.dbo.UserInfo_MTB AS reqUser,
										GCM.dbo.UserInfo_MTB AS interviewUser,
										GCM.dbo.DEPART_MTB AS DEPART_MTB,
										GCM.dbo.TITLE_MTB AS TITLE_MTB,
										(
										SELECT	VisitData.visitDataCode,
												ut.upnid,
												ut.displayName
										FROM    VisitData LEFT OUTER JOIN GCM.dbo.UserInfo_MTB ut ON VisitData.inSecurityUserCode=ut.upnid
										) inSecurity,
										(
										SELECT	VisitData.visitDataCode,
												ut.upnid,
												ut.displayName
										FROM    VisitData LEFT OUTER JOIN GCM.dbo.UserInfo_MTB ut ON VisitData.outSecurityUserCode=ut.upnid
										) outSecurity
								WHERE	VisitData.visitObjectCode=VisitObject.visitObjectCode
										AND VisitData.officeCode=Office.officeCode
										AND VisitData.requestUserCode=reqUser.UPNID
										AND VisitData.interviewUserCode=interviewUser.UPNID
										AND reqUser.department=DEPART_MTB.dep_code
										AND reqUser.title=TITLE_MTB.title_code
										AND VisitData.visitDataCode=inSecurity.visitDataCode
										AND VisitData.visitDataCode=outSecurity.visitDataCode
										AND reqUser.reg_type=9
										AND interviewUser.reg_type=9 
										AND VisitData.visitDataCode=" + visitDataCode);

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
            {
                if (rdr.Read())
                {
                    obj = bindVisitDataInfo(rdr, obj);
                }
            }

            log.Debug(@"=================END selectVisitData=================");

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
        public List<VisitDataInfo> selectVisitDataList(String keyWord, String key, String searchStartDate, String searchEndDate, String upnid, String approveUserCode, String type)
        {
            log.Debug("=================START selectVisitDataList=================");
            log.Info("start time = " + DateTime.Now);
            log.Debug("keyWord = " + keyWord);
            log.Debug("key = " + key);
            log.Debug("searchStartDate = " + searchStartDate);
            log.Debug("searchEndDate = " + searchEndDate);

            List<VisitDataInfo> list = new List<VisitDataInfo>();

            StringBuilder sql_select = new StringBuilder();
            sql_select.Append(@"
								SELECT	VisitData.visitDataCode,
										VisitData.regDate,
										VisitData.elecApproveCode AS elecApproveCode,
										VisitData.userFile1 AS userFile1,
										VisitData.userFile2 AS userFile2,
										VisitData.userFile3 AS userFile3,
										VisitObject.visitObjectCode,
										VisitObject.visitObjectName,
										VisitData.visitObjectContents,
										VisitData.approvalState,
										VisitData.approveTime,
										office.officeCode,
										office.officeName,
										VisitData.officeContents,
										reqUser.upnid AS requestUserCode,
										reqUser.displayName AS requestUserName,
										reqUser.mobilePhoneNumber AS requestUserPhone,
										TITLE_MTB.title_name AS requestTitleUserName,
										DEPART_MTB.dep_name AS reqDepartmentName,
										interviewUser.upnid AS interviewUserCode,
										interviewUser.displayName AS interviewUserName,
										carData.carCode,
										carData.header,
										carData.number,
										carData.codeName AS carCodeName,
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
										VisitorData.visitorDataCode,
										VisitorData.inTime,
										VisitorData.outTime,
										VisitorData.visitDate,
                                      	Company.companyCode,
										Company.companyName,
										inSecurity.upnid AS inSecurityUserCode,
										inSecurity.displayName AS inSecurityUserName,
										outSecurity.upnid AS outSecurityUserCode,
										outSecurity.displayName AS outSecurityUserName,
                                        VisitData.visitFlag,
                                        VisitData.startDate,
                                        VisitData.endDate,
                                        VisitorData.cardNo,
                                        Visitor.esdFlag,
                                        Visitor.esdDate
								FROM	VisitData LEFT OUTER JOIN 
										(
											SELECT	CarCategory.codeName,
													CarData.carCode,CarData.header,CarData.number 
											FROM	CarData ,CarCategory 
											WHERE	CarData.carCategoryCode=CarCategory.carCategoryCode
										) AS carData
										ON VisitData.carCode=carData.carCode,
										VisitorData,
										Visitor,
										VisitObject,
										Office, 
										GCM.dbo.UserInfo_MTB AS reqUser,
										GCM.dbo.UserInfo_MTB AS interviewUser,
										Company,
										GCM.dbo.DEPART_MTB AS DEPART_MTB,
										GCM.dbo.TITLE_MTB AS TITLE_MTB,
										(
										SELECT	VisitData.visitDataCode,
												ut.upnid,
												ut.displayName
										FROM    VisitData LEFT OUTER JOIN GCM.dbo.UserInfo_MTB ut ON VisitData.inSecurityUserCode=ut.upnid
										) inSecurity,
										(
										SELECT	VisitData.visitDataCode,
												ut.upnid,
												ut.displayName
										FROM    VisitData LEFT OUTER JOIN GCM.dbo.UserInfo_MTB ut ON VisitData.outSecurityUserCode=ut.upnid
										) outSecurity
								WHERE	VisitData.visitObjectCode=VisitObject.visitObjectCode
										AND VisitData.officeCode=Office.officeCode
										AND VisitData.requestUserCode=reqUser.UPNID
										AND VisitData.interviewUserCode=interviewUser.UPNID
										AND VisitData.visitDataCode=VisitorData.visitDataCode
										AND VisitorData.visitorCode=Visitor.visitorCode
										AND Visitor.companyCode=Company.companyCode
										AND reqUser.department=DEPART_MTB.dep_code
										AND reqUser.title=TITLE_MTB.title_code
										AND VisitData.visitDataCode=inSecurity.visitDataCode
										AND VisitData.visitDataCode=outSecurity.visitDataCode
										AND reqUser.reg_type=9
										AND interviewUser.reg_type=9
                                        ");

            if (type=="visitData") // 보안실,관리자화면
            {   
                sql_select.Append(" AND (VisitData.visitFlag=0 OR VisitData.visitFlag=2 OR VisitData.visitFlag=5)");

                // 사용자 화면이 아닐때는 예약일이 오늘인거 까지만 표시
                sql_select.Append(" AND CONVERT(varchar(10),VisitorData.visitDate,126) <= CONVERT(varchar(10),GETDATE(),126) ");
            }
            
            if (!String.IsNullOrEmpty(key))
            {
                sql_select.Append(" AND " + keyWord + " LIKE '%" + key + "%'");
            }

            if (!String.IsNullOrEmpty(searchStartDate) && !String.IsNullOrEmpty(searchEndDate))
            {
				sql_select.Append(" AND VisitorData.visitDate BETWEEN '" + searchStartDate + "' AND '" + searchEndDate + "'");
            }

            if (!String.IsNullOrEmpty(upnid))
            {   // 사용자 화면일때
                sql_select.Append(" AND VisitData.requestUserCode='" + upnid + "'");
            }

            if (!String.IsNullOrEmpty(approveUserCode))
            {
				sql_select.Append(" AND VisitData.approvalUserCode='" + approveUserCode + "'");
            }

            sql_select.Append(" ORDER BY VisitorData.visitDate DESC, VisitData.visitDataCode DESC");
            
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    VisitDataInfo obj = new VisitDataInfo();
                    obj = bindVisitData(rdr, obj);
                    list.Add(obj);
                }
            }

            log.Info("end time = " + DateTime.Now);
            log.Debug("=================END selectVisitData=================");
            return list;
        }

        /// <summary>
        /// longVisitList
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<VisitDataInfo> selectLongVisitDataList(String date, String key, String keyWord)
        {
            log.Debug("=================START selectLongVisitDataList=================");
            log.Info("start time = " + DateTime.Now);
            log.Debug("date = " + date);

            List<VisitDataInfo> list = new List<VisitDataInfo>();

            StringBuilder sql_select = new StringBuilder();
            sql_select.Append(@"
								SELECT	VisitData.visitDataCode,
										VisitData.regDate,
										VisitData.elecApproveCode AS elecApproveCode,
										VisitData.userFile1 AS userFile1,
										VisitData.userFile2 AS userFile2,
										VisitData.userFile3 AS userFile3,
										VisitObject.visitObjectCode,
										VisitObject.visitObjectName,
										VisitData.visitObjectContents,
										VisitData.approvalState,
										VisitData.approveTime,
										office.officeCode,
										office.officeName,
										VisitData.officeContents,
										reqUser.upnid AS requestUserCode,
										reqUser.displayName AS requestUserName,
										reqUser.mobilePhoneNumber AS requestUserPhone,
										TITLE_MTB.title_name AS requestTitleUserName,
										DEPART_MTB.dep_name AS reqDepartmentName,
										interviewUser.upnid AS interviewUserCode,
										interviewUser.displayName AS interviewUserName,
										carData.carCode,
										carData.header,
										carData.number,
										carData.codeName AS carCodeName,
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
										VisitorData.visitorDataCode,
										VisitorData.inTime,
										VisitorData.outTime,
										VisitorData.visitDate,
										Company.companyCode,
										Company.companyName,
										inSecurity.upnid AS inSecurityUserCode,
										inSecurity.displayName AS inSecurityUserName,
										outSecurity.upnid AS outSecurityUserCode,
										outSecurity.displayName AS outSecurityUserName,
                                        VisitData.visitFlag,
                                        VisitData.startDate,
                                        VisitData.endDate,
                                        VisitorData.cardNo,
                                        Visitor.esdFlag,
                                        Visitor.esdDate
								FROM	VisitData LEFT OUTER JOIN 
										(
											SELECT	CarCategory.codeName,
													CarData.carCode,CarData.header,CarData.number 
											FROM	CarData ,CarCategory 
											WHERE	CarData.carCategoryCode=CarCategory.carCategoryCode
										) AS carData
										ON VisitData.carCode=carData.carCode,
										VisitorData,
										Visitor,
										VisitObject,
										Office, 
										GCM.dbo.UserInfo_MTB AS reqUser,
										GCM.dbo.UserInfo_MTB AS interviewUser,
										Company,
										GCM.dbo.DEPART_MTB AS DEPART_MTB,
										GCM.dbo.TITLE_MTB AS TITLE_MTB,
										(
										SELECT	VisitData.visitDataCode,
												ut.upnid,
												ut.displayName
										FROM    VisitData LEFT OUTER JOIN GCM.dbo.UserInfo_MTB ut ON VisitData.inSecurityUserCode=ut.upnid
										) inSecurity,
										(
										SELECT	VisitData.visitDataCode,
												ut.upnid,
												ut.displayName
										FROM    VisitData LEFT OUTER JOIN GCM.dbo.UserInfo_MTB ut ON VisitData.outSecurityUserCode=ut.upnid
										) outSecurity
								WHERE	VisitData.visitObjectCode=VisitObject.visitObjectCode
										AND VisitData.officeCode=Office.officeCode
										AND VisitData.requestUserCode=reqUser.UPNID
										AND VisitData.interviewUserCode=interviewUser.UPNID
										AND VisitData.visitDataCode=VisitorData.visitDataCode
										AND VisitorData.visitorCode=Visitor.visitorCode
										AND Visitor.companyCode=Company.companyCode
										AND reqUser.department=DEPART_MTB.dep_code
										AND reqUser.title=TITLE_MTB.title_code
										AND VisitData.visitDataCode=inSecurity.visitDataCode
										AND VisitData.visitDataCode=outSecurity.visitDataCode
										AND reqUser.reg_type=9
										AND interviewUser.reg_type=9
                                        AND VisitData.visitFlag=1
                                        AND VisitData.approvalState=2
                                        AND CONVERT(VARCHAR(20),GETDATE(),112) BETWEEN CONVERT(VARCHAR(20),VisitData.startDate,112) AND CONVERT(VARCHAR(20),VisitData.endDate,112)");



            if (!String.IsNullOrEmpty(key))
            {
                sql_select.Append(" AND " + keyWord + " LIKE '%" + key + "%'");
            }

            //if (!String.IsNullOrEmpty(date))
            //{
            //    sql_select.Append(" AND VisitorData.visitDate BETWEEN '" + searchStartDate + "' AND '" + searchEndDate + "'");
            //}


            sql_select.Append(" ORDER BY VisitData.visitDataCode DESC");
           
            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    VisitDataInfo obj = new VisitDataInfo();
                    obj = bindVisitData(rdr, obj);
                    list.Add(obj);
                }
            }

            log.Info("end time = " + DateTime.Now);
            log.Debug("=================END selectVisitData=================");
            return list;
        }

        /// <summary>
        /// checkLongVisitDataCode
        /// </summary>
        /// <param name="visitDataCode"></param>
        /// <returns></returns>
        public VisitDataInfo checkLongVisitDataCode(String visitDataCode, String code)
        {
            log.Debug(@"=================START checkLongVisitDataCode=================");
            log.Debug(@"visitDataCode = " + visitDataCode);

            VisitDataInfo obj = new VisitDataInfo();

            StringBuilder sql_select = new StringBuilder();
            sql_select.Append(@"
								SELECT	VisitData.visitDataCode,
										VisitData.regDate,
										VisitData.elecApproveCode AS elecApproveCode,
										VisitData.userFile1 AS userFile1,
										VisitData.userFile2 AS userFile2,
										VisitData.userFile3 AS userFile3,
										VisitObject.visitObjectCode,
										VisitObject.visitObjectName,
										VisitData.visitObjectContents,
										VisitData.approvalState,
										VisitData.approveTime,
										office.officeCode,
										office.officeName,
										VisitData.officeContents,
										reqUser.upnid AS requestUserCode,
										reqUser.displayName AS requestUserName,
										reqUser.mobilePhoneNumber AS requestUserPhone,
										TITLE_MTB.title_name AS requestTitleUserName,
										DEPART_MTB.dep_name AS reqDepartmentName,
										interviewUser.upnid AS interviewUserCode,
										interviewUser.displayName AS interviewUserName,
										carData.carCode,
										carData.header,
										carData.number,
										carData.codeName AS carCodeName,
										inSecurity.upnid AS inSecurityUserCode,
										inSecurity.displayName AS inSecurityUserName,
										outSecurity.upnid AS outSecurityUserCode,
										outSecurity.displayName AS outSecurityUserName,
                                        VisitData.visitFlag,
                                        VisitData.startDate,
                                        VisitData.endDate
								FROM	VisitData LEFT OUTER JOIN 
										(
											SELECT	CarCategory.codeName,
													CarData.carCode,CarData.header,CarData.number 
											FROM	CarData ,CarCategory 
											WHERE	CarData.carCategoryCode=CarCategory.carCategoryCode
										) AS carData
										ON VisitData.carCode=carData.carCode,
										VisitObject,
										Office, 
										GCM.dbo.UserInfo_MTB AS reqUser,
										GCM.dbo.UserInfo_MTB AS interviewUser,
										GCM.dbo.DEPART_MTB AS DEPART_MTB,
										GCM.dbo.TITLE_MTB AS TITLE_MTB,
										(
										SELECT	VisitData.visitDataCode,
												ut.upnid,
												ut.displayName
										FROM    VisitData LEFT OUTER JOIN GCM.dbo.UserInfo_MTB ut ON VisitData.inSecurityUserCode=ut.upnid
										) inSecurity,
										(
										SELECT	VisitData.visitDataCode,
												ut.upnid,
												ut.displayName
										FROM    VisitData LEFT OUTER JOIN GCM.dbo.UserInfo_MTB ut ON VisitData.outSecurityUserCode=ut.upnid
										) outSecurity
								WHERE	VisitData.visitObjectCode=VisitObject.visitObjectCode
										AND VisitData.officeCode=Office.officeCode
										AND VisitData.requestUserCode=reqUser.UPNID
										AND VisitData.interviewUserCode=interviewUser.UPNID
										AND reqUser.department=DEPART_MTB.dep_code
										AND reqUser.title=TITLE_MTB.title_code
										AND VisitData.visitDataCode=inSecurity.visitDataCode
										AND VisitData.visitDataCode=outSecurity.visitDataCode
										AND reqUser.reg_type=9
										AND interviewUser.reg_type=9");

            //내방정보 longVisitDataCode 오늘날짜 있는지 확인. 
            if (code == "0")
            {
                sql_select.Append(@" AND VisitData.longVisitDataCode=" + visitDataCode + @"
                                     AND CONVERT(VARCHAR(20),VisitData.regDate,112) = CONVERT(VARCHAR(20),GETDATE(),112)");
            }

            //오늘날짜 내방정보가 없을때 때 visitDataInfo 가져옴.
            else
            {
                sql_select.Append(@" AND VisitData.visitDataCode=" + visitDataCode);
            }

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
            {
                if (rdr.Read())
                {
                    obj = bindVisitDataInfo(rdr, obj);
                }
            }

            log.Debug(@"=================END selectVisitData=================");

            return obj;
        }


        /// <summary>
        /// total
        /// </summary>
        /// <param name="keyWord"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public int selectVisitDataTotal(String keyWord, String key, String searchStartDate, String searchEndDate, String upnid, String approveUserCode)
        {
            log.Debug("=================START selectVisitDataTotal=================");
            log.Debug("keyWord = " + keyWord);
            log.Debug("key = " + key);

            Object totalCount = null;
            StringBuilder sql_select_total = new StringBuilder();
            sql_select_total.Append(@"
										SELECT	COUNT(*)
										FROM	VisitData a LEFT OUTER JOIN 
												(
													SELECT	CarCategory.codeName,CarData.carCode,CarData.header,CarData.number 
													FROM	CarData ,CarCategory 
													WHERE	CarData.carCategoryCode=CarCategory.carCategoryCode
												) b
												ON a.carCode=b.carCode,
												(
													SELECT	TOP 1
															VisitorData.visitDataCode,
															Visitor.visitorCode,
															visitorName,
															Visitor.visitorPhone1,
															Visitor.visitorPhone2,
															Visitor.visitorPhone3,
															Visitor.visitorRegNumber1,
															Visitor.visitorRegNumber2,
                                                            Visitor.visitorPassportNumber,
															Visitor.companyCode,
															Visitor.reject,
															Visitor.rejectContent,
															Visitor.regDate,
															Company.companyName
													FROM	Visitor LEFT OUTER JOIN Company ON Visitor.companyCode=Company.companyCode,VisitorData
													WHERE	Visitor.visitorCode=VisitorData.visitorCode
												) c,
												VisitObject d,
												Office e , 
												GCM.dbo.UserInfo_MTB f,
												GCM.dbo.UserInfo_MTB g,
												GCM.dbo.UserInfo_MTB h,
												GCM.dbo.TITLE_MTB g
										WHERE	a.visitObjectCode=d.visitObjectCode
												AND a.officeCode=e.officeCode
												AND a.requestUserCode=f.UPNID
												AND a.interviewUserCode=g.UPNID
												AND a.approvalUserCode=h.UPNID
												AND a.visitDataCode=c.visitDataCode
												AND f.title=g.title_code");
            if (!String.IsNullOrEmpty(key))
            {
                sql_select_total.Append(" WHERE " + keyWord + " LIKE '%" + key + "%'");
            }

            if (!String.IsNullOrEmpty(searchStartDate) && !String.IsNullOrEmpty(searchEndDate))
            {
                sql_select_total.Append(" AND c.startDate BETWEEN '" + searchStartDate + "' AND '" + searchEndDate + "'");
            }

            if (!String.IsNullOrEmpty(upnid))
            {
                sql_select_total.Append(" AND a.requestUserCode='" + upnid + "'");
            }

            if (!String.IsNullOrEmpty(approveUserCode))
            {
                sql_select_total.Append(" AND a.approvalUserCode='" + approveUserCode + "'");
            }


            totalCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select_total.ToString(), null);
            if (totalCount == null)
            {
                return Convert.ToInt32("0");
            }
            else
            {
                return Convert.ToInt32(totalCount);
            }

            log.Debug("=================END selectVisitDataTotal=================");
        }

        /// <summary>
        /// update
        /// </summary>
        /// <param name="visitData"></param>
        /// <returns></returns>
        public int updateVisitData(VisitDataInfo visitData)
        {
            log.Debug("=================START updateVisitData=================");
            log.Debug("visitData = " + visitData.ToString());

            StringBuilder sql_update = new StringBuilder();

			sql_update.Append("UPDATE VisitData SET ");

			sql_update.Append(@"		
										interviewUserCode='" + visitData.InterviewEmployeeInfo.Upnid + @"',
										visitObjectCode='" + visitData.VisitObjectInfo.VisitObjectCode + @"',
										visitObjectContents=N'" + visitData.VisitObjectContents + @"',
										officeCode='" + visitData.OfficeInfo.OfficeCode + @"',
										officeContents=N'" + visitData.OfficeContents + @"',
										carCode='" + visitData.CarDataInfo.CarCode + @"',
										approvalState=N'" + visitData.ApprovalState + @"',
                                        visitFlag='" + visitData.VisitFlag + @"',
										userFile1='" + visitData.UserFile1 + @"',
										userFile2='" + visitData.UserFile2 + @"',
										userFile3='" + visitData.UserFile3 + @"',
                                        startDate='" + visitData.StartDate + @"',
                                        endDate='" + visitData.EndDate + @"'
								WHERE	visitDataCode=" + visitData.VisitDataCode);

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

            log.Debug("=================END updateVisitData=================");

            return result;
        }

        public int updateVisitData(Int32 visitDataCode, Int32 flag)
        {
            log.Debug("=================START updateVisitData=================");
            log.Debug("visitDataCode = " + visitDataCode);
            log.Debug("visitFlag = " + flag);

            StringBuilder sql_update = new StringBuilder();

            sql_update.Append("UPDATE VisitData SET ");

            sql_update.Append(@"		

										visitFlag=" + flag + @"
								WHERE	visitDataCode=" + visitDataCode);

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

            log.Debug("=================END updateVisitData=================");

            return result;
        }

        /// <summary>
        /// insert
        /// </summary>
        /// <param name="visitData"></param>
        /// <returns></returns>
        public int insertVisitData(VisitDataInfo visitData)
        {
            log.Debug("=================START insertVisitData=================");
            log.Debug("visitData = " + visitData.ToString());

            StringBuilder sql_insert = new StringBuilder();

            sql_insert.Append(@"
								INSERT INTO VisitData
							   ([regDate]
							   ,[requestUserCode]
							   ,[interviewUserCode]
							   ,[visitObjectCode]
							   ,[visitObjectContents]
							   ,[officeCode]
							   ,[officeContents]
							   ,[carCode]
							   ,[approvalState]
							   ,[elecApproveCode]
							   ,[userFile1]
							   ,[userFile2]
							   ,[userFile3]
                               ,[visitFlag]
                               ,[startDate]
                               ,[endDate]
                               ,[longVisitDataCode])
						 VALUES
							   (
                               GETDATE()
							   ,N'" + visitData.ReqEmployeeInfo.Upnid+ @"'
							   ,N'" + visitData.InterviewEmployeeInfo.Upnid + @"'
							   ,N'" + visitData.VisitObjectInfo.VisitObjectCode + @"'
							   ,N'" + StringUtil.ConvertDatabaseString(visitData.VisitObjectContents) + @"'
							   ,N'" + visitData.OfficeInfo.OfficeCode + @"'
							   ,N'" + StringUtil.ConvertDatabaseString(visitData.OfficeContents) + @"'
							   ,N'" + visitData.CarDataInfo.CarCode + @"'"
                               //,0
                               //,'" + visitData.ElecApproveCode + @"'
                               //,'" + visitData.UserFile1 + @"'
                               //,'" + visitData.UserFile2 + @"'
                               //,'" + visitData.UserFile3 + @"'
                               //,'" + visitData.VisitFlag + @"'
                               //,'" + visitData.StartDate + @"'
                               //,'" + visitData.EndDate + @"')"
							);

            if (visitData.ApprovalState == 2)
            {
                sql_insert.Append(",2");
            }
            else
            {
                sql_insert.Append(",0");
            }
            sql_insert.Append(@",N'" + visitData.ElecApproveCode + @"'
							   ,N'" + visitData.UserFile1 + @"'
							   ,N'" + visitData.UserFile2 + @"'
							   ,N'" + visitData.UserFile3 + @"'
                               ,N'" + visitData.VisitFlag + @"'
                               ,N'" + visitData.StartDate + @"'
                               ,N'" + visitData.EndDate + @"'
                               ,N'" + visitData.LongVisitDataCode + @"')"
                              );

			int result=0;
			try
			{
				result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_insert.ToString(), null);
			}
			catch
			{
				log.Debug("오류 발생!!!!!!!!!");
				log.Debug("sql start ");
				log.Debug(sql_insert);
				log.Debug("sql end ");
			}

            log.Debug("=================END insertVisitData=================");
            return result;
        }

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="visitData"></param>
        /// <returns></returns>
        public int deleteVisitData(VisitDataInfo visitData)
        {
            log.Debug("=================START deleteVisitData=================");
            log.Debug("visitData = " + visitData.ToString());

            StringBuilder sql_delete = new StringBuilder();
            sql_delete.Append("DELETE FROM VisitData WHERE visitDataCode=" + visitData.VisitDataCode);

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_delete.ToString(), null);

            log.Debug("=================END deleteVisitData=================");

            return result;
        }

        /// <summary>    
        /// 최종 입려값
        /// </summary>
        /// <returns></returns>
        public int selectMaxCode()
        {
            log.Debug("=================START selectMaxCode=================");

            Object maxID = null;
            StringBuilder sql_select_max = new StringBuilder();
            sql_select_max.Append(@"SELECT MAX(visitDataCode) FROM VisitData" );

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
        /// 입문
        /// </summary>
        /// <param name="visitDatacode"></param>
        /// <returns></returns>
        //1212
        public int updateInTime(String visitDataCode)
        {
            log.Debug("=================START updateInTime=================");
            log.Debug("visitDataCode = " + visitDataCode);

            StringBuilder sql_update = new StringBuilder();

            sql_update.Append("UPDATE VisitData SET inTime=GETDATE() WHERE visitDataCode=" + visitDataCode);

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

            log.Debug("=================END updateInTime=================");

            return result;
        }

        /// <summary>
        /// 출문
        /// </summary>
        /// <param name="visitDatacode"></param>
        /// <returns></returns>
        public int updateOutTime(String visitDataCode)
        {
            log.Debug("=================START updateOutTime=================");
            log.Debug("visitDataCode = " + visitDataCode);

            StringBuilder sql_update = new StringBuilder();

            sql_update.Append("UPDATE VisitData SET outTime=GETDATE() WHERE visitDataCode=" + visitDataCode);

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

            log.Debug("=================END updateOutTime=================");

            return result;
        }

        /// <summary>
        /// 결재
        /// </summary>
        /// <param name="visitDateCode"></param>
        /// <param name="approveStat"></param>
        /// <returns></returns>
        public int updateApprove(String visitDataCode, String approveState, String approveContents)
        {
            log.Debug("=================START updateApprove=================");
            log.Debug("visitDataCode = " + visitDataCode);
            log.Debug("approveState = " + approveState);
            log.Debug("approveContents = " + approveContents);

            StringBuilder sql_update = new StringBuilder();

            if (approveState.Equals("1"))
            {
                sql_update.Append("UPDATE VisitData SET approvalState=1,approveTime=GETDATE() WHERE visitDataCode=" + visitDataCode);
            }
            else
            {
                sql_update.Append("UPDATE VisitData SET approvalState=2 WHERE visitDataCode=" + visitDataCode);
                //sql_update.Append("UPDATE VisitData SET approvalState=2,approveContents='" + StringUtil.ConvertDatabaseString(approveContents) + "' WHERE visitDataCode=" + visitDataCode);
            }

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

            log.Debug("=================END updateApprove=================");

            return result;
        }

		/// <summary>
		/// 전자결재 코드를 가지고 update 하기
		/// </summary>
		/// <param name="elecApproveCode"></param>
		/// <param name="approveState"></param>
		/// <returns></returns>
		public int UpdateApprove(String elecApproveCode, String approveState)
		{
			log.Debug("=================START UpdateApprove=================");
			log.Debug("elecApproveCode = " + elecApproveCode);
			log.Debug("approveState = " + approveState);

			StringBuilder sql_update = new StringBuilder();
			sql_update.Append("UPDATE VisitData SET approvalState=N'"+approveState+"',approveTime=GETDATE() WHERE elecApproveCode=N'" + elecApproveCode + "'");

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

			log.Debug("=================END UpdateApprove=================");

			return result;
		}

		/// <summary>
		/// 사용자 업로드 파일 삭제
		/// </summary>
		/// <param name="visitDataCode"></param>
		/// <param name="fileNumber"></param>
		/// <returns></returns>
		public int DeleteUserFile(String visitDataCode, String fileNumber)
		{
			log.Debug("=================START DeleteUserFile=================");
			log.Debug("visitDataCode = " + visitDataCode);
			log.Debug("fileNumber = " + fileNumber);

			StringBuilder sql = new StringBuilder();
			sql.Append("UPDATE VisitData SET ");

			if (fileNumber.Equals("1")) sql.Append(" userFile1='' ");
			if (fileNumber.Equals("2")) sql.Append(" userFile2='' ");
			if (fileNumber.Equals("3")) sql.Append(" userFile3='' ");

			sql.Append(" WHERE visitDataCode='" + visitDataCode + "'");

			int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql.ToString(), null);

			log.Debug("=================END DeleteUserFile=================");

			return result;
		}

        /// <summary>
        /// bind
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private VisitDataInfo bindVisitData(SqlDataReader rdr, VisitDataInfo obj)
        {
			obj.ReqEmployeeInfo = new EmployeeInfo(); // 신청자
			obj.InterviewEmployeeInfo = new EmployeeInfo(); // 접견자
			obj.CarDataInfo = new CarDataInfo(); // 차량
			obj.OfficeInfo = new OfficeInfo(); // 내방 장소
			obj.VisitorDataInfoList = new List<VisitorDataInfo>(); // 내방객 목록
			obj.VisitObjectInfo = new VisitObjectInfo(); // 내방 목적
			obj.InSecurityEmployeeInfo = new EmployeeInfo(); // 입문 처리자 직원 정보
			obj.OutSecurityEmployeeInfo = new EmployeeInfo(); // 출문 처리 직원정보

			obj.VisitorDataInfoList.Add(new VisitorDataInfo());
			obj.VisitorDataInfoList[0].VisitorInfo = new VisitorInfo(); // 내방객 정보
			obj.VisitorDataInfoList[0].CompanyInfo = new CompanyInfo(); // 내방객 회사

			// 내방 정보 
			obj.VisitDataCode = rdr.GetInt32(0);
			obj.RegDate = rdr.GetDateTime(1);
          
			if (rdr.IsDBNull(2)) obj.ElecApproveCode = null;
			else obj.ElecApproveCode = rdr.GetString(2);

			if (rdr.IsDBNull(3)) obj.UserFile1 = null;
			else obj.UserFile1 = rdr.GetString(3);

			if (rdr.IsDBNull(4)) obj.UserFile2 = null;
			else obj.UserFile2 = rdr.GetString(4);

			if (rdr.IsDBNull(5)) obj.UserFile3 = null;
			else obj.UserFile3 = rdr.GetString(5);

			// 내방 목적
			obj.VisitObjectInfo.VisitObjectCode = rdr.GetInt32(6);
			obj.VisitObjectInfo.VisitObjectName = rdr.GetString(7);
			obj.VisitObjectContents = rdr.GetString(8);
			obj.ApprovalState = rdr.GetInt32(9);

			if (rdr.IsDBNull(10)) obj.ApproveTime = new DateTime();
			else obj.ApproveTime = rdr.GetDateTime(10);

			// 내방 장소
			obj.OfficeInfo.OfficeCode = rdr.GetInt32(11);
			obj.OfficeInfo.OfficeName = rdr.GetString(12);
			obj.OfficeContents = rdr.GetString(13);

			// 신청자
			obj.ReqEmployeeInfo.Upnid = rdr.GetString(14);
			obj.ReqEmployeeInfo.DisplayName = rdr.GetString(15);

            if (rdr.IsDBNull(16)) obj.ReqEmployeeInfo.MobilePhoneNumber = null;
            else obj.ReqEmployeeInfo.MobilePhoneNumber = rdr.GetString(16);

			obj.ReqEmployeeInfo.Title_name = rdr.GetString(17);
			obj.ReqEmployeeInfo.Dep_name = rdr.GetString(18);
			
			// 접견자
			obj.InterviewEmployeeInfo.Upnid = rdr.GetString(19);
			obj.InterviewEmployeeInfo.DisplayName = rdr.GetString(20);

			// 차량정보
			if (rdr.IsDBNull(21)) obj.CarDataInfo.CarCode = 0;
			else obj.CarDataInfo.CarCode = rdr.GetInt32(21);

			if (rdr.IsDBNull(22)) obj.CarDataInfo.Header = null;
            else obj.CarDataInfo.Header = rdr.GetString(22);

			if (rdr.IsDBNull(23)) obj.CarDataInfo.Number = null;
			else obj.CarDataInfo.Number = rdr.GetString(23);

			if (rdr.IsDBNull(24)) obj.CarDataInfo.CodeName = null;
			else obj.CarDataInfo.CodeName = rdr.GetString(24);
			
			// 내방객 정보
			obj.VisitorDataInfoList[0].VisitorInfo.VisitorCode = rdr.GetInt32(25);
			obj.VisitorDataInfoList[0].VisitorInfo.VisitorName = rdr.GetString(26);
			obj.VisitorDataInfoList[0].VisitorInfo.VisitorPhone1 = rdr.GetString(27);
			obj.VisitorDataInfoList[0].VisitorInfo.VisitorPhone2 = rdr.GetString(28);
			obj.VisitorDataInfoList[0].VisitorInfo.VisitorPhone3 = rdr.GetString(29);
			obj.VisitorDataInfoList[0].VisitorInfo.VisitorRegNumber1 = rdr.GetString(30);
			obj.VisitorDataInfoList[0].VisitorInfo.VisitorRegNumber2 = rdr.GetString(31);
            if (rdr.IsDBNull(32)) obj.VisitorDataInfoList[0].VisitorInfo.VisitorPassportNumber = null;
            else obj.VisitorDataInfoList[0].VisitorInfo.VisitorPassportNumber = rdr.GetString(32);
			obj.VisitorDataInfoList[0].VisitorInfo.Reject = rdr.GetByte(33);

			if (rdr.IsDBNull(34)) obj.VisitorDataInfoList[0].VisitorInfo.RejectContent = null;
			else obj.VisitorDataInfoList[0].VisitorInfo.RejectContent = rdr.GetString(34);

			obj.VisitorDataInfoList[0].VisitorDataCode = rdr.GetInt32(35);

			if (rdr.IsDBNull(36)) obj.VisitorDataInfoList[0].InTime = "-";
			else obj.VisitorDataInfoList[0].InTime = HanaMicron.COMS.Utility.DateUtility.getDateFormatColon(rdr.GetDateTime(36));

            if (rdr.IsDBNull(37)) obj.VisitorDataInfoList[0].OutTime = "-";
            else obj.VisitorDataInfoList[0].OutTime = HanaMicron.COMS.Utility.DateUtility.getDateFormatColon(rdr.GetDateTime(37));
            //else obj.VisitorDataInfoList[0].OutTime = rdr.GetDateTime(37).ToString("HH시 mm분 ss초");

			if (rdr.IsDBNull(38)) obj.VisitorDataInfoList[0].VisitDate = "-";
			else obj.VisitorDataInfoList[0].VisitDate = rdr.GetDateTime(38).ToString("yyyy.MM.dd");

			// 내방객 회사 정보
			obj.VisitorDataInfoList[0].CompanyInfo.CompanyCode = rdr.GetInt32(39);
			obj.VisitorDataInfoList[0].CompanyInfo.CompanyName = rdr.GetString(40);

			// 입문 처리자 직원 정보
			if (rdr.IsDBNull(41)) obj.InSecurityEmployeeInfo.Upnid = null;
			else obj.InSecurityEmployeeInfo.Upnid = rdr.GetString(41);

			if (rdr.IsDBNull(42)) obj.InSecurityEmployeeInfo.DisplayName = null;
			else obj.InSecurityEmployeeInfo.DisplayName = rdr.GetString(42);

			// 출문 처리자 직원 정보
			if (rdr.IsDBNull(43)) obj.OutSecurityEmployeeInfo.Upnid = null;
			else obj.OutSecurityEmployeeInfo.Upnid = rdr.GetString(43);

			if (rdr.IsDBNull(44)) obj.OutSecurityEmployeeInfo.DisplayName = null;
			else obj.OutSecurityEmployeeInfo.DisplayName = rdr.GetString(44);

            // 장기 내방 정보
            if (rdr.IsDBNull(45)) obj.VisitFlag = 0;
            else obj.VisitFlag = rdr.GetInt32(45); ;

            if (rdr.IsDBNull(46)) obj.StartDate = null;
            else obj.StartDate = rdr.GetDateTime(46).ToString();

            if (rdr.IsDBNull(47)) obj.EndDate = null;
            else obj.EndDate = rdr.GetDateTime(47).ToString();

            if (rdr.IsDBNull(48)) obj.CardNo = null;
            else obj.CardNo = rdr.GetString(48);

            obj.VisitorDataInfoList[0].VisitorInfo.EsdFlag = rdr.GetString(49);

            if (rdr.IsDBNull(50)) obj.VisitorDataInfoList[0].VisitorInfo.EsdDate = new DateTime();
            else obj.VisitorDataInfoList[0].VisitorInfo.EsdDate = rdr.GetDateTime(50);

            return obj;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rdr"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		private VisitDataInfo bindVisitDataInfo(SqlDataReader rdr, VisitDataInfo obj)
		{
			obj.ReqEmployeeInfo = new EmployeeInfo(); // 신청자
			obj.InterviewEmployeeInfo = new EmployeeInfo(); // 접견자
			obj.CarDataInfo = new CarDataInfo(); // 차량
			obj.OfficeInfo = new OfficeInfo(); // 내방 장소
			obj.VisitorDataInfoList = new List<VisitorDataInfo>(); // 내방객 목록
			obj.VisitObjectInfo = new VisitObjectInfo(); // 내방 목적
			obj.InSecurityEmployeeInfo = new EmployeeInfo(); // 입문 처리자 직원 정보
			obj.OutSecurityEmployeeInfo = new EmployeeInfo(); // 출문 처리 직원정보

			obj.VisitorDataInfoList.Add(new VisitorDataInfo());
			obj.VisitorDataInfoList[0].VisitorInfo = new VisitorInfo(); // 내방객 정보
			obj.VisitorDataInfoList[0].CompanyInfo = new CompanyInfo(); // 내방객 회사

			// 내방 정보 
			obj.VisitDataCode = rdr.GetInt32(0);
			obj.RegDate = rdr.GetDateTime(1);

			if (rdr.IsDBNull(2)) obj.ElecApproveCode = null;
			else obj.ElecApproveCode = rdr.GetString(2);

			if (rdr.IsDBNull(3)) obj.UserFile1 = null;
			else obj.UserFile1 = rdr.GetString(3);

			if (rdr.IsDBNull(4)) obj.UserFile2 = null;
			else obj.UserFile2 = rdr.GetString(4);

			if (rdr.IsDBNull(5)) obj.UserFile3 = null;
			else obj.UserFile3 = rdr.GetString(5);

			// 내방 목적
			obj.VisitObjectInfo.VisitObjectCode = rdr.GetInt32(6);
			obj.VisitObjectInfo.VisitObjectName = rdr.GetString(7);
			obj.VisitObjectContents = rdr.GetString(8);
			obj.ApprovalState = rdr.GetInt32(9);

			if (rdr.IsDBNull(10)) obj.ApproveTime = new DateTime();
			else obj.ApproveTime = rdr.GetDateTime(10);

			// 내방 장소
			obj.OfficeInfo.OfficeCode = rdr.GetInt32(11);
			obj.OfficeInfo.OfficeName = rdr.GetString(12);
			obj.OfficeContents = rdr.GetString(13);

			// 신청자
			obj.ReqEmployeeInfo.Upnid = rdr.GetString(14);
			obj.ReqEmployeeInfo.DisplayName = rdr.GetString(15);

            if (rdr.IsDBNull(16)) obj.ReqEmployeeInfo.MobilePhoneNumber = null;
			else obj.ReqEmployeeInfo.MobilePhoneNumber = rdr.GetString(16);

			obj.ReqEmployeeInfo.Title_name = rdr.GetString(17);
			obj.ReqEmployeeInfo.Dep_name = rdr.GetString(18);

			// 접견자
			obj.InterviewEmployeeInfo.Upnid = rdr.GetString(19);
			obj.InterviewEmployeeInfo.DisplayName = rdr.GetString(20);

			// 차량정보
			if (rdr.IsDBNull(21)) obj.CarDataInfo.CarCode = 0;
			else obj.CarDataInfo.CarCode = rdr.GetInt32(21);

			if (rdr.IsDBNull(22)) obj.CarDataInfo.Header = null;
            else obj.CarDataInfo.Header = rdr.GetString(22);

			if (rdr.IsDBNull(23)) obj.CarDataInfo.Number = null;
			else obj.CarDataInfo.Number = rdr.GetString(23);

			if (rdr.IsDBNull(24)) obj.CarDataInfo.CodeName = null;
			else obj.CarDataInfo.CodeName = rdr.GetString(24);

			// 입문 처리자 직원 정보
			if (rdr.IsDBNull(25)) obj.InSecurityEmployeeInfo.Upnid = null;
			else obj.InSecurityEmployeeInfo.Upnid = rdr.GetString(25);

			if (rdr.IsDBNull(26)) obj.InSecurityEmployeeInfo.DisplayName = null;
			else obj.InSecurityEmployeeInfo.DisplayName = rdr.GetString(26);

			// 출문 처리자 직원 정보
			if (rdr.IsDBNull(27)) obj.OutSecurityEmployeeInfo.Upnid = null;
			else obj.OutSecurityEmployeeInfo.Upnid = rdr.GetString(27);

			if (rdr.IsDBNull(28)) obj.OutSecurityEmployeeInfo.DisplayName = null;
			else obj.OutSecurityEmployeeInfo.DisplayName = rdr.GetString(28);

            // 장기 내방 정보
            if (rdr.IsDBNull(29)) obj.VisitFlag = 0;
            else obj.VisitFlag = rdr.GetInt32(29);

            if (rdr.IsDBNull(30)) obj.StartDate = null;
            else obj.StartDate = rdr.GetDateTime(30).ToString();

            if (rdr.IsDBNull(31)) obj.EndDate = null;
            else obj.EndDate = rdr.GetDateTime(31).ToString();


			return obj;
		}

        #endregion

    }
}
