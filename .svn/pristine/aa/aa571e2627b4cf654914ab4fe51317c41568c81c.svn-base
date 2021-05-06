using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Model;

/// Bisiness Logic Layer 
namespace HanaMicron.COMS.BLL
{
	/// <summary>
	/// 반출 시작 지점 BLL
	/// </summary>
	public class TakeOutPathEnd
	{
		private static readonly ITakeOutPathEnd dal = HanaMicron.COMS.DALFactory.DataAccess.CreateTakeOutPathEnd();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutPathEndCode"></param>
		/// <returns></returns>
		public TakeOutPathEndInfo selectTakeOutPathEnd(String takeOutPathEndCode)
		{
			return dal.selectTakeOutPathEnd(takeOutPathEndCode);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public List<TakeOutPathEndInfo> selectTakeOutPathEndList(String key)
		{
			return dal.selectTakeOutPathEndList(key);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public Int32 selectTakeOutPathEndTotal(String key)
		{
			return dal.selectTakeOutPathEndTotal(key);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutPathEndInfo"></param>
		/// <returns></returns>
		public int updateTakeOutPathEnd(TakeOutPathEndInfo takeOutPathEndInfo)
		{
			return dal.updateTakeOutPathEnd(takeOutPathEndInfo);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutPathEndInfo"></param>
		/// <returns></returns>
		public int insertTakeOutPathEnd(TakeOutPathEndInfo takeOutPathEndInfo)
		{
			return dal.insertTakeOutPathEnd(takeOutPathEndInfo);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutPathEndInfo"></param>
		/// <returns></returns>
		public int deleteTakeOutPathEnd(TakeOutPathEndInfo takeOutPathEndInfo)
		{
			return dal.deleteTakeOutPathEnd(takeOutPathEndInfo);
		}
	}
}
