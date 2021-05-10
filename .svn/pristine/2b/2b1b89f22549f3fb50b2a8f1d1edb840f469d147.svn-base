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


public partial class main_takeOut_registration : System.Web.UI.Page
{
    Company bll = new Company();
    protected void Page_Load(object sender, EventArgs e)
    {
        // 로그인 체크  check login
        EmployeeInfo loginEmployee = new EmployeeInfo();
        loginEmployee = (EmployeeInfo)Session["loginMember"];
        if (loginEmployee == null)
        {
            Response.Redirect("~/login.aspx", true);
        }

        if (Page.IsPostBack)
        {
        
     
            // 등록하기 Đăng ký
            
            
                // 등록 여부 검사 Có Kiểm tra đăng ký hay không
                bool exists = bll.existsComapny(regNumber1.Text, regNumber2.Text, regNumber3.Text, companyName.Text);

                if (exists == true)
                {
                    Page.RegisterStartupScript("alertMsg", JavaScriptBuilder.alert(companyName.Text + "là tên công ty đã được đăng ký trước (는 이미 등록된 업체 명입니다.\\nHãy tìm theo tên công ty 회사명으로 검색해 보시기 바랍니다)."));
                }
                else
                {
                    // 객체를 만들어 저장 Lưu object đã tạo
                    CompanyInfo company = new CompanyInfo();

                    company.CompanyName = companyName.Text;
                    company.RegNumber1 = regNumber1.Text;
                    company.RegNumber2 = regNumber2.Text;
                    company.RegNumber3 = regNumber3.Text;
                    company.Phone1 = phone1.Text;
                    company.Phone2 = phone2.Text;
                    company.Phone3 = phone3.Text;
                    company.MasterName = masterName.Text;
                    company.Address = address.Text;
                    company.Approve = 0;
                    company.EmployeeCode = loginEmployee.Upnid;
                    company.EmployeeName = loginEmployee.DisplayName;
                    company.EmployeeDept = loginEmployee.Dep_name;    ///////////////////////////////////////////
                    int result = bll.insertCompany(company);
                    // 2011-02-11-김민우: 담당자에게 인폼 오토 메일 발송
                    bll.CreateHtml(company);
                    //Response.Redirect("requestList.aspx?employeeCode="+loginEmployee.Upnid);
                    Response.Redirect("/COMS/main/company/requestList.aspx");
                    
                }

            }
        
        
        

    }

}