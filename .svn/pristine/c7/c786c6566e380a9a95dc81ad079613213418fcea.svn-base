using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Model;

namespace HanaMicron.COMS.BLL
{
	/// <summary>
	/// 거래처 BLL
	/// </summary>
	public class Company
	{
		private static readonly ICompany dal = HanaMicron.COMS.DALFactory.DataAccess.CreateCompany();

		/// <summary>
		/// 거래처 정보 가져오기
		/// </summary>
		/// <param name="companyCode"></param>
		/// <returns></returns>
		public CompanyInfo getCompany(String companyCode)
		{
			return dal.getCompany(companyCode);
		}

		/// <summary>
		/// 거래처 목록
		/// </summary>
		/// <param name="keyWord"></param>
		/// <param name="key"></param>
		/// <param name="pageNo"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public List<CompanyInfo> getCompanyList(String keyWord, String key, Int32 approve, String employeeCode)
		{
			return dal.getCompanyList(keyWord, key,approve,employeeCode);
		}

		/// <summary>
		/// 거래처 숫자
		/// 검색어 구분,검색어,승인여부(승인:1,미승인:0),등록자 코드
		/// 등록자 코드를 empty 로 넘기면 전체가 조회 된다.
		/// ex : Int32 totalCount = bll.getCompanyTotal(keyWord.Text, key.Text,1,"");
		/// </summary>
		/// <param name="keyWord"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public Int32 getCompanyTotal(String keyWord, String key, Int32 approve, String employeeCode)
		{
			return dal.getCompanyTotal(keyWord, key, approve, employeeCode);
		}

		/// <summary>
		/// 거래처 수정
		/// </summary>
		/// <param name="company"></param>
		/// <returns></returns>
		public int updateCompany(CompanyInfo company)
		{
			return dal.updateCompany(company);
		}

		/// <summary>
		/// 거래처 저장
		/// </summary>
		/// <param name="company"></param>
		/// <returns></returns>
		public int insertCompany(CompanyInfo company)
		{
			return dal.insertCompany(company);
		}

		/// <summary>
		/// 거래처 삭제
		/// </summary>
		/// <param name="companyCode"></param>
		/// <returns></returns>
		public int deleteCompany(Int32 companyCode)
		{
			return dal.deleteCompany(companyCode);
		}

		/// <summary>
		/// 이미 등록된 거래처 여부
		/// </summary>
		/// <param name="regNumber1"></param>
		/// <param name="regNumber2"></param>
		/// <param name="regNumber3"></param>
		/// <param name="companyName"></param>
		/// <returns></returns>
		public bool existsComapny(String regNumber1, String regNumber2, String regNumber3, String companyName)
		{
			return dal.existsComapny(regNumber1, regNumber2, regNumber3, companyName);
		}

        // AM 함수
        public void CreateHtml(CompanyInfo company)
        {
            dal.CreateHtml(company);
        }
	}
}
