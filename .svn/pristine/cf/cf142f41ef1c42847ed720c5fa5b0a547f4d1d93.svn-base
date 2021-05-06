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
	/// 반출 시작 지점
	/// </summary>
    public class TakeOutPathEndInfo
    {
		private int takeOutPathEndCode;
		private String takeOutPathEndName;
        private DateTime regDate;
        private String status;

		public int TakeOutPathEndCode
		{
			get { return takeOutPathEndCode; }
			set { this.takeOutPathEndCode = value; }
		}

		public String TakeOutPathEndName
        {
			get { return this.takeOutPathEndName; }
			set { this.takeOutPathEndName = value; }
        }

		public DateTime RegDate
		{
			get { return regDate; }
			set { this.regDate = value; }
		}

        public String Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public String ToString()
        {
            StringBuilder str = new StringBuilder();

			str.Append("takeOutPathEndCode : " + takeOutPathEndCode.ToString() + "\n");
			str.Append("takeOutPathEndName : " + takeOutPathEndName + "\n");
			str.Append("regDate : " + regDate + "\n");
            str.Append("status : " + status + "\n");
            
            return str.ToString();
        }
    }
}