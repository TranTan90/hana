using System;
using System.Collections.Generic;
using System.Text;

namespace HanaMicron.COMS.Model
{
	/// <summary>
	/// 내방객 정보
	/// </summary>
    public class VisitObjectInfo
    {
		private int visitObjectCode;
		private String visitObjectName;
		private DateTime regDate;
        private String status;


		public int VisitObjectCode
        {
			get { return visitObjectCode; }
			set { visitObjectCode = value; }
        }

		public String VisitObjectName
        {
			get { return visitObjectName; }
			set { visitObjectName = value; }
        }
        
        public DateTime RegDate
        {
            get { return regDate; }
            set { regDate = value; }
        }

        public String Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public String ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append("visitObjectCode : " + visitObjectCode + "\n");
            str.Append("visitObjectName : " + visitObjectName + "\n");
            str.Append("regDate : " + regDate + "\n");
            str.Append("status : " + status + "\n");

            return str.ToString();
        }

    }
}
