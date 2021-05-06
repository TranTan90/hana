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
	/// 반출 물품
	/// </summary>
	public class TakeOutItemDataInfo
    {
		private int takeOutItemDataCode;
		private String takeOutDataCode;
		private int parentCategoryCode;
		private int subCategoryCode;
		private int unitCode;
		private String parentCodeName;
		private String subCodeName;
		private String takeOutItemName;
		private String takeOutItemType;
		private int account;
		private String unitName;
        private DateTime regDate;
        private String takeINTime; //반입일
        private String takeOutTime; //반출일
        private String inSecurityUserCode;
        private String inSecurityUserName;
        private String outSecurityUserCode;
        private String outSecurityUserName;

		public int TakeOutItemDataCode
		{
			get { return takeOutItemDataCode; }
			set { this.takeOutItemDataCode = value; }
		}

		public String TakeOutDataCode
		{
			get { return takeOutDataCode; }
			set { this.takeOutDataCode = value; }
		}

		public int ParentCategoryCode
		{
			get { return parentCategoryCode; }
			set { this.parentCategoryCode = value; }
		}

		public int SubCategoryCode
		{
			get { return subCategoryCode; }
			set { this.subCategoryCode = value; }
		}

		public int UnitCode
		{
			get { return unitCode; }
			set { this.unitCode = value; }
		}

		public String ParentCodeName
		{
			get { return parentCodeName; }
			set { this.parentCodeName = value; }
		}

		public String SubCodeName
		{
			get { return subCodeName; }
			set { this.subCodeName = value; }
		}

		public String TakeOutItemName
		{
			get { return takeOutItemName; }
			set { this.takeOutItemName = value; }
		}

		public String TakeOutItemType
		{
			get { return takeOutItemType; }
			set { this.takeOutItemType = value; }
		}

		public int Account
		{
			get { return account; }
			set { this.account = value; }
		}

		public String UnitName
		{
			get { return unitName; }
			set { this.unitName = value; }
		}

		public DateTime RegDate
		{
			get { return regDate; }
			set { this.regDate = value; }
		}

        public String TakeINTime
        {
            get { return takeINTime; }
            set { this.takeINTime = value; }
        }

        public String TakeOutTime
        {
            get { return takeOutTime; }
            set { this.takeOutTime = value; }
        }

        public String INSecurityUserCode
        {
            get { return inSecurityUserCode; }
            set { this.inSecurityUserCode = value; }
        }

        public String INSecurityUserName
        {
            get { return inSecurityUserName; }
            set { this.inSecurityUserName = value; }
        }

        public String OutSecurityUserCode
        {
            get { return outSecurityUserCode; }
            set { this.outSecurityUserCode = value; }
        }

        public String OutSecurityUserName
        {
            get { return outSecurityUserName; }
            set { this.outSecurityUserName = value; }
        }

        public String ToString()
        {
            StringBuilder str = new StringBuilder();

			str.Append("takeOutItemDataCode : " + takeOutItemDataCode.ToString() + "\n");
			str.Append("takeOutDataCode : " + takeOutDataCode.ToString() + "\n");
			str.Append("parentCategoryCode : " + parentCategoryCode.ToString() + "\n");
			str.Append("subCategoryCode : " + subCategoryCode.ToString() + "\n");
			str.Append("unitCode : " + unitCode.ToString() + "\n");
			str.Append("parentCodeName : " + parentCodeName + "\n");
			str.Append("subCodeName : " + subCodeName + "\n");
			str.Append("takeOutItemName : " + takeOutItemName + "\n");
			str.Append("takeOutItemType : " + takeOutItemType + "\n");
			str.Append("account : " + account + "\n");
			str.Append("unitName : " + unitName + "\n");
			str.Append("regDate : " + regDate + "\n");
            str.Append("takeINTime : " + takeINTime + "\n");
            str.Append("takeOutTime : " + takeOutTime + "\n");
            str.Append("inSecurityUserCode : " + inSecurityUserCode + "\n");
            str.Append("inSecurityUserName : " + inSecurityUserName + "\n");
            str.Append("outSecurityUserCode : " + outSecurityUserCode + "\n");
            str.Append("outSecurityUserName : " + outSecurityUserName + "\n");
            
            return str.ToString();
        }
    }
}