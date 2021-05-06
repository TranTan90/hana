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

public partial class _Default : System.Web.UI.Page
{
	VisitObject bll = new VisitObject();
    protected void Page_Load(object sender, EventArgs e)
    {
		// 관리자 체크
		EmployeeInfo loginEmployee = new EmployeeInfo();
		loginEmployee = (EmployeeInfo)Session["loginMember"];
		if (loginEmployee == null)
		{
			Response.Redirect("~/login.aspx", true);
		}

		if (loginEmployee.ManagerLevel < 2)
		{
			Response.Redirect("~/login.aspx", true);
		}

        if (Page.IsPostBack)
        {
			VisitObjectInfo visitObjectInfo = new VisitObjectInfo();
			visitObjectInfo.VisitObjectCode = Convert.ToInt32(Request.QueryString["visitObjectCode"]);
			visitObjectInfo.VisitObjectName = txtVisitObjectName.Text;
            visitObjectInfo.Status = txtStatus.Text;

            // 수정하기 sửa
            if (mode.Value.Equals("modify"))
            {
				int result = bll.updateVisitObject(visitObjectInfo);
                Response.Redirect("visitObjectList.aspx");
            }
            // 등록하기 đăng ký
            else
            {
				int result = bll.insertVisitObject(visitObjectInfo);
				Response.Redirect("visitObjectList.aspx");
            }
        }
        else
        {   
            if (Request.QueryString["mode"].Equals("modify"))
            {
				VisitObjectInfo visitObjectInfo = new VisitObjectInfo();
				visitObjectInfo=bll.selectVisitObject(Request.QueryString["visitObjectCode"]);

                txtVisitObjectName.Text = visitObjectInfo.VisitObjectName;
                txtStatus.Text = visitObjectInfo.Status;

                lableCodeName.Text = " Sửa thông tin (정보 수정하기)  : " + visitObjectInfo.VisitObjectName ;
                mode.Value = Request.QueryString["mode"];
            }
            else
            {
                lableCodeName.Text = "Đăng ký mục đích thăm (방문 목적 등록하기)";
                mode.Value = Request.QueryString["mode"];
            }   
            
        }
        
        
    }
}
