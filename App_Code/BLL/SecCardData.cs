using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Model;
using HanaMicron.COMS.Utility;


/// Bisiness Logic Layer 
namespace HanaMicron.COMS.BLL
{
	/// <summary>
	/// 보안카드 BLL
	/// </summary>
	public class SecCardData
	{
		private static readonly ISecCardData dal = HanaMicron.COMS.DALFactory.DataAccess.CreateSecCardData();

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(SecCardData));


        /// <summary>
        /// 출입 카드 정보 저장
        /// </summary>
        /// <param name="SecCardDataInfo"></param>
        /// <returns></returns>
        public int insertSecCardData(SecCardDataInfo SecCardDataInfo)
        {
            return dal.insertSecCardData(SecCardDataInfo);
        }

        public int updateSecCardData(SecCardDataInfo SecCardDataInfo)
        {
            return dal.updateSecCardData(SecCardDataInfo);
        }

        public List<SecCardDataInfo> selectSecCardDataList(String keyWord, String key, String searchStartDate, String searchEndDate, String upnid, String approveUserCode, String type)
        {
            return dal.selectSecCardDataList(keyWord, key, searchStartDate, searchEndDate, upnid, approveUserCode, type);
        }

        public SecCardDataInfo selectSecCardData(String secCardDataCode)
        {
            return dal.selectSecCardData(secCardDataCode);
        }

        public int deleteSecCardData(String secCardDataCode)
        {
            return dal.deleteSecCardData(secCardDataCode);
        }

        public int selectMaxCode()
        {
            return dal.selectMaxCode();
        }

        public int updateApprove(String secCardDataCode, String approveState, String approveContents)
        {
            return dal.updateApprove(secCardDataCode, approveState, approveContents);
        }

        /// <summary>
        /// 전자결재 코드 신규 생성 로직 (년월일 6자리 + 난수11자리 + 시분초 6자리 = 23자리)
        /// </summary>
        /// <returns></returns>
        public String GetNewApproveCode()
        {
            return DateTime.Now.ToString("yyMMdd") + StringUtil.GetRandomNumber(11).ToString() + DateTime.Now.ToString("HHmmss");
        }

        /// <summary>
        /// 전자결재 용 HTML 만들기
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// 
        public String MakeElecApproveContents(SecCardDataInfo obj)
        {
            StringBuilder str = new StringBuilder();
            str.Append(@"
				<table width='100%' cellpadding='6' cellspacing='1' style='background-color:#CCCCCC'>
				<tr>
					<td class='contents_title' style='background-color:#FFFFFF'>
						<img src='http://house.hmicron.com/COMS/images/basic/icon_02.gif' alt='icon' style='vertical-align:middle'> [Mẫu đăng ký ra/vào (Card Reader)] (출입(카드리더기) 등록 신청서)
					</td>
				</tr>
				<tr>
					<td style='background-color:#F5F5F5'>
						<strong>Lý do ra/vào (출입 사유)</strong>
					</td>
                </tr>
                <tr>
					<td style='background-color:#FFFFFF'>" + obj.Comment.Replace((char)13,(char)32).Replace("\n","<br>") + @"</td>
				</tr>
				<tr>
					<td style='background-color:#F5F5F5'>
						<strong>Thời gian ra/vào (출입 기간)</strong>
					</td>
                </tr>
                <tr>
					<td style='background-color:#FFFFFF'>" + obj.ReqDateFrom + " ~ " + obj.ReqDateEnd + @"</td>
				</tr>
           	");

            // 신규등록, 변경 구분
            if (obj.Flag == 1)
            {
                str.Append(@"
                            <tr>
					            <td style='background-color:#F5F5F5'><strong>Phân loại: Đăng ký mới (구분: 신규등록)</strong></td>
                            </tr>
                            ");
            }
            else
            {
                str.Append(@"
                            <tr>
					            <td style='background-color:#F5F5F5'><strong>Phân loại: Thay đổi (구분: 변경)</strong></td>
                            </tr>
                            ");
            }

            str.Append(@"
			            </table>
			            <br />
                        ");
            return str.ToString();
        }

        /// <summary>
        /// 결재 상태 state process (0 : 결재 신청 대기중 , 1 : 결재중 , 2 : 결재 완료)
        /// </summary>
        /// <param name="visitDataInfo"></param>
        /// <returns></returns>
        public String getApproveStringKOR(SecCardDataInfo secCardDataInfo)
        {
            String approveString = "";
            if (secCardDataInfo.ApprovalState == 0)
            {
                approveString = "Lưu tạm thời (임시저장)";
            }
            else if (secCardDataInfo.ApprovalState == 1)
            {
                approveString = "Đang gửi phê duyệt (결재 상신 중)";
            }
            else if (secCardDataInfo.ApprovalState == 2)
            {
                approveString = "Hoàn thành phê duyệt (결재 완료)";
            }
            else if (secCardDataInfo.ApprovalState == 3)
            {
                approveString = "Trả lại (반려)";
            }
            else if (secCardDataInfo.ApprovalState == 4)
            {

            }
            return approveString;
        }

    

       
	}
}
