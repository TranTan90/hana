using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Model;

/// Bisiness Logic Layer 
namespace HanaMicron.COMS.BLL
{
	/// <summary>
	/// 반출 목적 코드 BLL
	/// </summary>
	public class TakeOutObject
	{
		private static readonly ITakeOutObject dal = HanaMicron.COMS.DALFactory.DataAccess.CreateTakeOutObject();

		/// <summary>
		/// 반출 목적 단일 선택
		/// </summary>
		/// <param name="takeOutObjectCode"></param>
		/// <returns></returns>
		public TakeOutObjectInfo selectTakeOutObject(String takeOutObjectCode)
		{
			return dal.selectTakeOutObject(takeOutObjectCode);
		}

		/// <summary>
		/// 반출 목적 전체(검색) 목록
		/// </summary>
		/// <param name="txtKey"></param>
		/// <returns></returns>
		public List<TakeOutObjectInfo> selectTakeOutObjectList(String key)
		{
			return dal.selectTakeOutObjectList(key);
		}

		/// <summary>
		/// 반출 목적 갯수
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public Int32 selectTakeOutObjectTotal(String key)
		{
			return dal.selectTakeOutObjectTotal(key);
		}

		/// <summary>
		/// 반출 목적 수정
		/// </summary>
		/// <param name="takeOutObjectInfo"></param>
		/// <returns></returns>
		public int updateTakeOutObject(TakeOutObjectInfo takeOutObjectInfo)
		{
			return dal.updateTakeOutObject(takeOutObjectInfo);
		}

		/// <summary>
		/// 반출 목적 저장
		/// </summary>
		/// <param name="takeOutObjectInfo"></param>
		/// <returns></returns>
		public int insertTakeOutObject(TakeOutObjectInfo takeOutObjectInfo)
		{
			return dal.insertTakeOutObject(takeOutObjectInfo);
		}

		/// <summary>
		/// 반출 목적 삭제
		/// </summary>
		/// <param name="takeOutObjectInfo"></param>
		/// <returns></returns>
		public int deleteTakeOutObject(TakeOutObjectInfo takeOutObjectInfo)
		{
			return dal.deleteTakeOutObject(takeOutObjectInfo);
		}
	}
}
