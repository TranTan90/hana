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
using System.Collections.Generic;
using HanaMicron.COMS.BLL;

public partial class admin_approve_approveList : System.Web.UI.Page
{

	private TakeOutItemCategory bll = new TakeOutItemCategory();

    protected void Page_Load(object sender, EventArgs e)
	{
		// 관리자 체크 check người quản lý 
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}

		if (loginEmployee.ISAdmin == false)
		{
			Response.Redirect("~/login.aspx", true);
		}

		imgError.Visible = false;
		lblError.Visible = false;
	}


	/// <summary>
	/// 
	/// </summary>
	/// <param name="message"></param>
	protected void showError(String message)
	{
		imgError.Visible = true;
		lblError.Visible = true;
		lblError.Text = message;
	}
	

	/// <summary>
	/// 대분류 보이기  xem phân loại tài sản lớn
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void subItemList_SelectedIndexChanged(object sender, EventArgs e)
	{
		txtSubName.Text = subItemList.SelectedItem.Text;
	}

	/// <summary>
	/// 대분류 수정 Sửa phân loại tài sản lớn
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnItemModify_Click(object sender, EventArgs e)
	{
		TakeOutItemCategoryInfo obj=new TakeOutItemCategoryInfo();
		obj.CodeName=txtItemName.Text;
		obj.TakeOutItemCategoryCode=Convert.ToInt32(itemList.SelectedValue);

		int result=bll.updateTakeOutItemCategory(obj);

		Response.Redirect("takeOutItemCategoryList.aspx",true);
	}

	/// <summary>
	/// 대분류 추가   Thêm tài sản lớn
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnItemInsert_Click(object sender, EventArgs e)
	{
		TakeOutItemCategoryInfo obj = new TakeOutItemCategoryInfo();
		obj.CodeName = txtItemName.Text;
		obj.DepthID = 1;
		obj.GroupID = 0;

		int result = bll.insertTakeOutItemCategory(obj);

		Response.Redirect("takeOutItemCategoryList.aspx", true);
	}
	
	/// <summary>
	/// 대분류 삭제  xóa tài sản lớn
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnItemDelete_Click(object sender, EventArgs e)
	{
		TakeOutItemCategoryInfo obj = new TakeOutItemCategoryInfo();
		obj.TakeOutItemCategoryCode = Convert.ToInt32(itemList.SelectedValue);
		int result = bll.deleteTakeOutItemCategory(obj);
		Response.Redirect("takeOutItemCategoryList.aspx", true);
	}

	/// <summary>
	/// 소분류 보이기  Xem phân loại tài sản nhỏ
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void itemList_SelectedIndexChanged(object sender, EventArgs e)
	{
		txtItemName.Text = itemList.SelectedItem.Text;
	}

	/// <summary>
	/// 소분류 추가 Thêm tài sản nhỏ
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnSubInsert_Click(object sender, EventArgs e)
	{
		TakeOutItemCategoryInfo obj = new TakeOutItemCategoryInfo();
		obj.CodeName = txtSubName.Text;
		obj.DepthID = 2;
		obj.GroupID = Convert.ToInt32(itemList.SelectedValue);

		int result = bll.insertTakeOutItemCategory(obj);

		Response.Redirect("takeOutItemCategoryList.aspx", true);
	}

	/// <summary>
	/// 소분류 수정 Sửa tài sản nhỏ
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnSubModify_Click(object sender, EventArgs e)
	{
		TakeOutItemCategoryInfo obj = new TakeOutItemCategoryInfo();
		obj.CodeName = txtSubName.Text;
		obj.TakeOutItemCategoryCode = Convert.ToInt32(subItemList.SelectedValue);

		int result = bll.updateTakeOutItemCategory(obj);

		Response.Redirect("takeOutItemCategoryList.aspx", true);
	}

	/// <summary>
	/// 소분류 삭제  xóa tài sản nhỏ
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnSubDelete_Click(object sender, EventArgs e)
	{
		TakeOutItemCategoryInfo obj = new TakeOutItemCategoryInfo();
		obj.TakeOutItemCategoryCode = Convert.ToInt32(subItemList.SelectedValue);
		int result = bll.deleteTakeOutItemCategory(obj);
		Response.Redirect("takeOutItemCategoryList.aspx", true);
	}
}
