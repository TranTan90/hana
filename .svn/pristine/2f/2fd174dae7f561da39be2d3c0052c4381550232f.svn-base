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
    public class TakeOutPathStartInfo
    {
		private int takeOutPathStartCode;
		private String takeOutPathStartName;
        private DateTime regDate;
        private String status;

		public int TakeOutPathStartCode
		{
			get { return takeOutPathStartCode; }
			set { this.takeOutPathStartCode = value; }
		}

		public String TakeOutPathStartName
        {
			get { return this.takeOutPathStartName; }
			set { this.takeOutPathStartName = value; }
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

			str.Append("takeOutPathStartCode : " + takeOutPathStartCode.ToString() + "\n");
			str.Append("takeOutPathStartName : " + takeOutPathStartName + "\n");
			str.Append("regDate : " + regDate + "\n");
            str.Append("status : " + status + "\n");
            
            return str.ToString();
        }
    }
}