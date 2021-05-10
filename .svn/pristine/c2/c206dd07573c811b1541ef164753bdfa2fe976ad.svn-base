using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HanaMicron.COMS.Model;
using HanaMicron.COMS.DBUtility;
using HanaMicron.COMS.IDAL;
using log4net;


namespace HanaMicron.COMS.SQLServerDAL
{
    public class Department : IDepartment
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Department));

        public Department()
		{
			//log4net.Config.DOMConfigurator.Configure();
		}

        #region IDepartment 멤버

        /// <summary>
        /// 목록
        /// </summary>
        /// <returns></returns>
        public List<DepartmentInfo> listDepartment()
        {
            log.Debug("=================START listDepartment=================");

            List<DepartmentInfo> list = new List<DepartmentInfo>();

            StringBuilder sql_select = new StringBuilder();
            sql_select.Append("SELECT dep_code,dep_name,level_no,seq,del_flag,reg_date FROM GCM.dbo.DEPART_MTB WHERE del_flag=0 ORDER BY Convert(INT,level_no), Convert(INT,seq)");

            //Execute the query against the database
			using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_select.ToString(), null))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    DepartmentInfo obj = new DepartmentInfo();
                    obj = bindDepartment(rdr, obj);
                    list.Add(obj);
                }
            }

            log.Debug("=================END listDepartment=================");

            return list;
        }

		/// <summary>
		/// Department 객체와 Result Set 과의 Mapping
		/// </summary>
		/// <param name="rdr"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		public DepartmentInfo bindDepartment(SqlDataReader rdr, DepartmentInfo obj)
		{
            obj.Dep_code = rdr.GetString(0);
			obj.Dep_name = rdr.GetString(1);
			obj.Level_no = rdr.GetInt32(2);
			obj.View_seq = rdr.GetString(3);
			obj.Del_flag = rdr.GetByte(4);

            if (rdr.IsDBNull(5)) obj.Reg_date = null;
            else obj.Reg_date = rdr.GetString(5);

			return obj;
		}

        #endregion
    }
}
