using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;

/// Data Access Layer Interface
namespace HanaMicron.COMS.IDAL
{
	/// <summary>
	/// 내방객 DAL Interface
	/// </summary>
	public interface IVisitor
	{
		/// <summary>
		/// 내방객 정보 가져오기
		/// </summary>
		/// <param name="visitorCode"></param>
		/// <returns></returns>
		VisitorInfo getVisitor(String visitorCode);

        /// <summary>
        /// 내방객 정보 가져오기(주민번호 이용)
        /// </summary>
        /// <param name="visitorRegNumber1"></param>
        /// <param name="visitorRegNumber2"></param>
        /// <returns></returns>
        VisitorInfo getVisitor(String visitorRegNumber1, String visitorRegNumber2);

		/// <summary>
		/// 내방객 목록 
		/// </summary>
		/// <param name="keyWord"></param>
		/// <param name="key"></param>
		/// <param name="pageNo"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		List<VisitorInfo> listVisitor(String keyWord, String key,Boolean reject);

		/// <summary>
		/// 내방객 총 숫자
		/// </summary>
		/// <param name="keyWord"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		Int32 totalVisitor(String keyWord, String key,Boolean reject);

		/// <summary>
		/// 내방객 수정
		/// </summary>
		/// <param name="visitor"></param>
		/// <returns></returns>
		int updatetVisitor(VisitorInfo visitor);

		/// <summary>
		/// 내방객 저장
		/// </summary>
		/// <param name="visitor"></param>
		/// <returns></returns>
		int insertVisitor(VisitorInfo visitor);

		/// <summary>
		/// 내방객 삭제
		/// </summary>
		/// <param name="visitorCode"></param>
		/// <returns></returns>
		int deleteVisitor(Int32 visitorCode);

		/// <summary>
		/// 이미 등록된 내방객 확인
		/// </summary>
		/// <param name="visitorRegNumber1"></param>
		/// <param name="visitorRegNumber2"></param>
		/// <returns></returns>
        bool existsVisitor(String visitorRegNumber1, String visitorRegNumber2);

        /// <summary>
        /// 이미 등록된 Free pass 내방객 확인
        /// </summary>
        /// <param name="visitorName"></param>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        bool existsFreepassVisitor(String visitorName, Int32 companyCode);

        /// <summary>
        /// Free pass 내방객 유무 확인
        /// </summary>
        /// <param name="visitorCode"></param>
        /// <returns></returns>
        bool existsFreepassVisitor(Int32 visitorCode);

        /// <summary>
        /// EDS 교육이수 정보 업데이트
        /// </summary>
        /// <param name="visitor"></param>
        /// <returns></returns>
        int updateEdsData(VisitorInfo visitor);
    }
}
