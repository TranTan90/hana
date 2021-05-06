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
	/// 사무실 정보
	/// </summary>
    public class OfficeInfo
    {
        private int officeCode;
        private String officeName;
        private DateTime regDate;
        private String status;

		public int OfficeCode
		{
			get { return officeCode; }
			set { officeCode = value; }
        }

		public String OfficeName
        {
			get { return officeName; }
			set { officeName = value; }
        }

        public DateTime RegDate{
            get{return regDate;}
            set{regDate=value;}
        }

        public String Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public String ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append("officeCode : " + officeCode + "\n");
            str.Append("officeName : " + officeName + "\n");
            str.Append("regDate : " + regDate + "\n");
            str.Append("status : " + status + "\n");

            return str.ToString();
        }
    }
}