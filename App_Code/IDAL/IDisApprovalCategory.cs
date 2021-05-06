using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;

namespace HanaMicron.COMS.IDAL
{
	/// <summary>
	/// 불가 사유 IDAL
	/// </summary>
	public interface IDisApprovalCategory
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="disApprovalCategoryCode"></param>
		/// <returns></returns>
		DisApprovalCategoryInfo selectDisApprovalCategory(String disApprovalCategoryCode);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		List<DisApprovalCategoryInfo> selectDisApprovalCategoryList(String key);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		Int32 selectDisApprovalCategoryTotal(String key);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disApprovalCategoryInfo"></param>
		/// <returns></returns>
		int updateDisApprovalCategory(DisApprovalCategoryInfo disApprovalCategoryInfo);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disApprovalCategoryInfo"></param>
		/// <returns></returns>
		int insertDisApprovalCategory(DisApprovalCategoryInfo disApprovalCategoryInfo);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disApprovalCategoryInfo"></param>
		/// <returns></returns>
		int deleteDisApprovalCategory(DisApprovalCategoryInfo disApprovalCategoryInfo);
    }
}
