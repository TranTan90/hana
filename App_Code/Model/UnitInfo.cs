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
	public class UnitInfo
    {
		private int unitCode;
		private String codeName;
        private DateTime regDate;
        private String status;

		public int UnitCode
		{
			get { return unitCode; }
			set { this.unitCode = value; }
		}

		public String CodeName
        {
			get { return this.codeName; }
			set { this.codeName = value; }
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

			str.Append("unitCode : " + unitCode.ToString() + "\n");
			str.Append("codeName : " + codeName + "\n");
			str.Append("regDate : " + regDate + "\n");
            str.Append("status : " + status + "\n");
            
            return str.ToString();
        }
    }
}