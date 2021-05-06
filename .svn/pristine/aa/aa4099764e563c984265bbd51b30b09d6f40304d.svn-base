using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;

namespace HanaMicron.COMS.IDAL
{
	/// <summary>
	/// 반출 목적 IDAL
	/// </summary>
    public interface ITakeOutObject
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="carCategoryID"></param>
		/// <returns></returns>
		TakeOutObjectInfo selectTakeOutObject(String takeOutObjectCode);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="txtKey"></param>
		/// <returns></returns>
		List<TakeOutObjectInfo> selectTakeOutObjectList(String key);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		Int32 selectTakeOutObjectTotal(String key);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutObjectInfo"></param>
		/// <returns></returns>
		int updateTakeOutObject(TakeOutObjectInfo takeOutObjectInfo);
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutObjectInfo"></param>
		/// <returns></returns>
		int insertTakeOutObject(TakeOutObjectInfo takeOutObjectInfo);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutObjectInfo"></param>
		/// <returns></returns>
		int deleteTakeOutObject(TakeOutObjectInfo takeOutObjectInfo);
    }
}
