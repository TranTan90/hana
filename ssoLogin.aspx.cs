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

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		Employee bll = new Employee();
		String upnid = Request.QueryString["employeeCode"];
        
        long number1 = 0;
        bool canConvert = long.TryParse(upnid, out number1);
        HttpContext.Current.Response.AddHeader("p3p", "CP=\"IDC DSP COR ADM DEVi TAIi PSA PSD IVAi IVDi CONi HIS OUR IND CNT\"");

        //Response.AddHeader("P3P", "CP='CAO PSA CONi OTR OUR DEM ONL'");
        if (upnid != null && !canConvert)
        {
            //URL 특수문자 등 값들 문자인식 방지
            upnid = HttpUtility.UrlDecode(upnid);

            //아이디 Base 64 복호화
            upnid = Decrypt(upnid);

            Response.AddHeader("X-Frame-Options", "AllowAll");
          //  Response.AddHeader("P3P", "CP='ALL CURa ADMa DEVa TAIa OUR BUS IND PHY ONL UNI PUR FIN COM NAV INT DEM CNT STA POL HEA PRE LOC OTC'");
            
            HttpCookie ssoCookie = new HttpCookie("ssoID", upnid);
            ssoCookie.Expires = DateTime.Now.AddMinutes(30);
            Response.AddHeader("Set-Cookie", "ssoID=" + upnid + ";SameSite=None;");
            Response.AddHeader("Set-Cookie", String.Format(
        "{0}={1}; expires={2}; path=/;SameSite=None; secure; HttpOnly",
        "ssoID", upnid, DateTime.Now.AddMinutes(30)));
        }
        
		if (!bll.existsID(upnid))
		{
			Page.RegisterClientScriptBlock("errorID", JavaScriptBuilder.alert("Nhập sai ID. Hãy kiểm tra và nhập lại ID. (올바르지 못한 사번입니다.\\n\\n사번을 다시한번 확인하여 주십시요)"));
		}
		//else if (!bll.isPasswordMatch(upnid, upnpw))
		//{
		//    Page.RegisterClientScriptBlock("errorPW", JavaScriptBuilder.alert("올바르지 못한 비밀번호 입니다.\\n\\n비밀번호를 다시한번 확인하여 주십시요\\n\\n비밀번호는 대소문자를 구분합니다."));
		//}
		else
		{

			FormsAuthenticationTicket tkt;
			string cookiestr;

			// new ticket
			tkt = new FormsAuthenticationTicket(1, upnid, DateTime.Now, DateTime.Now.AddMinutes(30), true, "login Cookie", FormsAuthentication.FormsCookiePath);

			// encrypt
			cookiestr = FormsAuthentication.Encrypt(tkt);

            
			// create cookie
            
			Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr));
            

        
			// redirect return url
			String strReturnUrl = FormsAuthentication.GetRedirectUrl(upnid, true);
                 
			// save id
			HttpCookie saveCookie = new HttpCookie("saveID", upnid);
			saveCookie.Expires = DateTime.Now.AddYears(1);
			Response.Cookies.Add(saveCookie);
            
            
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

			if (count > -1)
			{
				strReturnUrl = "Default.aspx";
			}

			Response.Redirect(strReturnUrl, true);
		}
    }
    #region "Base64 복호화"
    public static string Decrypt(string textToDecrypt)
    {
        byte[] encryptedData = Convert.FromBase64String(textToDecrypt);
        return Encoding.UTF8.GetString(encryptedData);
    }
    #endregion
}