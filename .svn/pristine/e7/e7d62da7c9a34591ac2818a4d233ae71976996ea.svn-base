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

public partial class main_visit_viewTime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		VisitData bll = new VisitData();
		VisitDataInfo visitDataInfo = bll.selectVisitData(Request.QueryString["visitDataCode"]);

		VisitorData bllVisitorData = new VisitorData();
		VisitorDataInfo visitorDataInfo = bllVisitorData.selectVisitorData(Request.QueryString["visitorDataCode"]);

		lblRegDate.Text = visitDataInfo.RegDate.ToString();
		lblApproveTime.Text = visitDataInfo.ApproveTime.ToString();
		lblINTime.Text = visitorDataInfo.InTime;
		lblOutTime.Text = visitorDataInfo.OutTime;
    }
}
