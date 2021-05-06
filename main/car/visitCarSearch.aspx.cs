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
using System.Collections.Generic;

public partial class car_visitCarSearch : System.Web.UI.Page
{
    public string searchResult;
    protected void Page_Load(object sender, EventArgs e)
    {
        Car bllVisitCar = new Car();
        List<CarDataInfo> list = new List<CarDataInfo>();
        List<CarHandlerInfo> list2 = new List<CarHandlerInfo>();
        
        if (Request.QueryString["type"].Equals("carData"))
        {
            list = bllVisitCar.getCarDataList("car", Request.QueryString["number"]);
        }
        else
        {
            list2 = bllVisitCar.selectPermitCarHandlerList(Request.QueryString["carCode"]);
        }

        if (!list.Count.Equals(0) || !list2.Count.Equals(0))
        {
            if (Request.QueryString["type"].Equals("carData"))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    CarDataInfo ep = (CarDataInfo)list[i];
                    searchResult += ":|:" + ep.CarCode + "," + ep.Header + "," + ep.Number + "," + ep.CarType + "," + ep.CompanyName + "," + ep.CompanyCode;
                }

                //searchResult = list[0].CarCode.ToString() + "," + list[0].Header + "," + list[0].Number + "," + list[0].CarType + "," + list[0].CompanyName;
            }
            else
            {
                for (int i = 0; i < list2.Count; i++)
                {
                    CarHandlerInfo ep = (CarHandlerInfo)list2[i];
                    searchResult += ":|:" + ep.CarHandlerCode + "," + ep.CarCode + "," + ep.Handler + "," + ep.Phone;
                }

                //for (int i = 0; i < list.Count; i++)
                //{
                //    CarDataInfo ep = (CarDataInfo)list[i];
                //    searchResult += ":|:" + ep.CarhandlerInfoList[0].CarHandlerCode.ToString() + "," + ep.CarhandlerInfoList[0].Handler + "," + ep.CarhandlerInfoList[0].Phone;
                //}
            }
        }
        
    }
}
