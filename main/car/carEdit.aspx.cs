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
		Car bll = new Car();

        #region control Add Attribute

        number.Attributes.Add("onblur", "numCheck();");
        //txtCarNo.Attributes.Add("onkeypress", "numCheck();");

        // 2019-03-26-임종우 : .net 에서 client단에 readonly 설정 시 값을 안 가져오는 문제 발생.. 서버에 Attributes 추가로 해결 함.
        companyName.Attributes.Add("readonly", "readonly");

        #endregion

		if (Page.IsPostBack)
		{
			// 객체 생성 Hình thành Object
			CarDataInfo carData = new CarDataInfo();
            CarHandlerInfo carHandler = new CarHandlerInfo();

			carData.CarCategoryCode = Convert.ToInt32(carCategoryCode.SelectedValue);
			carData.Header = header.Text;
			carData.Number = number.Text;
            //carData.Handler = handler.Text;
			carData.Reject = 0;
			carData.RejectContent = "";
            carData.CarType = "4";
            carData.CompanyName = companyName.Text;

            if (!String.IsNullOrEmpty(companyCode.Value)) carData.CompanyCode = Convert.ToInt32(companyCode.Value);
                        
			// 차량번호 중복 검사 로직 삭제 (2008.03.10)
			//if (bll.existsCarData(carData.Header, carData.Number,carData.Handler))
			//{
			//    Page.RegisterStartupScript("alertMsg", JavaScriptBuilder.alert(header.Text + number.Text + " 는 이미 등록된 차량 번호 입니다."));
			//}
			//else
			//{
			//    int result = bll.insertCarData(carData);
			//    Response.Redirect("searchCar.aspx");
			//}

            if (bll.existsCarData(carData.Header, carData.Number))
            {
                Page.RegisterStartupScript("alertMsg", JavaScriptBuilder.alert(number.Text + " là số xe đã được đăng ký trước (는 이미 등록된 차량 번호 입니다)."));
            }
            else if (String.IsNullOrEmpty(carData.CompanyName))
            {
                Page.RegisterStartupScript("alertMsg", JavaScriptBuilder.alert("Nhập tên công ty (회사명을 입력하여 주세요)."));
            }
            else
            {
                int result = bll.insertCarData(carData);
                int carCode = bll.selectMaxCarCode();

                carHandler.CarCode = carCode;
                carHandler.Handler = handler.Text;
                carHandler.Phone = "";

                //운전자 등록 đăng ký lái xe
                bll.insertCarHandler(carHandler);

                Response.Redirect("searchCar.aspx");
            }

            //int result = bll.insertCarData(carData);
            //Response.Redirect("searchCar.aspx");
		}
        else
        {
			lableCodeName.Text = "Đăng ký xe (차량 등록하기)";
			mode.Value = Request.QueryString["mode"];
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{

	}
}
