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
using HanaMicron.COMS.Model;
using HanaMicron.COMS.BLL;
using HanaMicron.COMS.Utility;
using System.Text;

public partial class main_visit_timeUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 2019-07-15-임종우 : ESD 교육이수 정보 처리
        if (Request.QueryString["mode"].Equals("esdTime"))
        {
            Visitor bll = new Visitor();
            VisitorInfo obj = new VisitorInfo();

            obj.VisitorCode = Convert.ToInt32(Request.QueryString["visitorCode"]);

            int result = bll.updateEdsData(obj);
        }
        else
        {
            VisitorData bll = new VisitorData();
            VisitorDataInfo obj = new VisitorDataInfo();

            obj.VisitorDataCode = Convert.ToInt32(Request.QueryString["visitorDataCode"]);

		    if (Request.QueryString["mode"].Equals("inTime"))
		    {
			    int result = bll.updateInTime(obj);
		    }
		    else if (Request.QueryString["mode"].Equals("outTime"))
		    {
			    int result = bll.updateOutTime(obj);
		    }
        }		

	
		String key = HttpUtility.UrlEncode(Request.QueryString["key"]);
		Page.RegisterClientScriptBlock("alert", JavaScriptBuilder.alert("Đã hoàn thành (처리 하였습니다).", "visitDataList.aspx?keyWord=" + Request.QueryString["keyWord"] + "&key=" + key + "&page=" + Request.QueryString["page"]));
    }
}
