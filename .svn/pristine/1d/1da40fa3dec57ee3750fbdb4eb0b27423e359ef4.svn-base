using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;

namespace HanaMicron.COMS.IDAL
{
    /// <summary>
    /// 내방 정보 DAL Interface
    /// </summary>
    public interface IVisitData
    {
        /// <summary>
        /// select
        /// </summary>
        /// <param name="visitDataCode"></param>
        /// <returns></returns>
        VisitDataInfo selectVisitData(String visitDataCode);

        /// <summary>
        /// list 
        /// </summary>     
        /// <param name="keyWord"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        List<VisitDataInfo> selectVisitDataList(String keyWord, String key, String searchStartDate, String searchEndDate, String upnid, String approveUserCode, String type);

        /// <summary>
        /// longVisitList
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        List<VisitDataInfo> selectLongVisitDataList(String date, String key, String keyWord);

        /// <summary>
        /// checkLongVisitDataCode
        /// </summary>
        /// <param name="visitDataCode"></param>
        /// <returns></returns>
        VisitDataInfo checkLongVisitDataCode(String visitDataCode, String code);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyWord"></param>
        /// <param name="key"></param>
        /// <param name="searchStartDate"></param>
        /// <param name="searchEndDate"></param>
        /// <param name="upnid"></param>
        /// <param name="approveUserCode"></param>
        /// <returns></returns>
        int selectVisitDataTotal(String keyWord, String key, String searchStartDate, String searchEndDate, String upnid, String approveUserCode);

        /// <summary>
        /// update
        /// </summary>
        /// <param name="visitData"></param>
        /// <returns></returns>
        int updateVisitData(VisitDataInfo visitData);

        /// <summary>
        /// update (Free pass 내방 Data로 update, visitFlag=5)
        /// </summary>
        /// <param name="visitData"></param>
        /// <returns></returns>
        int updateVisitData(Int32 visitDataCode, Int32 flag);

        /// <summary>
        /// insert
        /// </summary>
        /// <param name="visitData"></param>
        /// <returns></returns>
        int insertVisitData(VisitDataInfo visitData);

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="visitData"></param>
        /// <returns></returns>
        int deleteVisitData(VisitDataInfo visitData);

        /// <summary>
        /// 최종 입력 값
        /// </summary>
        /// <returns></returns>
        int selectMaxCode();

        /// <summary>
        /// 입문
        /// </summary>
        /// <param name="visitDatacode"></param>
        /// <returns></returns>
        int updateInTime(String visitDataCode);

        /// <summary>
        /// 출문
        /// </summary>
        /// <param name="visitDatacode"></param>
        /// <returns></returns>
        int updateOutTime(String visitDataCode);

        /// <summary>
        /// 결재
        /// </summary>
        /// <param name="visitDateCode"></param>
        /// <param name="approveStat"></param>
        /// <returns></returns>
        int updateApprove(String visitDataCode, String approveState, String approveContents);

		/// <summary>
		/// 전자결재 코드를 가지고 update
		/// </summary>
		/// <param name="elecApproveCode"></param>
		/// <returns></returns>
		int UpdateApprove(String elecApproveCode, String approveState);

		/// <summary>
		/// 업로드 파일 삭제
		/// </summary>
		/// <param name="visitDataCode"></param>
		/// <param name="fileNumber"></param>
		/// <returns></returns>
		int DeleteUserFile(String visitDataCode, String fileNumber);
    }
}
