using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Model;

/// Bisiness Logic Layer 
namespace HanaMicron.COMS.BLL
{
	/// <summary>
	/// 내방객 BLL
	/// </summary>
	public class Visitor
	{
		private static readonly IVisitor dal = HanaMicron.COMS.DALFactory.DataAccess.CreateVisitor();

		/// <summary>
		/// 내방객 정보 가져오기
		/// </summary>
		/// <param name="visitorCode"></param>
		/// <returns></returns>
		public VisitorInfo getVisitor(String visitorCode)
		{
			return dal.getVisitor(visitorCode);	
		}

        /// <summary>
        /// 내방객 정보 가져오기(주민번호 이용)
        /// </summary>
        /// <param name="visitorRegNumber1"></param>
        /// <param name="visitorRegNumber2"></param>
        /// <returns></returns>
        public VisitorInfo getVisitor(String visitorRegNumber1, String visitorRegNumber2)
        {
            return dal.getVisitor(visitorRegNumber1, visitorRegNumber2);
        }

		/// <summary>
		/// 내방객 목록
		/// </summary>
		/// <param name="keyWord"></param>
		/// <param name="key"></param>
		/// <param name="pageNo"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public List<VisitorInfo> listVisitor(String keyWord, String key,Boolean reject)
		{
			return dal.listVisitor(keyWord, key,reject);
		}

		/// <summary>
		/// 내방객 숫자
		/// </summary>
		/// <param name="keyWord"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public Int32 totalVisitor(String keyWord, String key,Boolean reject)
		{
			return dal.totalVisitor(keyWord, key,reject);
		}

		/// <summary>
		/// 내방객 수정
		/// </summary>
		/// <param name="visitor"></param>
		/// <returns></returns>
		public int updatetVisitor(VisitorInfo visitor)
		{
			return dal.updatetVisitor(visitor);
		}

		/// <summary>
		/// 내방객 저장
		/// </summary>
		/// <param name="visitor"></param>
		/// <returns></returns>
		public int insertVisitor(VisitorInfo visitor)
		{
			return dal.insertVisitor(visitor);
		}

		/// <summary>
		/// 내방객 삭제
		/// </summary>
		/// <param name="visitorCode"></param>
		/// <returns></returns>
		public int deleteVisitor(Int32 visitorCode)
		{
			return dal.deleteVisitor(visitorCode);
		}

		/// <summary>
		/// 이미 등록된 내방객 여부
		/// </summary>
		/// <param name="visitorRegNumber1"></param>
		/// <param name="visitorRegNumber2"></param>
		/// <returns></returns>
        public bool existsVisitor(String visitorRegNumber1, String visitorRegNumber2)
        {
            return dal.existsVisitor(visitorRegNumber1, visitorRegNumber2);
        }

        /// <summary>
        /// 이미 등록된 Free pass 내방객 여부
        /// </summary>
        /// <param name="visitorName"></param>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public bool existsFreepassVisitor(String visitorName, Int32 companyCode)
        {
            return dal.existsFreepassVisitor(visitorName, companyCode);
        }

        /// <summary>
        /// Free pass 내방객 유무 확인
        /// </summary>
        /// <param name="visitorCode"></param>
        /// <returns></returns>
        public bool existsFreepassVisitor(Int32 visitorCode)
        {
            return dal.existsFreepassVisitor(visitorCode);
        }

        /// <summary>
        /// EDS 교육이수 정보 업데이트
        /// </summary>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public int updateEdsData(VisitorInfo visitor)
        {
            return dal.updateEdsData(visitor);
        }
	}
}
