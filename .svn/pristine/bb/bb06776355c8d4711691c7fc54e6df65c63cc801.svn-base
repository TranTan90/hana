using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;

namespace HanaMicron.COMS.IDAL
{
	/// <summary>
	/// 반출 물품 IDAL
	/// </summary>
	public interface ITakeOutItemData
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutItemDataCode"></param>
		/// <returns></returns>
		TakeOutItemDataInfo selectTakeOutItemData(String takeOutItemDataCode);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutItemDataCode"></param>
		/// <returns></returns>
		List<TakeOutItemDataInfo> selectTakeOutItemDataList(String takeOutDataCode);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutItemDataInfo"></param>
		/// <returns></returns>
		int insertTakeOutItemData(TakeOutItemDataInfo takeOutItemDataInfo);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutItemDataInfo"></param>
		/// <returns></returns>
		int deleteTakeOutItemData(TakeOutItemDataInfo takeOutItemDataInfo);

        /// <summary>
        /// 반출 처리 시간 저장(부분반출 없음. 동일 반출번호 일괄 반출처리)
        /// </summary>
        /// <param name="takeOutItemDataCode"></param>
        /// <param name="securityUserCode"></param>
        /// <returns></returns>
        int updateOutTime(String takeOutDataCode, String securityUserCode);

        /// <summary>
        /// 반입 시간 저장
        /// </summary>
        /// <param name="takeOutDataCode"></param>
        /// <param name="securityUserCode"></param>
        /// <returns></returns>
        int updateInTime(String takeOutItemDataCode, String securityUserCode);
    }
}
