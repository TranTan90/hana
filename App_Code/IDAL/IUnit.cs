using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;

namespace HanaMicron.COMS.IDAL
{
	/// <summary>
	/// 단위 IDAL
	/// </summary>
	public interface IUnit
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="unitCode"></param>
		/// <returns></returns>
		UnitInfo selectUnit(String unitCode);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		List<UnitInfo> selectUnitList(String key);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		Int32 selectUnitTotal(String key);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="unitInfo"></param>
		/// <returns></returns>
		int updateUnit(UnitInfo unitInfo);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="unitInfo"></param>
		/// <returns></returns>
		int insertUnit(UnitInfo unitInfo);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="unitInfo"></param>
		/// <returns></returns>
		int deleteUnit(UnitInfo unitInfo);
    }
}
