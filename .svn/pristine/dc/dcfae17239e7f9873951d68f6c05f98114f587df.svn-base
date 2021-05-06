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
	/// 반출 목적
	/// </summary>
    public class TakeOutObjectInfo
    {
        private int takeOutObjectCode;
        private String codeName;
        private DateTime regDate;
        private String status;

		public int TakeOutObjectCode
		{
			get { return takeOutObjectCode; }
			set { this.takeOutObjectCode = value; }
		}
        public DateTime RegDate
		{
            get{return this.regDate;}
            set{this.regDate=value;}
        }

        public String CodeName
        {
			get { return this.codeName; }
			set { this.codeName = value; }
        }

        public String Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public String ToString()
        {
            StringBuilder str = new StringBuilder();

			str.Append("takeOutObjectCode : " + takeOutObjectCode.ToString() + "\n");
			str.Append("codeName : " + codeName + "\n");
			str.Append("regDate : " + regDate + "\n");
            str.Append("status : " + status + "\n");
            
            return str.ToString();
        }
    }
}