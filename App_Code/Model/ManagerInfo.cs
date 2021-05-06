using System;
using System.Collections.Generic;
using System.Text;

namespace HanaMicron.COMS.Model
{
	public class ManagerInfo
	{
		private String upnid;
		private String displayName;
		private int managerLevel;
		private DateTime regDate;


		public String Upnid
		{
			get { return upnid; }
			set { upnid = value; }
		}

		public String DisplayName
		{
			get { return displayName; }
			set { displayName = value; }
		}

		public int ManagerLevel
		{
			get { return managerLevel; }
			set { managerLevel = value; }
		}

		public DateTime Regdate
		{
			get { return regDate; }
			set { regDate = value; }
		}

        public String ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append("upnid : " + upnid + "\n");
            str.Append("displayName : " + displayName + "\n");
            str.Append("managerLevel : " + managerLevel + "\n");
            str.Append("regDate : " + regDate + "\n");

            return str.ToString();
        }
	}
}
