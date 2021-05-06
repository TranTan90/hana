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
	public class SecCardDataInfo
    {
        private int secDataCode; 
        private String regDate; //등록 날짜
		private String requestUserCode ; //요청자 사번
        private String requestUserName; //요청자 이름
		private String requestDepCode ; //요청자 부서코드
		private String requestDepDesc ; //요청부서
		private String roleCode ; //요청자 직급코드
        private String roleDesc; //요청자 직급
     	private String officePhone ; //요청자 내선번호
		private String comment ; // 요청 사유
        private String reqDateFrom ; //요청기간 From
        private String reqDateEnd; // 요청기간 To
        private int flag; // 보안카드 요청 구분 1/신규등록, 2/변경
		private int approvalState; //전자결재 상태
        private DateTime approveTime; //전자결재시간
		private String elecApproveCode ; //전자결재 코드
	
		public int SecDataCode
		{
            get { return secDataCode; }
            set { this.secDataCode = value; }
		}

        public String RegDate
		{
            get { return regDate; }
            set { this.regDate = value; }
		}

        public String RequestUserCode
		{
            get { return requestUserCode; }
            set { this.requestUserCode = value; }
		}

        public String RequestUserName
		{
			get { return requestUserName; }
			set { this.requestUserName = value; }
		}

        public String RequestDepCode
		{
            get { return requestDepCode; }
            set { this.requestDepCode = value; }
		}

        public String RequestDepDesc
		{
            get { return requestDepDesc; }
            set { this.requestDepDesc = value; }
		}

        public String RoleCode
		{
            get { return roleCode; }
            set { this.roleCode = value; }
		}

        public String RoleDesc
		{
            get { return roleDesc; }
            set { this.roleDesc = value; }
		}

        public String OfficePhone
		{
            get { return officePhone; }
            set { this.officePhone = value; }
		}

        public String Comment
        {
            get { return comment; }
            set { this.comment = value; }
        }

        public String ReqDateFrom
		{
            get { return reqDateFrom; }
            set { this.reqDateFrom = value; }
		}

        public String ReqDateEnd
		{
            get { return reqDateEnd; }
            set { this.reqDateEnd = value; }
		}

        public int Flag
		{
            get { return flag; }
            set { this.flag = value; }
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

        public String ElecApproveCode
		{
            get { return elecApproveCode; }
            set { this.elecApproveCode = value; }
		}

        public String ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append("secDataCode : " + secDataCode + "\n");
            str.Append("regDate : " + regDate + "\n");
            str.Append("requestUserCode  : " + requestUserCode + "\n");
            str.Append("requestUserName : " + requestUserName + "\n");
            str.Append("requestDepCode  : " + requestDepCode + "\n");
            str.Append("requestDepDesc  : " + requestDepDesc + "\n");
            str.Append("roleCode  : " + roleCode + "\n");
            str.Append("roleDesc : " + roleDesc + "\n");
            str.Append("officePhone  : " + officePhone + "\n");
            str.Append("comment : " + comment + "\n");
            str.Append("reqDateFrom  : " + reqDateFrom + "\n");
            str.Append("reqDateEnd : " + reqDateEnd + "\n");
            str.Append("flag : " + flag + "\n");
            str.Append("approvalState : " + approvalState + "\n");
            str.Append("approveTime : " + approveTime + "\n");
            str.Append("elecApproveCode  : " + elecApproveCode + "\n");
		    return str.ToString();
        }
    }
}