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

public partial class main_visit_userFileDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		VisitData bll = new VisitData();

		bll.DeleteUserFile(Request.QueryString["visitDataCode"], Request.QueryString["fileNumber"],Request.QueryString["fileName"]);

		Response.Redirect("inputVisit.aspx?visitDataCode=" + Request.QueryString["visitDataCode"] + "&mode=modify");
    }
}