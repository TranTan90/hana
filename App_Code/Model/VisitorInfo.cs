using System;
using System.Collections.Generic;
using System.Text;

namespace HanaMicron.COMS.Model
{
	/// <summary>
	/// 내방객 정보
	/// </summary>
    public class VisitorInfo
    {
        private int visitorCode;
        private String visitorName;
        private String visitorPhone1;
        private String visitorPhone2;
        private String visitorPhone3;
        private String visitorRegNumber1;
        private String visitorRegNumber2;
        private String visitorPassportNumber;
        private int companyCode;
        private int reject;
        private String rejectContent;
        private DateTime regDate;
        private String companyName;
        private int visitorFlag;
        private String cardNo;

        // 2019-07-15-임종우 : ESD 교육이수 관련 컬럼 생성 (윤혜림과장 요청)
        private String esdFlag;
        private DateTime esdDate;

        public String CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        public int VisitorCode
        {
            get { return visitorCode; }
            set { visitorCode = value; }
        }

        public String VisitorName
        {
            get { return visitorName; }
            set { visitorName = value; }
        }
        
        public String VisitorPhone1
        {
            get { return visitorPhone1; }
            set { visitorPhone1 = value; }
        }
        
        public String VisitorPhone2
        {
            get { return visitorPhone2; }
            set { visitorPhone2 = value; }
        }
        
        public String VisitorPhone3
        {
            get { return visitorPhone3; }
            set { visitorPhone3 = value; }
        }
        
        public String VisitorRegNumber1
        {
            get { return visitorRegNumber1; }
            set { visitorRegNumber1 = value; }
        }
        
        public String VisitorRegNumber2
        {
            get { return visitorRegNumber2; }
            set { visitorRegNumber2 = value; }
        }

        public String VisitorPassportNumber
        {
            get { return visitorPassportNumber; }
            set { visitorPassportNumber = value; }
        }

        public int CompanyCode
        {
            get { return companyCode; }
            set { companyCode = value; }
        }
        
        public int Reject
        {
            get { return reject; }
            set { reject = value; }
        }
        
        public String RejectContent
        {
            get { return rejectContent; }
            set { rejectContent = value; }
        }

        public DateTime RegDate
        {
            get { return regDate; }
            set { regDate = value; }
        }

        public int VisitorFlag
        {
            get { return visitorFlag; }
            set { visitorFlag = value; }
        }

        public String CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }

        public String EsdFlag
        {
            get { return esdFlag; }
            set { esdFlag = value; }
        }

        public DateTime EsdDate
        {
            get { return esdDate; }
            set { esdDate = value; }
        }

        public String ToString()
        {
            StringBuilder str = new StringBuilder();
            
            str.Append("visitorCode : " + visitorCode + "\n");
            str.Append("visitorName : " + visitorName + "\n");
            str.Append("visitorPhone1 : " + visitorPhone1 + "\n");
            str.Append("visitorPhone2 : " + visitorPhone2 + "\n");
            str.Append("visitorPhone3 : " + visitorPhone3 + "\n");
            str.Append("visitorRegNumber1 : " + visitorRegNumber1 + "\n");
            str.Append("visitorRegNumber2 : " + visitorRegNumber2 + "\n");
            str.Append("companyCode : " + companyCode + "\n");
            str.Append("reject : " + reject + "\n");
            str.Append("rejectContent : " + rejectContent + "\n");
            str.Append("regDate : " + regDate + "\n");
            str.Append("companyName : " + companyName + "\n");
            str.Append("cardNo : " + cardNo + "\n");
            str.Append("esdFlag : " + esdFlag + "\n");
            str.Append("esdDate : " + esdDate + "\n");
  
            return str.ToString();
        }

    }
}
