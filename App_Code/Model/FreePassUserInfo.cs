using System;
using System.Collections.Generic;
using System.Text;

namespace HanaMicron.COMS.Model
{
	public class FreePassUserInfo
	{
		private String upnid;
		private String displayName;
        private String dep_name;
		


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

        public String Dep_name
        {
            get { return dep_name; }
            set { dep_name = value; }
        }

		

        public String ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append("upnid : " + upnid + "\n");
            str.Append("displayName : " + displayName + "\n");
            str.Append("dep_name : " + dep_name + "\n");
            return str.ToString();
        }
	}
}
