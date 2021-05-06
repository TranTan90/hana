using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;
using HanaMicron.COMS.IDAL;
using System.Data.SqlClient;

namespace HanaMicron.COMS.BLL
{
    public class Department
    {
        private static readonly IDepartment dal = HanaMicron.COMS.DALFactory.DataAccess.CreateDepartment();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public List<DepartmentInfo> listDepartment()
        {
            return dal.listDepartment();
        }

		

    }
}
