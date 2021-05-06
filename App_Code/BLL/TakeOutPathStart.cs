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
	public class TakeOutPathStart
	{
		private static readonly ITakeOutPathStart dal = HanaMicron.COMS.DALFactory.DataAccess.CreateTakeOutPathStart();

		/// <summary>
		/// 반출 시작 지점 가져오기 (단일 레코드)
		/// </summary>
		/// <param name="takeOutPathStartCode"></param>
		/// <returns></returns>
		public TakeOutPathStartInfo selectTakeOutPathStart(String takeOutPathStartCode)
		{
			return dal.selectTakeOutPathStart(takeOutPathStartCode);
		}

		/// <summary>
		/// 반출 시작 지점 목록(검색)
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public List<TakeOutPathStartInfo> selectTakeOutPathStartList(String key)
		{
			return dal.selectTakeOutPathStartList(key);
		}

		/// <summary>
		/// 반출 시작 지점 갯수(검색 갯수)
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public Int32 selectTakeOutPathStartTotal(String key)
		{
			return dal.selectTakeOutPathStartTotal(key);
		}

		/// <summary>
		/// 반출 시작 지점 수정
		/// </summary>
		/// <param name="takeOutPathStartInfo"></param>
		/// <returns></returns>
		public int updateTakeOutPathStart(TakeOutPathStartInfo takeOutPathStartInfo)
		{
			return dal.updateTakeOutPathStart(takeOutPathStartInfo);
		}

		/// <summary>
		/// 반출 시작 지점 저장
		/// </summary>
		/// <param name="takeOutPathStartInfo"></param>
		/// <returns></returns>
		public int insertTakeOutPathStart(TakeOutPathStartInfo takeOutPathStartInfo)
		{
			return dal.insertTakeOutPathStart(takeOutPathStartInfo);
		}

		/// <summary>
		/// 반출 시작 지점 삭제
		/// </summary>
		/// <param name="takeOutPathStartInfo"></param>
		/// <returns></returns>
		public int deleteTakeOutPathStart(TakeOutPathStartInfo takeOutPathStartInfo)
		{
			return dal.deleteTakeOutPathStart(takeOutPathStartInfo);
		}
	}
}
