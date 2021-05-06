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

public partial class main_visit_regCheckVisitor : System.Web.UI.Page
{
    public String searchResult;
    protected void Page_Load(object sender, EventArgs e)
    {
        Visitor bll = new Visitor();
        VisitorInfo obj = new VisitorInfo();

        obj = bll.getVisitor(Request.QueryString["regNumber1"], Request.QueryString["regNumber2"]);
        //if (exists) searchResult = "1";
        //else searchResult = "0";
        searchResult = obj.VisitorCode.ToString() + ":|:" + obj.VisitorName + ":|:" + obj.Reject + ":|:" + obj.RejectContent;
    }
}
