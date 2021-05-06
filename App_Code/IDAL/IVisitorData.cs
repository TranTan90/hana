using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;

namespace HanaMicron.COMS.IDAL
{
	/// <summary>
	/// 내방 정보 DAL Interface
	/// </summary>
	public interface IVisitorData
	{
		/// <summary>
		/// 내방 정보 가져오기
		/// </summary>
		/// <param name="visitorDataCode"></param>
		/// <returns></returns>
		VisitorDataInfo selectVisitorData(String visitorDataCode);

		/// <summary>
		/// 내방 정보 목록
		/// </summary>
		/// <param name="keyWord"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		List<VisitorDataInfo> selectVisitorDataList(String keyWord, String key);

		/// <summary>
		/// 내방 정보 목록 (1개의 내방 Data)
		/// </summary>
		/// <param name="visitDataCode"></param>
		/// <returns></returns>
		List<VisitorDataInfo> selectVisitorDataList(String visitDataCode);

        /// <summary>
		/// 내방 총 count
		/// </summary>
		/// <param name="keyWord"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		int selectVisitorDataTotal(String keyWord, String key);

		/// <summary>
		/// 내방 정보 수정
		/// </summary>
		/// <param name="visitorDataInfo"></param>
		/// <returns></returns>
		int updateVisitorData(VisitorDataInfo visitorDataInfo);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="?"></param>
		/// <returns></returns>
		int updateInTime(VisitorDataInfo visitorDataInfo);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="?"></param>
		/// <returns></returns>
		int updateOutTime(VisitorDataInfo visitorDataInfo);

		/// <summary>
		/// 내방 정보 저장
		/// </summary>
		/// <param name="visitorDataInfo"></param>
		/// <returns></returns>
		int insertVisitorData(VisitorDataInfo visitorDataInfo);

		/// <summary>
		/// 내방 정보 삭제
		/// </summary>
		/// <param name="visitorDataInfo"></param>
		/// <returns></returns>
		int deleteVisitorData(VisitorDataInfo visitorDataInfo);

        /// <summary>
        /// 최종 입력된 VisitorDataCode값
        /// </summary>
        /// <returns></returns>
        int selectMaxVisitorDataCode();

        /// <summary>
        /// 금일날짜 내방 정보중 출문미처리 된 내역
        /// </summary>
        /// <param name="visitDataCode"></param>
        /// <param name="visitorCode"></param>
        /// <returns></returns>
        bool checkTodayVisitorData(String visitorCode);
	}
}
