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

public partial class car_carVisitTimeUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		Car bll = new Car();
        CarVisitDataInfo obj = new CarVisitDataInfo();

        obj.CarVistDataCode = Convert.ToInt32(Request.QueryString["carVisitDataCode"]);

        int result = bll.updateOutTime(obj.CarVistDataCode);

        //if (Request.QueryString["mode"].Equals("inTime"))
        //{
        //    int result = bll.updateInTime(obj);
        //}
        //else if (Request.QueryString["mode"].Equals("outTime"))
        //{
        //    int result = bll.updateOutTime(obj);
        //}

		String key = HttpUtility.UrlEncode(Request.QueryString["key"]);
        Page.RegisterClientScriptBlock("alert", JavaScriptBuilder.alert("Đã hoàn thành (처리 하였습니다).", "../security/carVisitDataList.aspx?keyWord=" + Request.QueryString["keyWord"] + "&key=" + key + "&page=" + Request.QueryString["page"]));
    }
}
