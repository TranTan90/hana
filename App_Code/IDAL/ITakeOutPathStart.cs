using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;

namespace HanaMicron.COMS.IDAL
{
	/// <summary>
	/// 반출 경로 시작지점 IDAL
	/// </summary>
    public interface ITakeOutPathStart
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutPathStartCode"></param>
		/// <returns></returns>
		TakeOutPathStartInfo selectTakeOutPathStart(String takeOutPathStartCode);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		List<TakeOutPathStartInfo> selectTakeOutPathStartList(String key);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		Int32 selectTakeOutPathStartTotal(String key);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutPathStartInfo"></param>
		/// <returns></returns>
		int updateTakeOutPathStart(TakeOutPathStartInfo takeOutPathStartInfo);
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutPathStartInfo"></param>
		/// <returns></returns>
		int insertTakeOutPathStart(TakeOutPathStartInfo takeOutPathStartInfo);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="takeOutPathStartInfo"></param>
		/// <returns></returns>
		int deleteTakeOutPathStart(TakeOutPathStartInfo takeOutPathStartInfo);
    }
}
