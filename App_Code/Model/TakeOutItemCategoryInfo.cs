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
    public class TakeOutItemCategoryInfo
    {
		private int takeOutItemCategoryCode;
		private String codeName;
        private DateTime regDate;
		private int depthID;
		private int groupID;

		public int TakeOutItemCategoryCode
		{
			get { return takeOutItemCategoryCode; }
			set { this.takeOutItemCategoryCode = value; }
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

		public int DepthID
		{
			get { return this.depthID; }
			set { this.depthID = value; }
		}

		public int GroupID
		{
			get { return this.groupID; }
			set { this.groupID = value; }
		}

        public String ToString()
        {
            StringBuilder str = new StringBuilder();

			str.Append("takeOutItemCategoryCode : " + takeOutItemCategoryCode.ToString() + "\n");
			str.Append("codeName : " + codeName + "\n");
			str.Append("regDate : " + regDate + "\n");
			str.Append("depthID : " + depthID.ToString() + "\n");
			str.Append("groupID : " + groupID.ToString() + "\n");
            
            return str.ToString();
        }
    }
}