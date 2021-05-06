using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;

namespace HanaMicron.COMS.IDAL
{
    public interface IEmployee
    {
        List<FreePassUserInfo> selectEmployeeForfreepass(String ename);
        
        EmployeeInfo selectEmployee(String upnid);

        Boolean existsID(String upnid);

        Boolean isPasswordMatch(String upnid, String upnpw);

		List<EmployeeInfo> listEmployee(String department);

		List<EmployeeInfo> listApprovor(String isVisit, String isTakeOut);

		List<EmployeeInfo> searchEmployeeList(String keyWord, String key);

		Boolean existsApprovor(String upnid, String isVisit, String isTakeOut);

		int insertApprovor(EmployeeInfo employee, String isVisit, String isTakeOut);

		int deleteApprovor(EmployeeInfo employee, String isVisit, String isTakeOut);
    }
}