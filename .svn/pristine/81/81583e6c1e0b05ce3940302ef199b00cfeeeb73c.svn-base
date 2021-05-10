using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Model;
using HanaMicron.COMS.Utility;
using System.IO;
using System.Configuration;

/// Bisiness Logic Layer 
namespace HanaMicron.COMS.BLL
{
	/// <summary>
	/// 내방 BLL
	/// </summary>
	public class VisitData
	{
		private static readonly IVisitData dal = HanaMicron.COMS.DALFactory.DataAccess.CreateVisitData();

		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(VisitData));

		/// <summary>
		/// 
		/// </summary>
		public VisitData()
		{
			//log4net.Config.DOMConfigurator.Configure();
		}

		public VisitDataInfo selectVisitData(String visitDataCode)
		{
			return dal.selectVisitData(visitDataCode);
		}

		public List<VisitDataInfo> selectVisitDataList(String keyWord, String key, String searchStartDate, String searchEndDate,String upnid,String approveUserCode,String type)
		{
            return dal.selectVisitDataList(keyWord, key, searchStartDate, searchEndDate, upnid, approveUserCode, type);
		}

        public List<VisitDataInfo> selectLongVisitDataList(String date, String key, String keyWord)
        {
            return dal.selectLongVisitDataList(date, key, keyWord);
        }

        public VisitDataInfo checkLongVisitDataCode(String visitDataCode, String code)
        {
            return dal.checkLongVisitDataCode(visitDataCode, code);
        }

		public int selectVisitDataTotal(String keyWord, String key, String searchStartDate, String searchEndDate, String upnid, String approveUserCode)
		{
			return dal.selectVisitDataTotal(keyWord, key,searchStartDate,searchEndDate,upnid,approveUserCode);
		}

		public int updateVisitData(VisitDataInfo visitData)
		{
			return dal.updateVisitData(visitData);
		}

        public int updateVisitData(Int32 visitDataCode, Int32 flag)
        {
            return dal.updateVisitData(visitDataCode, flag);
        }

		public int insertVisitData(VisitDataInfo visitData)
		{
			return dal.insertVisitData(visitData);
		}

		public int deleteVisitData(VisitDataInfo visitData)
		{
			return dal.deleteVisitData(visitData);
		}

		public int selectMaxCode()
		{
            return dal.selectMaxCode();
		}

		public int updateInTime(String visitDataCode)
		{
			return dal.updateInTime(visitDataCode);
		}

		public int updateOutTime(String visitDataCode)
		{
			return dal.updateOutTime(visitDataCode);
		}

		public int updateApprove(String visitDataCode, String approveState, String approveContents)
		{
			return dal.updateApprove(visitDataCode, approveState, approveContents);
		}

		/// <summary>
		/// 전자결재 코드를 가지고 결재 상태 변경하기
		/// </summary>
		/// <param name="elecApproveCode"></param>
		/// <param name="approveState"></param>
		/// <returns></returns>
		public int UpdateApprove(String elecApproveCode, String approveState)
		{
			return dal.UpdateApprove(elecApproveCode, approveState);
		}

		/// <summary>
		/// 사용자 업로드 파일 삭제
		/// </summary>
		/// <param name="visitDataCode"></param>
		/// <param name="fileNumber"></param>
		/// <returns></returns>
		public int DeleteUserFile(String visitDataCode, String fileNumber,String fileName)
		{
			try
			{
				File.Delete(ConfigurationManager.AppSettings["fileUploadPath"] + "\\" + fileName);
			}
			catch (Exception ex)
			{
				log.Debug(@"fileNumber = " + fileNumber);
				log.Debug(@"fileName = " + fileName);
			}
			return dal.DeleteUserFile(visitDataCode, fileNumber);
		}

