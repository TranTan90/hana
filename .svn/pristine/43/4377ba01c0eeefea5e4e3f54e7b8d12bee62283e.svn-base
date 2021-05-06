using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;

namespace HanaMicron.COMS.IDAL
{
	/// <summary>
	/// 반출 정보 DAL Interface
	/// </summary>
	public interface ISecCardData
	{

        /// <summary>
        /// 반출 정보 저장
        /// </summary>
        /// <param name="SecCardDataInfo"></param>
        /// <returns></returns>
        int insertSecCardData(SecCardDataInfo SecCardDataInfo);
        int updateSecCardData(SecCardDataInfo SecCardDataInfo);
        int deleteSecCardData(String secCardDataCode);
        int selectMaxCode();
        int updateApprove(String secCardDataCode, String approveState, String approveContents);
        /// <summary>
        /// 반출 정보 조회
        /// </summary>
        /// <param name="SecCardDataInfo"></param>
        /// <returns></returns>
        List<SecCardDataInfo> selectSecCardDataList(String keyWord, String key, String searchStartDate, String searchEndDate, String upnid, String approveUserCode, String type);
       
        /// <summary>
        /// select
        /// </summary>
        /// <param name="secCardDataCode"></param>
        /// <returns></returns>
        SecCardDataInfo selectSecCardData(String secCardDataCode);
     
        
	}
}
