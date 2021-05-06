using System;
using System.Collections.Generic;
using System.Text;

namespace HanaMicron.COMS.Model
{
    public class DepartmentInfo
    {
        private String dep_code;
        private String dep_name;
		private int level_no;
        private String view_seq;
		private int del_flag;
        private String reg_date;

        public String Dep_code
        {
            get { return dep_code; }
            set { dep_code = value; }
        }

        public String Dep_name
        {
            get { return dep_name; }
            set { dep_name = value; }
        }

		public int Level_no
        {
            get { return level_no; }
            set { level_no = value; }
        }

		public String View_seq
        {
            get { return view_seq; }
            set { view_seq = value; }
        }

		public int Del_flag
        {
            get { return del_flag; }
            set { del_flag = value; }
        }

        public String Reg_date
        {
            get { return reg_date; }
            set { reg_date = value; }
        }

        public String ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append("dep_code : " + dep_code + "\n");
            str.Append("dep_name : " + dep_name + "\n");
            str.Append("level_no : " + level_no + "\n");
            str.Append("view_seq : " + view_seq + "\n");
            str.Append("del_flag : " + del_flag + "\n");
            str.Append("reg_date : " + reg_date + "\n");

            return str.ToString();
        }

    }
}
