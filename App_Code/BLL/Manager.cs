using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Model;

/// Bisiness Logic Layer 
namespace HanaMicron.COMS.BLL
{
	/// <summary>
	/// 관리자 정보 BLL
	/// </summary>
	public class Manager
	{
		private static readonly IManager dal = HanaMicron.COMS.DALFactory.DataAccess.CreateManager();


		/// <summary>
		/// 관리자 정보 가져오기
		/// </summary>
		/// <param name="upnid"></param>
		/// <returns></returns>
		public ManagerInfo selectManager(String upnid)
		{
			return dal.selectManager(upnid);
		}

		/// <summary>
		/// 관리자 목록
		/// </summary>
		/// <returns></returns>
		public List<ManagerInfo> selectManagerList(int managerLevel)
		{
			return dal.selectManagerList(managerLevel);
		}

		/// <summary>
		/// 관리자 수정
		/// </summary>
		/// <param name="managerInfo"></param>
		/// <returns></returns>
		public int updateManager(ManagerInfo managerInfo)
		{
			return dal.updateManager(managerInfo);
		}

		/// <summary>
		/// 관리자 저장
		/// </summary>
		/// <param name="managerInfo"></param>
		/// <returns></returns>
		public int insertManager(ManagerInfo managerInfo)
		{
			return dal.insertManager(managerInfo);
		}

		/// <summary>
		/// 관리자 삭제
		/// </summary>
		/// <param name="managerInfo"></param>
		/// <returns></returns>
		public int deleteManager(ManagerInfo managerInfo)
		{
			return dal.deleteManager(managerInfo);
		}

		/// <summary>
		/// 이미 등록된 관리자 여부
		/// </summary>
		/// <param name="managerInfo"></param>
		/// <returns></returns>
		public bool existsManager(ManagerInfo managerInfo){
			return dal.existsManager(managerInfo);
		}
	}
}
