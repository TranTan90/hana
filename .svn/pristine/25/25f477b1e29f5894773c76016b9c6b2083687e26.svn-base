using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;
using HanaMicron.COMS.IDAL;

namespace HanaMicron.COMS.BLL
{
    public class Employee
    {
        private static readonly IEmployee dal = HanaMicron.COMS.DALFactory.DataAccess.CreateEmployee();

        public List<FreePassUserInfo> selectEmployeeForfreepass(String ename)
        {
            return dal.selectEmployeeForfreepass(ename);
        }

        public EmployeeInfo selectEmployee(String upnid)
        {
            return dal.selectEmployee(upnid);
        }

        public Boolean existsID(String upnid)
        {
            return dal.existsID(upnid);
        }

        public Boolean isPasswordMatch(String upnid, String upnpw)
        {
            return dal.isPasswordMatch(upnid, upnpw);
        }

		public List<EmployeeInfo> listEmployee(String department)
		{
			return dal.listEmployee(department);
		}

		public List<EmployeeInfo> listApprovor(String isVisit, String isTakeOut)
		{
			return dal.listApprovor(isVisit, isTakeOut);
		}

		public List<EmployeeInfo> searchEmployeeList(String keyWord, String key)
		{
			return dal.searchEmployeeList(keyWord, key);
		}

		public Boolean existsApprovor(String upnid,String isVisit,String isTakeOut)
		{
			return dal.existsApprovor(upnid,isVisit,isTakeOut);
		}

		public int insertApprovor(EmployeeInfo employee,String isVisit,String isTakeOut)
		{
			return dal.insertApprovor(employee, isVisit, isTakeOut);
		}

		public int deleteApprovor(EmployeeInfo employee, string isVisit, string isTakeOut)
		{
			return dal.deleteApprovor(employee, isVisit, isTakeOut);
		}
    }
}
