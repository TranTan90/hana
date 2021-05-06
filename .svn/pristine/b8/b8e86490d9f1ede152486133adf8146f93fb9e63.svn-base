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
using System.Collections.Generic;
using HanaMicron.COMS.Model;

public partial class main_takeOut_searchSubCategory : System.Web.UI.Page
{
	public string searchResult;
    protected void Page_Load(object sender, EventArgs e)
    {
		TakeOutItemCategory bll = new TakeOutItemCategory();
		List<TakeOutItemCategoryInfo> list=bll.selectTakeOutItemCategoryList(2,Convert.ToInt32(Request.QueryString["takeOutItemCategoryCode"]));

        searchResult = "Chọn tài sản nhỏ (소분류를 선택 하십시오||0:|:)";
		for (int i = 0; i < list.Count; i++)
		{
			TakeOutItemCategoryInfo obj=(TakeOutItemCategoryInfo)list[i];
			searchResult += obj.CodeName + "||" + obj.TakeOutItemCategoryCode +":|:";

		}
    }
}
