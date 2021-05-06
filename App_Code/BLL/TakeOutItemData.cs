using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Model;

/// Bisiness Logic Layer 
namespace HanaMicron.COMS.BLL
{
	/// <summary>
	/// 반출 물품 BLL
	/// </summary>
	public class TakeOutItemData
	{
		private static readonly ITakeOutItemData dal = HanaMicron.COMS.DALFactory.DataAccess.CreateTakeOutItemData();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutItemDataCode"></param>
		/// <returns></returns>
		public TakeOutItemDataInfo selectTakeOutItemData(String takeOutItemDataCode)
		{
			return dal.selectTakeOutItemData(takeOutItemDataCode);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutItemDataCode"></param>
		/// <returns></returns>
		public List<TakeOutItemDataInfo> selectTakeOutItemDataList(String takeOutDataCode)
		{
			return dal.selectTakeOutItemDataList(takeOutDataCode);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutItemDataInfo"></param>
		/// <returns></returns>
		public int insertTakeOutItemData(TakeOutItemDataInfo takeOutItemDataInfo)
		{
			return dal.insertTakeOutItemData(takeOutItemDataInfo);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutItemDataInfo"></param>
		/// <returns></returns>
		public int deleteTakeOutItemData(TakeOutItemDataInfo takeOutItemDataInfo)
		{
			return dal.deleteTakeOutItemData(takeOutItemDataInfo);
		}

        /// <summary>
        /// 반출 처리 시간 저장(부분반출 없음. 동일 반출번호 일괄 반출처리)
        /// </summary>
        /// <param name="takeOutDataCode"></param>
        /// <param name="securityUserCode"></param>
        /// <returns></returns>
        public int updateOutTime(String takeOutDataCode, String securityUserCode)
        {
            return dal.updateOutTime(takeOutDataCode, securityUserCode);
        }

        /// <summary>
        /// 반입 시간 저장
        /// </summary>
        /// <param name="takeOutDataCode"></param>
        /// <param name="securityUserCode"></param>
        /// <returns></returns>
        public int updateInTime(String takeOutItemDataCode, String securityUserCode)
        {
            return dal.updateInTime(takeOutItemDataCode, securityUserCode);
        }
	}
}
