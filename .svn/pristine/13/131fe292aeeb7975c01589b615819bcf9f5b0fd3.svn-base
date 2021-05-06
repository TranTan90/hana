using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HanaMicron.COMS.BLL;
using HanaMicron.COMS.Model;
using HanaMicron.COMS.Utility;

public partial class admin_company_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		Company bll = new Company();
		CompanyInfo obj = new CompanyInfo();
		obj=bll.getCompany(Request["companyCode"]);
		obj.Approve = 1;
		int result=bll.updateCompany(obj);

		Page.RegisterClientScriptBlock("alert",JavaScriptBuilder.alert("Đã được đồng ý (승인 처리 하였습니다).","requestList.aspx"));
    }
    // 첫째 version: 아래 것이 없음
    //protected void Button1_Click(object sender, EventArgs e)
    //{

    //}
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{

    //}
}
