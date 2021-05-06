using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Model;

/// Bisiness Logic Layer 
namespace HanaMicron.COMS.BLL
{
	/// <summary>
	/// 반출 BLL
	/// </summary>
	public class ElecApprove
	{
        private static readonly IElecApprove dal = HanaMicron.COMS.DALFactory.DataAccess.CreateElecApprove();

        /// <summary>
        /// 전자 결재 정보 저장
        /// </summary>
        /// <param name="ElecApprove"></param>
        /// <returns></returns>
        public int insertElecApprove(ElecApproveInfo ElecApproveInfo)
        {
            return dal.insertElecApprove(ElecApproveInfo);
        }

        /// <summary>
        /// 전자 결재 상태 보기
        /// </summary>
        /// <param name="docCode"></param>
        /// <returns></returns>
        public ElecApproveInfo selectElecApproveStatus(String elecApproveCode)
        {
            return dal.selectElecApproveStatus(elecApproveCode);
        }


        
        /// <summary>
        /// 전자 결재 상태 보기
        /// </summary>
        /// <param name="docCode"></param>
        /// <returns></returns>
        public List<ElecStatusInfo> SelectStatus(String docCode)
        {
            return dal.SelectStatus(docCode);
        }

        public String ElecApproveKor(String decision)
        {
            String state="";

            if(decision=="A")
                state = "Phê duyệt (결재)";
            else if(decision=="C")
                state = "Thỏa thuận (합의)";
            else
                state = "Thông báo (통보) ";

            return state;
        }


	}
}
