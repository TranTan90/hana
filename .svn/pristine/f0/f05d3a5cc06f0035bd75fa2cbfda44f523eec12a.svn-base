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
using System.Collections.Generic;

public partial class main_visit_deleteVisit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		TakeOutData blltakeOutData = new TakeOutData();
		TakeOutItemData bllTakeOutItemData = new TakeOutItemData();

		List<TakeOutItemDataInfo> list = bllTakeOutItemData.selectTakeOutItemDataList(Request.QueryString["takeOutDataCode"]);
		for (int i = 0; i < list.Count; i++)
		{
			TakeOutItemDataInfo item = (TakeOutItemDataInfo)list[i];
			int resultDel = bllTakeOutItemData.deleteTakeOutItemData(item);
		}

		TakeOutDataInfo takeOutDataInfo = new TakeOutDataInfo();
		takeOutDataInfo.TakeOutDataCode = Request.QueryString["takeOutDataCode"];
		int result = blltakeOutData.deleteTakeOutData(takeOutDataInfo);

		Page.RegisterClientScriptBlock("alert",JavaScriptBuilder.alert("đã xóa (삭제 하였습니다).","listTakeOut.aspx"));
    }
}
