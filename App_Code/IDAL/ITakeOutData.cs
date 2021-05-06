using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;

namespace HanaMicron.COMS.IDAL
{
	/// <summary>
	/// 반출 정보 DAL Interface
	/// </summary>
	public interface ITakeOutData
	{
		/// <summary>
		/// 반출 상세
		/// </summary>
		/// <param name="visitDataCode"></param>
		/// <returns></returns>
		TakeOutDataInfo selectTakeOutData(String takeOutDataCode);

		/// <summary>
		/// 반출 정보 목록 - 보안실,신청자,결재자
		/// </summary>
		/// <param name="keyWord"></param>
		/// <param name="key"></param>
		/// <param name="searchStartDate"></param>
		/// <param name="searchEndDate"></param>
		/// <returns></returns>
		List<TakeOutDataInfo> selectTakeOutDataList(String keyWord, String key, String searchStartDate, String searchEndDate, String dateType, String requestUserCode, String pageType, Boolean check);
        // 2011-04-20-김민우: 반출입 조회 시 반출목적 검색 조건 추가
        List<TakeOutDataInfo> selectTakeOutDataList(String keyWord, String key, String searchStartDate, String searchEndDate, String dateType, String requestUserCode, String pageType, Boolean check, String visitPurpose);

		/// <summary>
		/// 반출 정보 갯수 - 보안실,신청자,결재자
		/// </summary>
		/// <param name="keyWord"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		int selectTakeOutDataTotal(String keyWord, String key, String searchStartDate, String searchEndDate, String approveUserCode, String requestUserCode);

		/// <summary>
		/// 반출 정보 수정
		/// </summary>
		/// <param name="takeOutDataInfo"></param>
		/// <returns></returns>
		int updateTakeOutData(TakeOutDataInfo takeOutDataInfo);

        /// <summary>
        /// 관리자 반출 정보 수정 (2009.09.23 임종우)
        /// </summary>
        /// <param name="dataList"></param>
        /// <returns></returns>
        int updateTakeOutData(String[] dataList);

		/// <summary>
		/// 반출 정보 저장
		/// </summary>
		/// <param name="takeOutDataInfo"></param>
		/// <returns></returns>
		int insertTakeOutData(TakeOutDataInfo takeOutDataInfo);

		/// <summary>
		/// 반출 정보 삭제
		/// </summary>
		/// <param name="takeOutDataInfo"></param>
		/// <returns></returns>
		int deleteTakeOutData(TakeOutDataInfo takeOutDataInfo);

		/// <summary>
		/// 반출 코드
		/// </summary>
		/// <returns></returns>
		String selectNextTakeOutDataCode();

		/// <summary>
		/// 결재 저장 (반려)
		/// </summary>
		/// <param name="takeOutDataCode"></param>
		/// <param name="approveState"></param>
		/// <param name="approveContents"></param>
		/// <returns></returns>
		int updateApprove(String takeOutDataCode, String approveState, String approveContents);

        /// <summary>
        /// 업로드 파일 삭제
        /// </summary>
        /// <param name="takeOutDataCode"></param>
        /// <param name="fileNumber"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        int DeleteUserFile(String takeOutDataCode, String fileNumber);
	}
}
