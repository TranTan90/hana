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
	public class TakeOutDataInfo
    {
		private String takeOutDataCode;
		private int companyCode; //수령회사코드
		private String companyName; //수령 회사 이름
		private String recieveName; //수령자
		private String requestUserCode; //요청자 코드
		private String requestUserDepartment; //요청부서
		private String requestUserDisplayName; //요청자 이름
		private int requireIN; //반입여부(반입필:1, 반입불가:2)
        private List<TakeOutItemDataInfo> takeOutItemDataList; //반출항목                
		private String objectContents; //반출세부 목적
		private String scheduleInDate; //반입 예정일
        private String scheduleOutDate; //반출 예정일
		private int takeOutStateCode; 
		private int takeOutObjectCode;
		private String takeOutObjectName;
		private String approvalUserCode;
		private String approvalDisplayName;
		private int approvalState; //전자결재 상태
		private int takeOutPathStartCode; //반출경로코드(시작점)
		private String takeOutPathStartName; //반출경로명(시작점)
		private int takeOutPathEndCode; //반출경로코드(종료점)
		private String takeOutPathEndName; //반출경로명(종료점)
		private int disApprovalCategoryCode; //반입불가 코드
		private String disApprovalCategoryName; //반입불가명
		private String disApprovalCategoryDetail; //반입불가 세부 사유
		private DateTime approveTime; //결재시간
		private String approveContents; 
        private String elecApproveCode; //전자결재 코드
		private DateTime regDate; //등록일
		private int carCode; //차량코드
		private String carNumber; //차량번호
		private String requestUserTitleName; //요청자직급
		private String requestUserOfficeName; //요청자부서명
        private String userFile1; // 첨부 파일 1
        private String userFile2; // 첨부 파일 2        
        private String userFile3; // 첨부 파일 3
        private String note; // 비고

		public String TakeOutDataCode
		{
			get { return takeOutDataCode; }
			set { this.takeOutDataCode = value; }
		}

		public int CompanyCode
		{
			get { return companyCode; }
			set { this.companyCode = value; }
		}

		public String CompanyName
		{
			get { return companyName; }
			set { this.companyName = value; }
		}

		public String RecieveName
		{
			get { return recieveName; }
			set { this.recieveName = value; }
		}

		public String RequestUserCode
		{
			get { return requestUserCode; }
			set { this.requestUserCode = value; }
		}

		public String RequestUserDepartment
		{
			get { return requestUserDepartment; }
			set { this.requestUserDepartment = value; }
		}

		public String RequestUserDisplayName
		{
			get { return requestUserDisplayName; }
			set { this.requestUserDisplayName = value; }
		}

		public int RequireIN
		{
			get { return requireIN; }
			set { this.requireIN = value; }
		}

        public List<TakeOutItemDataInfo> TakeOutItemDataList
        {
            get { return takeOutItemDataList; }
            set { takeOutItemDataList = value; }
        }

		public String ObjectContents
		{
			get { return objectContents; }
			set { this.objectContents = value; }
		}

		public String ScheduleInDate
		{
			get { return scheduleInDate; }
			set { this.scheduleInDate = value; }
		}

        public String ScheduleOutDate
        {
            get { return scheduleOutDate; }
            set { this.scheduleOutDate = value; }
        }

		public int TakeOutStateCode
		{
			get { return takeOutStateCode; }
			set { this.takeOutStateCode = value; }
		}

		public int TakeOutObjectCode
		{
			get { return takeOutObjectCode; }
			set { this.takeOutObjectCode = value; }
		}

		public String TakeOutObjectName
		{
			get { return takeOutObjectName; }
			set { this.takeOutObjectName = value; }
		}

		public String ApprovalUserCode
		{
			get { return approvalUserCode; }
			set { this.approvalUserCode = value; }
		}

		public String ApprovalDisplayName
		{
			get { return approvalDisplayName; }
			set { this.approvalDisplayName = value; }
		}

		public int ApprovalState
		{
			get { return approvalState; }
			set { this.approvalState = value; }
		}

		public int TakeOutPathStartCode
		{
			get { return takeOutPathStartCode; }
			set { this.takeOutPathStartCode = value; }
		}

		public String TakeOutPathStartName
		{
			get { return takeOutPathStartName; }
			set { this.takeOutPathStartName = value; }
		}

		public int TakeOutPathEndCode
		{
			get { return takeOutPathEndCode; }
			set { this.takeOutPathEndCode = value; }
		}

		public String TakeOutPathEndName
		{
			get { return takeOutPathEndName; }
			set { this.takeOutPathEndName = value; }
		}

		public int DisApprovalCategoryCode
		{
			get { return disApprovalCategoryCode; }
			set { this.disApprovalCategoryCode = value; }
		}

		public String DisApprovalCategoryName
		{
			get { return disApprovalCategoryName; }
			set { this.disApprovalCategoryName = value; }
		}

		public String DisApprovalCategoryDetail
		{
			get { return disApprovalCategoryDetail; }
			set { this.disApprovalCategoryDetail = value; }
		}
        
		public DateTime ApproveTime
		{
			get { return approveTime; }
			set { this.approveTime = value; }
		}

		public String ApproveContents
		{
			get { return approveContents; }
			set { this.approveContents = value; }
		}

        public String ElecApproveCode
        {
            get { return elecApproveCode; }
            set { elecApproveCode = value; }
        }

		public DateTime RegDate
		{
			get { return regDate; }
			set { this.regDate = value; }
		}

		public int CarCode
		{
			get { return carCode; }
			set { this.carCode = value; }
		}

		public String CarNumber
		{
			get { return carNumber; }
			set { this.carNumber = value; }
		}

		public String RequestUserTitleName
		{
			get { return requestUserTitleName; }
			set { this.requestUserTitleName = value; }
		}

		public String RequestUserOfficeName
		{
			get { return requestUserOfficeName; }
			set { this.requestUserOfficeName = value; }
		}

        public String UserFile1
        {
            get { return userFile1; }
            set { userFile1 = value; }
        }

        public String UserFile2
        {
            get { return userFile2; }
            set { userFile2 = value; }
        }

        public String UserFile3
        {
            get { return userFile3; }
            set { userFile3 = value; }
        }


        public String Note
        {
            get { return note; }
            set { note = value; }
        }

        public String ToString()
        {
            StringBuilder str = new StringBuilder();

			str.Append("takeOutDataCode : " + takeOutDataCode + "\n");
			str.Append("companyCode : " + companyCode.ToString() + "\n");
			str.Append("companyName : " + companyName + "\n");
			str.Append("recieveName : " + recieveName + "\n");
			str.Append("requestUserCode : " + requestUserCode + "\n");
			str.Append("requestUserDepartment : " + requestUserDepartment + "\n");
			str.Append("requestUserDisplayName : " + requestUserDisplayName + "\n");
			str.Append("requireIN : " + requireIN + "\n");
			str.Append("objectContents : " + objectContents + "\n");
			str.Append("scheduleInDate : " + scheduleInDate + "\n");
            str.Append("scheduleOutDate : " + scheduleOutDate + "\n");
			str.Append("takeOutStateCode : " + takeOutStateCode + "\n");
			str.Append("takeOutObjectCode : " + takeOutObjectCode + "\n");
			str.Append("takeOutObjectName : " + takeOutObjectName + "\n");
			str.Append("approvalUserCode : " + approvalUserCode + "\n");
			str.Append("approvalDisplayName : " + approvalDisplayName + "\n");
			str.Append("approvalState : " + approvalState + "\n");
			str.Append("takeOutPathStartCode : " + takeOutPathStartCode + "\n");
			str.Append("takeOutPathStartName : " + takeOutPathStartName + "\n");
			str.Append("takeOutPathEndCode : " + takeOutPathEndCode + "\n");
			str.Append("takeOutPathEndName : " + takeOutPathEndName + "\n");
			str.Append("disApprovalCategoryCode : " + disApprovalCategoryCode + "\n");
			str.Append("disApprovalCategoryName : " + disApprovalCategoryName + "\n");
			str.Append("disApprovalCategoryDetail : " + disApprovalCategoryDetail + "\n");
			str.Append("approveTime : " + approveTime + "\n");
			str.Append("approveContents : " + approveContents + "\n");
			str.Append("regDate : " + regDate + "\n");
			str.Append("carCode : " + carCode + "\n");
			str.Append("carNumber : " + carNumber + "\n");
			str.Append("requestUserTitleName : " + requestUserTitleName + "\n");
            str.Append("requestUserOfficeName : " + requestUserOfficeName + "\n");
            str.Append("userFile1 : " + userFile1 + "\n");
            str.Append("userFile2 : " + userFile2 + "\n");
            str.Append("userFile3 : " + userFile3 + "\n");
            
            return str.ToString();
        }
    }
}