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
using System.Text;

public partial class main_visit_visitorEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
        VisitorData bll = new VisitorData();
        VisitorDataInfo obj = new VisitorDataInfo();

		if (Page.IsPostBack)
		{

            obj.VisitorDataCode = Convert.ToInt32(Request.QueryString["visitorDataCode"]);
            obj.CardNo = cardNo.Text;
            
            if (Request.QueryString["mode"].Equals("inTime"))
            {
                int result = bll.updateInTime(obj);
            }
            String key = HttpUtility.UrlEncode(Request.QueryString["key"]);
            Page.RegisterClientScriptBlock("alert", JavaScriptBuilder.selfCloseOpenerReload("Đã hoàn thành vào cổng (입문 처리 하였습니다).", "visitDataList.aspx?keyWord=" + Request.QueryString["keyWord"] + "&key=" + key + "&page=" + Request.QueryString["page"]));
        }
	}
}
