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

public partial class main_security_Default : System.Web.UI.Page
{
	public String url;
    protected void Page_Load(object sender, EventArgs e)
    {
		//url = "visitDataList.aspx?keyWord=companyName&key=" + HttpUtility.UrlEncode("세안") + "&page=0";
		url = "visitDataList.aspx?keyWord=companyName&key=" + HttpUtility.UrlEncode(Request.QueryString["key"]) + "&page=0";
		//url = "visitDataList.aspx?keyWord=companyName&key=" + Request.QueryString["key"] + "&page=0";
    }
}
