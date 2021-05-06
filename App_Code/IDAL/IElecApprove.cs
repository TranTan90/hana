using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;

namespace HanaMicron.COMS.IDAL
{
	/// <summary>
	/// 반출 정보 DAL Interface
	/// </summary>
	public interface IElecApprove
	{
        /// <summary>
        /// 결재 상태 보기
        /// </summary>
        /// <param name="docCode"></param>
        /// <returns></returns>
        List<ElecStatusInfo> SelectStatus(String docCode);

        //결재 정보 저장
        int insertElecApprove(ElecApproveInfo ElecApproveInfo);
        ElecApproveInfo selectElecApproveStatus(String elecApproveCode);
    }
}
