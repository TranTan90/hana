using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Model;

/// Bisiness Logic Layer 
namespace HanaMicron.COMS.BLL
{
	/// <summary>
	/// 단위 BLL
	/// </summary>
	public class DisApprovalCategory
	{
		private static readonly IDisApprovalCategory dal = HanaMicron.COMS.DALFactory.DataAccess.CreateDisApprovalCategory();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disApprovalCategoryCode"></param>
		/// <returns></returns>
		public DisApprovalCategoryInfo selectDisApprovalCategory(String disApprovalCategoryCode)
		{
			return dal.selectDisApprovalCategory(disApprovalCategoryCode);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public List<DisApprovalCategoryInfo> selectDisApprovalCategoryList(String key)
		{
			return dal.selectDisApprovalCategoryList(key);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public Int32 selectDisApprovalCategoryTotal(String key)
		{
			return dal.selectDisApprovalCategoryTotal(key);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disApprovalCategoryInfo"></param>
		/// <returns></returns>
		public int updateDisApprovalCategory(DisApprovalCategoryInfo disApprovalCategoryInfo)
		{
			return dal.updateDisApprovalCategory(disApprovalCategoryInfo);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disApprovalCategoryInfo"></param>
		/// <returns></returns>
		public int insertDisApprovalCategory(DisApprovalCategoryInfo disApprovalCategoryInfo)
		{
			return dal.insertDisApprovalCategory(disApprovalCategoryInfo);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disApprovalCategoryInfo"></param>
		/// <returns></returns>
		public int deleteDisApprovalCategory(DisApprovalCategoryInfo disApprovalCategoryInfo)
		{
			return dal.deleteDisApprovalCategory(disApprovalCategoryInfo);
		}
	}
}
