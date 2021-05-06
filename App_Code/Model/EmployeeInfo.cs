using System;
using System.Collections.Generic;
using System.Text;

namespace HanaMicron.COMS.Model
{
    public class EmployeeInfo
    {
        private String upnid;
        private String sn;
        private String givenName;
        private String description;
        private String displayName;
        private String officeName;
        private String officePhoneNumber;
        private String emailAddress;
        private String homePage;
        private String country;
        private String city;
        private String state;
        private String address;
        private String zipcode;
        private String homePhoneNumber;
        private String mobilePhoneNumber;
        private String faxPhoneNumber;
        private String memo;
        private String title;
        private String department;
        private String company;
        private String mailBoxUrl;
        private String upnpwd;
        private String job_state;
        private String reg_type;
        private String reg_date;
        private String dep_name;
        private String title_name;
		private Boolean isAdmin;
		private int managerLevel;

        public String Upnid
        {
            get { return upnid; }
            set { upnid = value; }
        }

        public String Sn
        {
            get { return sn; }
            set { sn = value; }
        }

        public String GivenName
        {
            get { return givenName; }
            set { givenName = value; }
        }

        public String DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public String OfficeName
        {
            get { return officeName; }
            set { officeName = value; }
        }

        public String OfficePhoneNumber
        {
            get { return officePhoneNumber; }
            set { officePhoneNumber = value; }
        }

        public String EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        public String HomePage
        {
            get { return homePage; }
            set { homePage = value; }
        }

        public String Country
        {
            get { return country; }
            set { country = value; }
        }

        public String City
        {
            get { return city; }
            set { city = value; }
        }

        public String State
        {
            get { return state; }
            set { state = value; }
        }

        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        public String Zipcode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }

        public String HomePhoneNumber
        {
            get { return homePhoneNumber; }
            set { homePhoneNumber = value; }
        }

        public String MobilePhoneNumber
        {
            get { return mobilePhoneNumber; }
            set { mobilePhoneNumber = value; }
        }

        public String FaxPhoneNumber
        {
            get { return faxPhoneNumber; }
            set { faxPhoneNumber = value; }
        }

        public String Memo
        {
            get { return memo; }
            set { memo = value; }
        }

        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        public String Department
        {
            get { return department; }
            set { department = value; }
        }

        public String Company
        {
            get { return company; }
            set { company = value; }
        }

        public String MailBoxUrl
        {
            get { return mailBoxUrl; }
            set { mailBoxUrl = value; }
        }

        public String Upnpwd
        {
            get { return upnpwd; }
            set { upnpwd = value; }
        }

        public String Job_state
        {
            get { return job_state; }
            set { job_state = value; }
        }

        public String Reg_type
        {
            get { return reg_type; }
            set { reg_type = value; }
        }

        public String Reg_date
        {
            get { return reg_date; }
            set { reg_date = value; }
        }

        public String Dep_name
        {
            get { return dep_name; }
            set { dep_name = value; }
        }

        public String Title_name
        {
            get { return title_name; }
            set { title_name = value; }
        }

		public Boolean ISAdmin
		{
			get { return isAdmin; }
			set { isAdmin = value; }
		}

		public int ManagerLevel
		{
			get { return managerLevel; }
			set { managerLevel = value; }
		}

        public String ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append("upnid : " + upnid + "\n");
            str.Append("sn : " + sn + "\n");
            str.Append("givenName : " + givenName + "\n");
            str.Append("description : " + description + "\n");
            str.Append("displayName : " + displayName + "\n");
            str.Append("officeName : " + officeName + "\n");
            str.Append("officePhoneNumber : " + officePhoneNumber + "\n");
            str.Append("emailAddress : " + emailAddress + "\n");
            str.Append("homePage : " + homePage + "\n");
            str.Append("country : " + country + "\n");
            str.Append("city : " + city + "\n");
            str.Append("state : " + state + "\n");
            str.Append("address : " + address + "\n");
            str.Append("zipcode : " + zipcode + "\n");
            str.Append("homePhoneNumber : " + homePhoneNumber + "\n");
            str.Append("mobilePhoneNumber : " + mobilePhoneNumber + "\n");
            str.Append("faxPhoneNumber : " + faxPhoneNumber + "\n");
            str.Append("memo : " + memo + "\n");
            str.Append("title : " + title + "\n");
            str.Append("department : " + department + "\n");
            str.Append("company : " + company + "\n");
            str.Append("mailBoxUrl : " + mailBoxUrl + "\n");
            str.Append("upnpwd : " + upnpwd + "\n");
            str.Append("job_state : " + job_state + "\n");
            str.Append("reg_type : " + reg_type + "\n");
            str.Append("reg_date : " + reg_date + "\n");
            str.Append("dep_name : " + dep_name + "\n");
            str.Append("title_name : " + title_name + "\n");
            str.Append("isAdmin : " + isAdmin + "\n");
            str.Append("managerLevel : " + managerLevel + "\n");

            return str.ToString();
        }
    }
}
