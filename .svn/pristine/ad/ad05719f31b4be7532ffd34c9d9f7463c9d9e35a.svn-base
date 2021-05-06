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
using System.Globalization;
using System.Threading;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // Thread.CurrentThread.CurrentUICulture ciLang = new CultureInfo("en-EN");
       // Resources.resLanguage.Culture = ciLang;

        if (!Page.IsPostBack)
        {
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                FormsAuthenticationTicket ticket;
                ticket = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);
                //txtUpnid.Text = ticket.Name;
                
                chkPersistCookie.Checked = true;
            }

            // save id 
            if (Request.Cookies.Get("saveID")!=null)
            {
                txtUpnid.Text = Request.Cookies.Get("saveID").Value;
                chkPersistCookie.Checked = true;
            }
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        CultureInfo ciLang = new CultureInfo("en-EN");
        Resources.resLanguage.Culture = ciLang;
        Employee bll = new Employee();
        String upnid = txtUpnid.Text;
        String upnpw = txtUpnpw.Text;

        if (!bll.existsID(upnid))
        {
            Page.RegisterClientScriptBlock("errorID", JavaScriptBuilder.alert("ID không chính xác. Hãy Kiểm tra lại ID. (올바르지 못한 사번입니다.\\n\\n사번을 다시한번 확인하여 주십시요)"));
        }
        else if (!bll.isPasswordMatch(upnid, upnpw))
        {
            Page.RegisterClientScriptBlock("errorPW", JavaScriptBuilder.alert("Mật khẩu không chính xác. Hãy Kiểm tra lại mật khẩu. Mật khẩu phân biệt chữ thường, chữ in hoa. (올바르지 못한 비밀번호 입니다 .\\n\\n비밀번호를 다시한번 확인하여 주십시요\\n\\n비밀번호는 대소문자를 구분합니다.)"));
        }
        else
        {

            FormsAuthenticationTicket tkt;
            string cookiestr;

            // new ticket
            tkt = new FormsAuthenticationTicket(1, upnid, DateTime.Now, DateTime.Now.AddMinutes(30), chkPersistCookie.Checked, "login Cookie", FormsAuthentication.FormsCookiePath);

            // encrypt
            cookiestr = FormsAuthentication.Encrypt(tkt);

            // create cookie
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr));

            // redirect return url
            String strReturnUrl = FormsAuthentication.GetRedirectUrl(upnid, chkPersistCookie.Checked);

            // save id
            if (chkPersistCookie.Checked == true)
            {
                HttpCookie saveCookie = new HttpCookie("saveID", upnid);
                saveCookie.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(saveCookie);
            }

            // session save
            EmployeeInfo employeeInfo = new EmployeeInfo();
            employeeInfo = bll.selectEmployee(upnid);
            Session.Add("loginMember", employeeInfo);
            Session.Add("loginUpnid", upnid);

            // return url check
            int count = 0;
            if (strReturnUrl != null)
            {
                count = strReturnUrl.IndexOf("logOut.aspx");
            }

            if (count > -1 )
            {
                strReturnUrl = "Default.aspx";
            }

            Response.Redirect(strReturnUrl, true);
            }
        
    }
   
    protected void txtUpnid_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtUpnpw_TextChanged(object sender, EventArgs e)
    {

    }
}
