using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;

namespace HanaMicron.COMS.IDAL
{
	/// <summary>
	/// 관리자 DAL Interface
	/// </summary>
    public interface IManager
    {
		/// <summary>
		/// 관리자 정보 가져오기
		/// </summary>
		/// <param name="upnid"></param>
		/// <returns></returns>
        ManagerInfo selectManager(String upnid);

		/// <summary>
		/// 관리자 목록
		/// </summary>
		/// <returns></returns>
		List<ManagerInfo> selectManagerList(int managerLevel);

		/// <summary>
		/// 관리자 수정
		/// </summary>
		/// <param name="managerInfo"></param>
		/// <returns></returns>
		int updateManager(ManagerInfo managerInfo);

		/// <summary>
		/// 관리자 저장
		/// </summary>
		/// <param name="managerInfo"></param>
		/// <returns></returns>
		int insertManager(ManagerInfo managerInfo);

		/// <summary>
		/// 관리자 삭제
		/// </summary>
		/// <param name="managerInfo"></param>
		/// <returns></returns>
		int deleteManager(ManagerInfo managerInfo);

		/// <summary>
		/// 이미 등록된 관리자 여부
		/// </summary>
		/// <param name="managerInfo"></param>
		/// <returns></returns>
		bool existsManager(ManagerInfo managerInfo);
    }
}
