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
    /// 내방 정보
    /// </summary>
    public class VisitDataInfo
    {
        private int visitDataCode; // 내방 코드
        private DateTime regDate; // 내방 등록일
        private String visitObjectContents; // 내방 세부 내용
        private String officeContents; // 상세 방문실

		private OfficeInfo officeInfo; // 사업장
		private VisitObjectInfo visitObjectInfo; // 내방 목적
		private List<VisitorDataInfo> visitorDataInfoList; // 내방자 목록
		private CarDataInfo carDataInfo; // 차량 정보

		private EmployeeInfo reqEmployeeInfo; // 신청자 임직원 정보
		private EmployeeInfo interviewEmployeeInfo; // 접견자 임직원 정보
		private EmployeeInfo inSecurityEmployeeInfo; // 입문 처리자 임직원 정보
		private EmployeeInfo outSecurityEmployeeInfo; // 출문 처리자 임직원 정보
        
        private int approvalState; // 결재 상태 코드
        private String approveContents; // 결재 내용
        private DateTime approveTime; // 결재 시간
		private String elecApproveCode; // 전자결재 연동 코드
		private String userFile1; // 첨부 파일 1
		private String userFile2; // 첨부 파일 2
		private String userFile3; // 첨부 파일 3
        private int visitFlag; // 장기 내방 여부 코드
        private String startDate; // 장기 내방 시작일
        private String endDate; // 장기 내방 종료일
        private int longVisitDataCode; // 장기 내방 코드
        private String cardNo; // 내방객 Card No.
     
		public int VisitDataCode
		{
			get { return visitDataCode; }
			set { visitDataCode = value; }
		}

		public DateTime RegDate
		{
			get { return regDate; }
			set { regDate = value; }
		}

		public String VisitObjectContents
		{
			get { return visitObjectContents; }
			set { visitObjectContents = value; }
		}

		public String OfficeContents
		{
			get { return officeContents; }
			set { officeContents = value; }
		}

		public OfficeInfo OfficeInfo
		{
			get { return officeInfo; }
			set { officeInfo = value; }
		}

		public VisitObjectInfo VisitObjectInfo
		{
			get { return visitObjectInfo; }
			set { visitObjectInfo = value; }
		}

		public List<VisitorDataInfo> VisitorDataInfoList
		{
			get { return visitorDataInfoList; }
			set { visitorDataInfoList = value; }
		}

		public CarDataInfo CarDataInfo
		{
			get { return carDataInfo; }
			set { carDataInfo = value; }
		}

		public EmployeeInfo ReqEmployeeInfo
		{
			get { return reqEmployeeInfo; }
			set { reqEmployeeInfo = value; }
		}

		public EmployeeInfo InterviewEmployeeInfo
		{
			get { return interviewEmployeeInfo; }
			set { interviewEmployeeInfo = value; }
		}

		public EmployeeInfo InSecurityEmployeeInfo
		{
			get { return inSecurityEmployeeInfo; }
			set { inSecurityEmployeeInfo = value; }
		}

		public EmployeeInfo OutSecurityEmployeeInfo
		{
			get { return outSecurityEmployeeInfo; }
			set { outSecurityEmployeeInfo = value; }
		}

		public int ApprovalState
		{
			get { return approvalState; }
			set { approvalState = value; }
		}

		public String ApproveContents
		{
			get { return approveContents; }
			set { approveContents = value; }
		}

		public DateTime ApproveTime
		{
			get { return approveTime; }
			set { approveTime = value; }
		}

		public String ElecApproveCode
		{
			get { return elecApproveCode; }
			set { elecApproveCode = value; }
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

        public int VisitFlag
        {
            get { return visitFlag; }
            set { visitFlag = value; }
        }

        public String StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public String EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public int LongVisitDataCode
        {
            get { return longVisitDataCode; }
            set { longVisitDataCode = value; }
        }

        public String CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }

    }
}