		/// <summary>
		/// 전자결재 코드 신규 생성 로직 (년월일 6자리 + 난수11자리 + 시분초 6자리 = 23자리)
		/// </summary>
		/// <returns></returns>
		public String GetNewApproveCode()
		{
            //return DateTime.Now.ToString("yyMMdd") + StringUtil.GetRandomNumber(11).ToString() ;
            Random random = new Random();
            return DateTime.Now.ToString("yyMMdd") + StringUtil.GetRandomNumber(random,8).ToString() + DateTime.Now.ToString("HHmmss");
		}

		/// <summary>
		/// 결재 상태 state process (0 : 결재 신청 대기중 , 1 : 결재중 , 2 : 결재 완료)
		/// </summary>
		/// <param name="visitDataInfo"></param>
		/// <returns></returns>
		public String getApproveStringKOR(VisitDataInfo visitDataInfo)
		{
			String approveString="";
			if (visitDataInfo.ApprovalState == 0)
			{
				approveString = "Lưu tạm thời (임시저장)";
			}
			else if (visitDataInfo.ApprovalState == 1)
			{
				approveString = "Đang gửi phê duyệt (결재 상신 중)";
			}
			else if (visitDataInfo.ApprovalState == 2)
			{
				approveString = getComsState(visitDataInfo);
			}
			else if (visitDataInfo.ApprovalState == 3)
			{
				approveString = "Trả lại (반려)";
			}else if (visitDataInfo.ApprovalState==4)
			{
				
			}
			return approveString;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="visitDataInfo"></param>
		/// <returns></returns>
		private String getComsState(VisitDataInfo obj)
		{
			String state = "";
			if (obj.ApprovalState == 2)
			{
				if (obj.VisitorDataInfoList[0].InTime.Equals("-") && obj.VisitorDataInfoList[0].OutTime.Equals("-"))
				{
					state = "Hoàn thành phê duyệt (결재 완료)";
				}
				else
				{
					state = "Ra cổng (출문)";
					if (obj.VisitorDataInfoList[0].OutTime.Equals("-")) state = "Vào cổng (입문)";
					if (obj.VisitorDataInfoList[0].InTime.Equals("-")) state = "Đồng ý (승인)";
					
					
				}
			}

			return state;
		}

		/// <summary>
		/// 전자결재 용 HTML 만들기
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public String MakeElecApproveContents(VisitDataInfo obj)
		{
			StringBuilder str = new StringBuilder();
			str.Append(@"
				<table width='100%' cellpadding='6' cellspacing='1' style='background-color:#CCCCCC'>
				<tr>
					<td colspan='6' class='contents_title' style='background-color:#FFFFFF'>
						<img src='http://house.hmicron.com/COMS/images/basic/icon_02.gif' alt='icon' style='vertical-align:middle'> Thông tin khách thăm (내방 정보)
					</td>
				</tr>
				<tr>
					<td style='background-color:#F5F5F5'>
						Mục đích đến (방문 목적)
					</td>
					<td style='background-color:#FFFFFF'>"+obj.VisitObjectInfo.VisitObjectName+@"</td>
					<td style='background-color:#F5F5F5'>
						Chi tiết mục đích (세부 목적)
					</td>
					<td style='background-color:#FFFFFF'>"+obj.VisitObjectContents+@"</td>
				</tr>
				<tr>
					<td style='background-color:#F5F5F5'>
						Người gặp (접견자)
					</td>
					<td style='background-color:#FFFFFF'>"+obj.InterviewEmployeeInfo.DisplayName+@"</td>
					<td style='background-color:#F5F5F5'>
						Đại điểm gặp (접견장소)
					</td>
					<td style='background-color:#FFFFFF'>" + obj.OfficeInfo.OfficeName + " " + obj.OfficeContents + @"</td>
				</tr>
				<tr>
					<td style='background-color:#F5F5F5'>
						Số xe (차량 번호)
					</td>
					<td style='background-color:#FFFFFF' colspan='3'>" + obj.CarDataInfo.Header + "  " + obj.CarDataInfo.Number + " " + obj.CarDataInfo.CodeName + @"</td>
				</tr>
			");

            // 장기 내방이면 내방기간 표시
            if (obj.VisitFlag == 1)
            {
                str.Append(@"
                            <tr>
                                <td style='background-color:#F5F5F5'>
                                    Thời hạn khách thăm dài hạn (장기내방 기간)
                                </td>
                                <td style='background-color:#FFFFFF' colspan='3'>" + obj.StartDate.Substring(0,10) + " ~ " + obj.EndDate.Substring(0,10) + @"</td>
                            </tr>
                            ");
            }

            str.Append(@"
			            </table>
			            <br />
                        ");

			str.Append(@"
						<table cellspacing='0' cellpadding='4' rules='all' border='1' style='background-color:White;border-color:#3366CC;border-width:1px;border-style:None;width:100%;border-collapse:collapse;'>
						<tr style='color:#CCCCFF;background-color:#003399;'>
							<td align='center' scope='col'>성명</td><td align='center' colspan='2' scope='col'>Ngày, tháng, năm sinh (생년월일)</td>
                            <td align='center' scope='col'>업체명</td><td align='center' colspan='3' scope='col'>Liên lạc (연락처)</td>");

            // 단기 내방이면 또는 Free pass 이면 방문일 표시
            if (obj.VisitFlag == 0 || obj.VisitFlag == 5)
            {
                str.Append(@"<td align='center' scope='col'>Ngày đến (방문일)</td>");
            }

            str.Append("</tr>");


			VisitorData bllVisitorData = new VisitorData();
			List<VisitorDataInfo> list = bllVisitorData.selectVisitorDataList(obj.VisitDataCode.ToString());

			foreach (VisitorDataInfo subObj in list)
			{
				str.Append(@"
					<tr style='color:#003399;background-color:White;'>
						<td align='center'>"+subObj.VisitorInfo.VisitorName+@"</td>");

                if (String.IsNullOrEmpty(subObj.VisitorInfo.VisitorPassportNumber))
                {
                    //str.Append(@"<td align='center' colspan='2'>" + subObj.VisitorInfo.VisitorRegNumber1 + " - " + subObj.VisitorInfo.VisitorRegNumber2.Substring(0, 4) + "***" + @"</td>");
                    str.Append(@"<td align='center' colspan='2'>" + subObj.VisitorInfo.VisitorRegNumber1 + @"</td>");
                }
                else
                {
                    str.Append(@"<td align='center' colspan='2'>" + subObj.VisitorInfo.VisitorPassportNumber + @"</td>");
                }

                str.Append(@"
                        <td align='center'>" + subObj.CompanyInfo.CompanyName + @"</td>
						<td align='center' colspan='3'>" + subObj.VisitorInfo.VisitorPhone1 + "-" + subObj.VisitorInfo.VisitorPhone2 + "-" + subObj.VisitorInfo.VisitorPhone3 + @"</td>");

                // 단기 내방 또는 Free pass 이면 방문일 표시
                if (obj.VisitFlag == 0 || obj.VisitFlag == 5)
                {
                    str.Append(@"<td align='center'>" + subObj.VisitDate + @"</td>");					
                }

                str.Append("</tr>");
			}
			str.Append("</table>");


			return str.ToString();
		}

		/// <summary>
		/// 사업장 이름 찾기
		/// </summary>
		/// <param name="officePlaceCode"></param>
		/// <returns></returns>
		public String GetofficePlaceName(int officePlaceCode)
		{
			String officePlaceName;
			if (officePlaceCode == 1) officePlaceName = "Nơi làm việc 1 (1 사업장)";
            else officePlaceName = "Nơi làm việc 2 (2 사업장)";

			return officePlaceName;
		}

		/// <summary>
		/// Database 에 저장된 파일 정보 중에서 파일 명만을 Return 한다.
		/// </summary>
		/// <param name="fileInfo"></param>
		/// <returns></returns>
		public String GetFileName(String fileInfo)
		{
			Char separator = '|';
			String[] fileNames = fileInfo.Split(separator);

			return fileNames[0];
		}
	}
}
