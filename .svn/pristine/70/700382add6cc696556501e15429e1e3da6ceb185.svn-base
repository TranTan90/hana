using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Model;

/// Bisiness Logic Layer 
namespace HanaMicron.COMS.BLL
{
	/// <summary>
	/// 반출 제품 카테고리 BLL
	/// </summary>
	public class TakeOutItemCategory
	{
		private static readonly ITakeOutItemCategory dal = HanaMicron.COMS.DALFactory.DataAccess.CreateTakeOutItemCategory();

		/// <summary>
		/// 카테고리 단일 선택
		/// </summary>
		/// <param name="takeOutItemCategoryCode"></param>
		/// <returns></returns>
		public TakeOutItemCategoryInfo selectTakeOutItemCategory(String takeOutItemCategoryCode)
		{
			return dal.selectTakeOutItemCategory(takeOutItemCategoryCode);
		}

		/// <summary>
		/// 카테고리 목록 (검색)
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public List<TakeOutItemCategoryInfo> selectTakeOutItemCategoryList(int depthID,int groupID)
		{
			return dal.selectTakeOutItemCategoryList(depthID,groupID);
		}

		/// <summary>
		/// 카텍로리 갯수 (검색)
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public Int32 selectTakeOutItemCategoryTotal(String key)
		{
			return dal.selectTakeOutItemCategoryTotal(key);
		}

		/// <summary>
		/// 카테고리 수정
		/// </summary>
		/// <param name="takeOutItemCategoryInfo"></param>
		/// <returns></returns>
		public int updateTakeOutItemCategory(TakeOutItemCategoryInfo takeOutItemCategoryInfo)
		{
			return dal.updateTakeOutItemCategory(takeOutItemCategoryInfo);
		}

		/// <summary>
		/// 카테고리 저장
		/// </summary>
		/// <param name="takeOutItemCategoryInfo"></param>
		/// <returns></returns>
		public int insertTakeOutItemCategory(TakeOutItemCategoryInfo takeOutItemCategoryInfo)
		{
			return dal.insertTakeOutItemCategory(takeOutItemCategoryInfo);
		}

		/// <summary>
		/// 카테고리 삭제
		/// </summary>
		/// <param name="takeOutItemCategoryInfo"></param>
		/// <returns></returns>
		public int deleteTakeOutItemCategory(TakeOutItemCategoryInfo takeOutItemCategoryInfo)
		{
			return dal.deleteTakeOutItemCategory(takeOutItemCategoryInfo);
		}
	}
}
