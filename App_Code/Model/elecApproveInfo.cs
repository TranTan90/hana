using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// Model Object
/// </summary>
namespace HanaMicron.COMS.Model
{
	/// <summary>
	/// 반출 정보
	/// </summary>
	public class ElecApproveInfo
    {
        private String elecApproveCode; //전자결재 코드
		private int approvalState; //전자결재 상태
        private DateTime approveTime; //전자결재시간

        public String ElecApproveCode
        {
            get { return elecApproveCode; }
            set { this.elecApproveCode = value; }
        }
	
        public int ApprovalState
		{
            get { return approvalState; }
            set { this.approvalState = value; }
		}

        public DateTime ApproveTime
		{
            get { return approveTime; }
            set { this.approveTime = value; }
		}

    

        public String ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append("elecApproveCode  : " + elecApproveCode + "\n");
            str.Append("approvalState : " + approvalState + "\n");
            str.Append("approveTime : " + approveTime + "\n");
          
		    return str.ToString();
        }
    }
}