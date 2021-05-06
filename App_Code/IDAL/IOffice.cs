using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;

namespace HanaMicron.COMS.IDAL
{
	/// <summary>
	/// 거래처 DAL  Interface
	/// </summary>
	public interface IOffice
	{
		/// <summary>
		/// 사무실 정보 가져오기
		/// </summary>
		/// <param name="officeCode"></param>
		/// <returns></returns>
		OfficeInfo selectOffice(String officeCode);

		/// <summary>
		/// 사무실 목록 가져오기
		/// </summary>
		/// <param name="keyWord"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		List<OfficeInfo> selectOfficeList(String keyWord, String key);

		/// <summary>
		/// 사무실 총 숫자
		/// </summary>
		/// <param name="keyWord"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		int selectOfficeTotal(String keyWord, String key);

		/// <summary>
		/// 사무실 수정
		/// </summary>
		/// <param name="office"></param>
		/// <returns></returns>
		int updateOffice(OfficeInfo office);

		/// <summary>
		/// 사무실 저장
		/// </summary>
		/// <param name="office"></param>
		/// <returns></returns>
		int insertOffice(OfficeInfo office);
		
		/// <summary>
		/// 사무실 삭제
		/// </summary>
		/// <param name="office"></param>
		/// <returns></returns>
		int deleteOffice(OfficeInfo office);
	}
}
