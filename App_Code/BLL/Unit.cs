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
	public class Unit
	{
		private static readonly IUnit dal = HanaMicron.COMS.DALFactory.DataAccess.CreateUnit();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="unitCode"></param>
		/// <returns></returns>
		public UnitInfo selectUnit(String unitCode)
		{
			return dal.selectUnit(unitCode);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public List<UnitInfo> selectUnitList(String key)
		{
			return dal.selectUnitList(key);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public Int32 selectUnitTotal(String key)
		{
			return dal.selectUnitTotal(key);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="unitInfo"></param>
		/// <returns></returns>
		public int updateUnit(UnitInfo unitInfo)
		{
			return dal.updateUnit(unitInfo);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="unitInfo"></param>
		/// <returns></returns>
		public int insertUnit(UnitInfo unitInfo)
		{
			return dal.insertUnit(unitInfo);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="unitInfo"></param>
		/// <returns></returns>
		public int deleteUnit(UnitInfo unitInfo)
		{
			return dal.deleteUnit(unitInfo);
		}
	}
}
