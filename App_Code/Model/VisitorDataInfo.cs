using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;

/// <summary>
/// Model Object
/// </summary>
namespace HanaMicron.COMS.Model
{
	/// <summary>
	/// 내방 정보
	/// </summary>
    public class VisitorDataInfo
    {
		private VisitorInfo visitorInfo;
		private int visitorDataCode;
		private int visitDataCode;
		private CompanyInfo companyInfo;
		private String visitDate;
		private String inTime;
		private String outTime;
		private DateTime regDate;
        private String cardNo;

		public VisitorInfo VisitorInfo
		{
			get { return visitorInfo; }
			set { visitorInfo = value; }
		}

		public int VisitorDataCode
		{
			get { return visitorDataCode; }
			set { visitorDataCode = value; }
		}

		public int VisitDataCode
		{
			get { return visitDataCode; }
			set { visitDataCode = value; }
		}

		public CompanyInfo CompanyInfo
		{
			get { return companyInfo; }
			set { companyInfo = value; }
		}

		public String VisitDate
		{
			get { return visitDate; }
			set { visitDate = value; }
		}

		public String InTime
		{
			get { return inTime; }
			set { inTime = value; }
		}

		public String OutTime
		{
			get { return outTime; }
			set { outTime = value; }
		}

		public DateTime RegDate
		{
			get { return regDate; }
			set { regDate = value; }
		}

        public String CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }


    }
}