using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Model;

/// Bisiness Logic Layer 
namespace HanaMicron.COMS.BLL
{
	/// <summary>
	/// 반출 BLL
	/// </summary>
	public class TakeOutData
	{
		private static readonly ITakeOutData dal = HanaMicron.COMS.DALFactory.DataAccess.CreateTakeOutData();

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(TakeOutData));

		/// <summary>
		/// 반출 상세
		/// </summary>
		/// <param name="visitDataCode"></param>
		/// <returns></returns>
		public TakeOutDataInfo selectTakeOutData(String takeOutDataCode)
		{
			return dal.selectTakeOutData(takeOutDataCode);
		}

		/// <summary>
		/// 반출 정보 목록 - 보안실,신청자,결재자
		/// </summary>
		/// <param name="keyWord"></param>
		/// <param name="key"></param>
		/// <param name="searchStartDate"></param>
		/// <param name="searchEndDate"></param>
		/// <returns></returns>
		public List<TakeOutDataInfo> selectTakeOutDataList(String keyWord, String key, String searchStartDate, String searchEndDate, String dateType, String requestUserCode, String pageType, Boolean check)
		{
            return dal.selectTakeOutDataList(keyWord, key, searchStartDate, searchEndDate, dateType, requestUserCode, pageType, check);
		}
        // 2011-04-20-김민우: 반출입 조회 시 반출목적 검색 조건 추가
        public List<TakeOutDataInfo> selectTakeOutDataList(String keyWord, String key, String searchStartDate, String searchEndDate, String dateType, String requestUserCode, String pageType, Boolean check, String visitPurpose)
        {
            return dal.selectTakeOutDataList(keyWord, key, searchStartDate, searchEndDate, dateType, requestUserCode, pageType, check, visitPurpose);
        }

		/// <summary>
		/// 반출 정보 갯수 - 보안실,신청자,결재자
		/// </summary>
		/// <param name="keyWord"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public int selectTakeOutDataTotal(String keyWord, String key, String searchStartDate, String searchEndDate, String approveUserCode, String requestUserCode)
		{
			return dal.selectTakeOutDataTotal(keyWord, key, searchStartDate, searchEndDate, approveUserCode, requestUserCode);
		}

		/// <summary>
		/// 반출 정보 수정
		/// </summary>
		/// <param name="takeOutDataInfo"></param>
		/// <returns></returns>
		public int updateTakeOutData(TakeOutDataInfo takeOutDataInfo)
		{
			return dal.updateTakeOutData(takeOutDataInfo);
		}

        /// <summary>
        /// 관리자 반출 정보 수정 (2009.09.23 임종우)
        /// </summary>
        /// <param name="dataList"></param>
        /// <returns></returns>
        public int updateTakeOutData(string[] dataList)
        {
            return dal.updateTakeOutData(dataList);
        }

		/// <summary>
		/// 반출 정보 저장
		/// </summary>
		/// <param name="takeOutDataInfo"></param>
		/// <returns></returns>
		public int insertTakeOutData(TakeOutDataInfo takeOutDataInfo)
		{
			return dal.insertTakeOutData(takeOutDataInfo);
		}

		/// <summary>
		/// 반출 정보 삭제
		/// </summary>
		/// <param name="takeOutDataInfo"></param>
		/// <returns></returns>
		public int deleteTakeOutData(TakeOutDataInfo takeOutDataInfo)
		{
			return dal.deleteTakeOutData(takeOutDataInfo);
		}

		/// <summary>
		/// 반출 코드
		/// </summary>
		/// <returns></returns>
		public String selectNextTakeOutDataCode()
		{
			return dal.selectNextTakeOutDataCode();
		}

		/// <summary>
		/// 결재 저장 (반려)
		/// </summary>
		/// <param name="takeOutDataCode"></param>
		/// <param name="approveState"></param>
		/// <param name="approveContents"></param>
		/// <returns></returns>
		public int updateApprove(String takeOutDataCode, String approveState, String approveContents)
		{
			return dal.updateApprove(takeOutDataCode, approveState, approveContents);
		}

