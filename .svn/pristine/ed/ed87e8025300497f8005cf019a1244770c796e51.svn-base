using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;

namespace HanaMicron.COMS.IDAL
{
	/// <summary>
	/// 물품 카테고리 IDAL
	/// </summary>
	public interface ITakeOutItemCategory
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutItemCategoryCode"></param>
		/// <returns></returns>
		TakeOutItemCategoryInfo selectTakeOutItemCategory(String takeOutItemCategoryCode);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="depthID"></param>
		/// <param name="groupID"></param>
		/// <returns></returns>
		List<TakeOutItemCategoryInfo> selectTakeOutItemCategoryList(int depthID,int groupID);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		Int32 selectTakeOutItemCategoryTotal(String key);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutItemCategoryInfo"></param>
		/// <returns></returns>
		int updateTakeOutItemCategory(TakeOutItemCategoryInfo takeOutItemCategoryInfo);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutItemCategoryInfo"></param>
		/// <returns></returns>
		int insertTakeOutItemCategory(TakeOutItemCategoryInfo takeOutItemCategoryInfo);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutItemCategoryInfo"></param>
		/// <returns></returns>
		int deleteTakeOutItemCategory(TakeOutItemCategoryInfo takeOutItemCategoryInfo);
    }
}
