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

public partial class elecApprove_updateVisitApproveState : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		String approveState;
		String status = Request.QueryString["status"];
		String elecApproveCode = Request.QueryString["doc_code"];

		if (status.Equals("R")) approveState = "3";
		else if (status.Equals("F")) approveState = "2";
		else approveState = "1";

		VisitData bll = new VisitData();
		bll.UpdateApprove(elecApproveCode, approveState);
    }
}