		/// <summary>
		/// 결재 상태 가져오기
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
        //public String approveStateKOR(TakeOutDataInfo obj)
        //{
        //    String approveKor;

        //    if (obj.ApprovalState == 0)
        //    {
        //        approveKor = "미결";
        //    }
        //    else if(obj.ApprovalState == 1)
        //    {
        //        if (obj.TakeOutTime.Year == 1)
        //        {
        //            if (obj.RequireIN == 1) approveKor = "미반출 (반입필)";
        //            else approveKor = "미반출 (반입불가)";
        //        }
        //        else
        //        {
        //            if (obj.RequireIN == 1) approveKor = "반출 (반입필)";
        //            else approveKor = "종료 (반입불가)";
					
        //        }
        //    }
        //    else
        //    {
        //        approveKor = "반려";
        //    }

        //    return approveKor;
        //}

		/// <summary>
		/// 반입 필 , 불가 가져오기
		/// </summary>
		/// <param name="requireIN"></param>
		/// <returns></returns>
		public String requireKor(int requireIN)
		{
			if (requireIN == 1) return "Cần mang vào (반입필)";
			else return "Từ chối mang vào (반입불가)";
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeINTime"></param>
		/// <returns></returns>
		public String timeKor(String takeTime)
		{

            return takeTime;
            

            //if (takeTime == "-") 
            //    return "-";
            //else return takeTime.Substring(0,10);
		}

        /// <summary>
        /// 전자결재 용 HTML 만들기(반출)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public String MakeElecApproveContentsTakeOut(TakeOutDataInfo takeOutData)
        {
            StringBuilder str = new StringBuilder();
            str.Append(@"
				<table width='100%' cellpadding='6' cellspacing='1' style='background-color:#CCCCCC'>
				<tr>
					<td colspan='6' class='contents_title' style='background-color:#FFFFFF'>
						<img src='http://house.hmicron.com/COMS/images/basic/icon_02.gif' alt='icon' style='vertical-align:middle'> Thông tin tài sản mang ra (반출 정보)
					</td>
				</tr>
				<tr>
					<td style='background-color:#F5F5F5'>
						Ngày mang ra dự định (반출예정일)
					</td>
					<td style='background-color:#FFFFFF'>" + takeOutData.ScheduleOutDate + @"</td>
					<td style='background-color:#F5F5F5'>
						Ngày mang vào dự định (반입예정일)
					</td>
					<td style='background-color:#FFFFFF'>" + takeOutData.ScheduleInDate + @"</td>
				</tr>
				<tr>
					<td style='background-color:#F5F5F5'>
						Mục đích mang ra (반출 목적)
					</td>
					<td style='background-color:#FFFFFF'>" + takeOutData.TakeOutObjectName + @"</td>
					<td style='background-color:#F5F5F5'>
						Mục đích chi tiết (세부 목적)
					</td>
					<td style='background-color:#FFFFFF'>" + takeOutData.ObjectContents + @"</td>
				</tr>
				<tr>
					<td style='background-color:#F5F5F5'>
						Có mang vào hay không? (반입 여부)
					</td>
					<td style='background-color:#FFFFFF'>" + requireKor(takeOutData.RequireIN) + @"</td>
                    <td style='background-color:#F5F5F5'>
						Lý do từ chối mang vào (반입불가 사유)
					</td>
					<td style='background-color:#FFFFFF'>" + takeOutData.DisApprovalCategoryName + @"</td>
				</tr>
				<tr>
					<td style='background-color:#F5F5F5'>
						Công ty nhận (수령 회사)
					</td>
					<td style='background-color:#FFFFFF'>" + takeOutData.CompanyName + @"</td>
                    <td style='background-color:#F5F5F5'>
						Người nhận (수령자)
					</td>
					<td style='background-color:#FFFFFF'>" + takeOutData.RecieveName+ @"</td>
				</tr>
				</table>
				<br />
			");

            str.Append(@"
						<table cellspacing='0' cellpadding='4' rules='all' border='1' style='background-color:White;border-color:#3366CC;border-width:1px;border-style:None;width:100%;border-collapse:collapse;'>
						<tr style='color:#CCCCFF;background-color:#003399;'>
							<td align='center' scope='col'>Tài sản lớn (대분류)</td><td align='center' scope='col'>Tài sản vừa (중분류)</td>
                            <td align='center' scope='col'>Tên tài sản (품명)</td><td align='center' scope='col'>Quy cách (규격/Serial)</td>
                            <td align='center' scope='col'>Đơn vị (단위)</td><td align='center' scope='col'>Số lượng (수량/Serial)</td>
                        </tr>");

            TakeOutItemData bllTakeOutItemData = new TakeOutItemData();
            List<TakeOutItemDataInfo> list = bllTakeOutItemData.selectTakeOutItemDataList(takeOutData.TakeOutDataCode);            

            foreach (TakeOutItemDataInfo subObj in list)
            {
                str.Append(@"
					<tr style='color:#003399;background-color:White;'>
						<td align='center'>" + subObj.ParentCodeName + @"</td>
                        <td align='center'>" + subObj.SubCodeName + @"</td>
						<td align='center'>" + subObj.TakeOutItemName + @"</td>
                        <td align='center'>" + subObj.TakeOutItemType + @"</td>
                        <td align='center'>" + subObj.UnitName + @"</td>
                        <td align='center'>" + subObj.Account + @"</td>
                    </tr>");
            }

            str.Append("</table>");


            return str.ToString();
        }

        /// <summary>
        /// 결재 상태 state process (0 : 결재 신청 대기중 , 1 : 결재중 , 2 : 결재 완료)
        /// </summary>
        /// <param name="visitDataInfo"></param>
        /// <returns></returns>
        public String getApproveStringKOR(TakeOutDataInfo takeOutDataInfo)
        {
            String approveString = "";
            if (takeOutDataInfo.ApprovalState == 0)
            {
                approveString = "Lưu tạm thời (임시저장)";
            }
            else if (takeOutDataInfo.ApprovalState == 1)
            {
                approveString = "Gửi phê duyệt (결재상신)";
            }
            else if (takeOutDataInfo.ApprovalState == 2)
            {
                approveString = getComsState(takeOutDataInfo);
            }
            else if (takeOutDataInfo.ApprovalState == 3)
            {
                approveString = "Trả lại (반려)";
            }
            else if (takeOutDataInfo.ApprovalState == 4)
            {

            }
            return approveString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="visitDataInfo"></param>
        /// <returns></returns>
        private String getComsState(TakeOutDataInfo obj)
        {
            String state = "";
            if (obj.ApprovalState == 2)
            {
                if (obj.TakeOutItemDataList[0].TakeINTime.Equals("-") && obj.TakeOutItemDataList[0].TakeOutTime.Equals("-"))
                {
                    state = "Hoàn thành phê duyệt (결재완료)";
                }
                else
                {
                    state = "Mang vào (반입)";
                    if (obj.TakeOutItemDataList[0].TakeINTime.Equals("-")) state = "Mang ra (반출)";
                    if (obj.TakeOutItemDataList[0].TakeOutTime.Equals("-")) state = "Đồng ý (승인)";


                }
            }

            return state;
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

        /// <summary>
        /// 사용자 업로드 파일 삭제
        /// </summary>
        /// <param name="visitDataCode"></param>
        /// <param name="fileNumber"></param>
        /// <returns></returns>
        public int DeleteUserFile(String takeOutDataCode, String fileNumber, String fileName)
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
            return dal.DeleteUserFile(takeOutDataCode, fileNumber);
        }
	}
}
