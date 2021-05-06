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

public partial class main_takeOut_userFileDeleteTakeOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		TakeOutData bll = new TakeOutData();

		bll.DeleteUserFile(Request.QueryString["takeOutDataCode"], Request.QueryString["fileNumber"],Request.QueryString["fileName"]);

        Response.Redirect("inputTakeOut.aspx?takeOutDataCode=" + Request.QueryString["takeOutDataCode"] + "&mode=modify");
    }
}