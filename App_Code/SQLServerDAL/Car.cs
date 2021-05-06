using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;
using System.Data.SqlClient;
using System.Data;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.DBUtility;
using HanaMicron.COMS.Utility;
using System.Globalization;
using log4net;

namespace HanaMicron.COMS.SQLServerDAL
{
	/// <summary>
	/// 차량 DAL
	/// </summary>
    public class Car : ICar
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Car));

        private const string SQL_SELECT_CARCATEGORY = "SELECT carCategoryCode,codeName,regDate, status FROM CarCategory WHERE carCategoryCode = @carCategoryID";
        private const string PARM_CARCATEGORY_ID = "@carCategoryID";

        public Car()
		{
			log4net.Config.DOMConfigurator.Configure();
		}

        #region 차종 관리 부분

        /// <summary>
        /// 차종 정보 가져오기
        /// </summary>
        /// <param name="carCategoryID"></param>
        /// <returns></returns>
        public CarCategoryInfo getCarCategory(String carCategoryID)
        {
            log.Debug(@"=================START getCarCategory=================");
            log.Debug(@"carCategoryID = " + carCategoryID);

            CarCategoryInfo obj = null;

            //Create a parameter
            SqlParameter parm = new SqlParameter(PARM_CARCATEGORY_ID, SqlDbType.VarChar, 10);
            //Bind the parameter
            parm.Value = carCategoryID;

            //Execute the query	
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_CARCATEGORY, parm))
            {
                if (rdr.Read())
                    obj = new CarCategoryInfo(rdr.GetInt16(0), rdr.GetString(1), rdr.GetDateTime(2), rdr.GetString(3));
                else
                    obj = new CarCategoryInfo();
            }

            log.Debug(@"=================END getCarCategory=================");

            return obj;

        }

        /// <summary>
        /// 차종 목록
        /// </summary>
        /// <param name="txtKey"></param>
        /// <returns></returns>
        public List<CarCategoryInfo> getCarCategoryList(String txtKey)
        {
            log.Debug(@"=================START getCarCategoryList=================");
            log.Debug(@"txtKey = " + txtKey);

            List<CarCategoryInfo> list = new List<CarCategoryInfo>();
            

            String SQL_SELECT_CAR_CATEGORY_LIST="SELECT carCategoryCode,codeName,regDate, status ";
            SQL_SELECT_CAR_CATEGORY_LIST += "FROM CarCategory ";

            if (!String.IsNullOrEmpty(txtKey))
            {
                if (txtKey.Equals("A"))
                {
                    SQL_SELECT_CAR_CATEGORY_LIST += "WHERE status = 'Y' ";
                }
                else
                {
                    SQL_SELECT_CAR_CATEGORY_LIST += "WHERE codeName LIKE '%" + txtKey + "%' ";
                }

            }
          
            SQL_SELECT_CAR_CATEGORY_LIST+="ORDER BY codeName";

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_CAR_CATEGORY_LIST, null))
            {
                while (rdr.Read())
                {
                    CarCategoryInfo obj = new CarCategoryInfo(rdr.GetInt16(0), rdr.GetString(1), rdr.GetDateTime(2), rdr.GetString(3));
                    list.Add(obj);
                }
            }

            log.Debug(@"=================END getCarCategoryList=================");

            return list;
        }

        /// <summary>
        /// 차종 목록 총 갯수
        /// </summary>
        /// <param name="txtKey"></param>
        /// <returns></returns>
        public Int32 getCarCategoryTotal(String txtKey)
        {
            log.Debug(@"=================START getCarCategoryTotal=================");
            log.Debug(@"txtKey = " + txtKey);

            Object totalCount=null;
            String SQL_SELECT_CAR_CATEGORY_TOTAL = "SELECT COUNT(*) FROM CarCategory";
            SQL_SELECT_CAR_CATEGORY_TOTAL += " WHERE 1=1 ";
          
            if (!String.IsNullOrEmpty(txtKey))
            {
                SQL_SELECT_CAR_CATEGORY_TOTAL += " AND codeName LIKE '%" + txtKey + "%'";
            }
            totalCount=SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_CAR_CATEGORY_TOTAL, null);
            if (totalCount == null)
            {
                return Convert.ToInt32("0");
            }
            else
            {
                return Convert.ToInt32(totalCount);
            }

            log.Debug(@"=================END getCarCategoryTotal=================");

        }

        /// <summary>
        /// 차종 수정
        /// </summary>
        /// <param name="carCategoryCode"></param>
        /// <param name="codeName"></param>
        /// <returns></returns>
        public int updateCarCategory(String carCategoryCode, String codeName, String status)
        {
            log.Debug("=================START updateCarCategory=================");
            log.Debug("carCategoryCode = " + carCategoryCode);
            log.Debug("codeName = " + codeName);

            String SQL_CAR_CATEGORY_UPDATE = "UPDATE CarCategory SET codeName=N'" + codeName + "', status='" + status + "' WHERE carCategoryCode=" + carCategoryCode;

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_CAR_CATEGORY_UPDATE, null);

            log.Debug("=================END updateCarCategory=================");

            return result;
        }

        /// <summary>
        /// 차종 저장
        /// </summary>
        /// <param name="codeName"></param>
        /// <returns></returns>
        public int insertCarCategory(String codeName,String status)
        {
            log.Debug("=================START insertCarCategory=================");
            log.Debug("codeName = " + codeName);
            log.Debug("status = " + status);

            String SQL_CAR_CATEGORY_INSERT = "INSERT INTO CarCategory (codeName,regDate,status) VALUES (N'"+codeName+"',GETDATE(),'" + status +"' );";

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_CAR_CATEGORY_INSERT, null);

            log.Debug("=================END insertCarCategory=================");

            return result;
        }

        /// <summary>
        /// 차종 삭제
        /// </summary>
        /// <param name="carCategoryCode"></param>
        /// <returns></returns>
        public int deleteCarCategory(Int16 carCategoryCode)
        {
            log.Debug("=================START deleteCarCategory=================");
            log.Debug("carCategoryCode = " + carCategoryCode.ToString());

            String SQL_CAR_CATEGORY_DELETE = "DELETE FROM CarCategory WHERE carCategoryCode="+carCategoryCode;

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_CAR_CATEGORY_DELETE, null);

            log.Debug("=================END deleteCarCategory=================");

            return result;
        }
        #endregion

        #region 차량 관리

        /// <summary>
        /// 차량 정보 가져오기
        /// </summary>
        /// <param name="carDataCode"></param>
        /// <returns></returns>
        public CarDataInfo getCarData(String type, int code)
        {
            log.Debug("=================START getCarData=================");
            log.Debug("type = " + type);
            log.Debug("coed = " + code.ToString());

            CarDataInfo obj = new CarDataInfo();

            StringBuilder SQL_SELECT_CAR_DATA = new StringBuilder();

            SQL_SELECT_CAR_DATA.Append(@"
                                    SELECT	a.carCode,
		                                    a.carCategoryCode,
		                                    a.header,
		                                    a.number,
		                                    a.carType,
		                                    a.companyName,
		                                    ISNULL(c.handler,' ') as handler,
                                            c.handlerPhone,
		                                    a.reject,
		                                    isnull(a.rejectContent,' ') as rejectContent,
		                                    a.regDate,
		                                    b.codeName,
                                            c.carHandlerCode,
                                            a.companyCode
                                    FROM	CarData a,
		                                    CarCategory b,
		                                    CarHandler c
                                    WHERE	a.carCategoryCode=b.carCategoryCode
		                                    AND a.carCode=c.carCode ");

            if(String.Equals(type,"carCode")) SQL_SELECT_CAR_DATA.Append(" AND a.carCode=" + code);
            else SQL_SELECT_CAR_DATA.Append(" AND c.carHandlerCode=" + code);

            //Execute the query	
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_CAR_DATA.ToString(), null))
            {
                if (rdr.Read()) 
                {
                    obj = bindCarDataInfo(rdr, obj);
                }
            }

            log.Debug("=================END getCarData=================");

            return obj;
        }


        ///// <summary>
        ///// 차량 정보 가져오기
        ///// </summary>
        ///// <param name="carDataCode"></param>
        ///// <returns></returns>
        //public CarDataInfo getCarData(int carCode)
        //{
        //    log.Debug("=================START getCarData=================");
        //    log.Debug("carCode = " + carCode.ToString());

        //    CarDataInfo obj = new CarDataInfo();

        //    String SQL_SELECT_CAR_DATA = "SELECT a.carCode,a.carCategoryCode,a.header,a.number,ISNULL(a.handler,' ') as handler,a.reject,isnull(a.rejectContent,' ') as rejectContent,a.regDate,b.codeName FROM CarData a,CarCategory b WHERE a.carCategoryCode=b.carCategoryCode AND carCode=" + carCode;

        //    //Execute the query	
        //    using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_CAR_DATA, null))
        //    {
        //        if (rdr.Read()) obj = new CarDataInfo(rdr.GetInt32(0),rdr.GetInt16(1),rdr.GetString(2),rdr.GetString(3),rdr.GetString(4),rdr.GetByte(5),rdr.GetString(6),rdr.GetDateTime(7),rdr.GetString(8));
        //    }

        //    log.Debug("=================END getCarData=================");

        //    return obj;
        //}

        /// <summary>
        /// 검색된 차량 갯수
        /// </summary>
        /// <param name="txtKey"></param>
        /// <returns></returns>
        public int getCarDataTotal(String txtKey)
        {
            log.Debug("=================START getCarDataTotal=================");
            log.Debug("txtKey = " + txtKey);

            Object totalCount = null;
            String SQL_SELECT_CAR_CATEGORY_TOTAL = "SELECT COUNT(*) FROM CarData a,CarCategory b WHERE a.carCategoryCode=b.carCategoryCode ";
            if (!String.IsNullOrEmpty(txtKey))
            {
                SQL_SELECT_CAR_CATEGORY_TOTAL += " AND a.number LIKE '%" + txtKey + "%'";
            }
            totalCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_CAR_CATEGORY_TOTAL, null);

            log.Debug("=================END getCarDataTotal=================");

            if (totalCount == null)
            {
                return Convert.ToInt32("0");
            }
            else
            {
                return Convert.ToInt32(totalCount);
            }

        }


        /// <summary>
        /// 차량 목록
        /// </summary>
        /// <param name="txtKey"></param>
        /// <returns></returns>
        public List<CarDataInfo> getCarDataList(String type, String txtKey)
        {
            log.Debug("=================START getCarDataList=================");
            log.Debug("txtKey = " + txtKey);

            List<CarDataInfo> list = new List<CarDataInfo>();

            StringBuilder SQL_SELECT_CAR_DATA_LIST = new StringBuilder();

            if (type.Equals("car"))
            {
                SQL_SELECT_CAR_DATA_LIST.Append(@"
                                                    SELECT	a.carCode,
		                                                    a.carCategoryCode,
		                                                    a.header,
		                                                    a.number,
		                                                    a.carType,
		                                                    a.companyName,
		                                                    '' as handler,
                                                            '' as handlerPhone,
		                                                    a.reject,
		                                                    isnull(a.rejectContent,' ') as rejectContent,
		                                                    a.regDate,
		                                                    b.codeName,
                                                            0 as carHandlerCode,
                                                            a.companyCode
                                                    FROM	CarData a,
		                                                    CarCategory b
                                                    WHERE	a.carCategoryCode=b.carCategoryCode
                                                      AND   a.companyCode IS NOT NULL");

            }
            else
            {
                SQL_SELECT_CAR_DATA_LIST.Append(@"
                                                    SELECT	a.carCode,
                		                                    a.carCategoryCode,
                		                                    a.header,
                		                                    a.number,
                		                                    a.carType,
                		                                    a.companyName,
                		                                    ISNULL(c.handler,' ') as handler,
                                                            c.handlerPhone,
                		                                    a.reject,
                		                                    isnull(a.rejectContent,' ') as rejectContent,
                		                                    a.regDate,
                		                                    b.codeName,
                                                            c.carHandlerCode,
                                                            a.companyCode
                                                    FROM	CarData a,
                		                                    CarCategory b,
                		                                    CarHandler c
                                                    WHERE	a.carCategoryCode=b.carCategoryCode
                		                                    AND a.carCode=c.carCode ");
            }
            if (!String.IsNullOrEmpty(txtKey) && type.Equals("car"))
            {
                SQL_SELECT_CAR_DATA_LIST.Append(" AND a.number LIKE '" + txtKey + "%' ");
            }
            else if(!String.IsNullOrEmpty(txtKey))
            {
                SQL_SELECT_CAR_DATA_LIST.Append(" AND a.number+c.handler LIKE '%" + txtKey + "%' ");
            }

            SQL_SELECT_CAR_DATA_LIST.Append(" ORDER BY a.carCode DESC");

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_CAR_DATA_LIST.ToString(), null))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    CarDataInfo obj = new CarDataInfo();
                    obj = bindCarDataInfo(rdr, obj);

                    //Add each item to the arraylist
                    list.Add(obj);
                }
            }

            log.Debug("=================END getCarDataList=================");

            return list;
        }
               
        ///// <summary>
        ///// 차량 목록
        ///// </summary>
        ///// <param name="txtKey"></param>
        ///// <returns></returns>
        //public List<CarDataInfo> getCarDataList(String txtKey)
        //{
        //    log.Debug("=================START getCarDataList=================");
        //    log.Debug("txtKey = " + txtKey);

        //    List<CarDataInfo> list = new List<CarDataInfo>();

        //    String SQL_SELECT_CAR_DATA_LIST = "SELECT ";
        //    SQL_SELECT_CAR_DATA_LIST += " a.carCode,a.carCategoryCode,a.header,a.number,ISNULL(a.handler,' ') as handler,a.reject,ISNULL(a.rejectContent,' ') as rejectContent,a.regDate,b.codeName ";
        //    SQL_SELECT_CAR_DATA_LIST += " FROM CarData a,CarCategory b ";
        //    SQL_SELECT_CAR_DATA_LIST += " WHERE a.carCategoryCode=b.carCategoryCode";

        //    if (!String.IsNullOrEmpty(txtKey))
        //    {
        //        SQL_SELECT_CAR_DATA_LIST += " AND a.number LIKE '%" + txtKey + "%' ";
        //    }
        //    SQL_SELECT_CAR_DATA_LIST += " ORDER BY a.carCode DESC";

        //    //Execute the query against the database
        //    using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_CAR_DATA_LIST, null))
        //    {
        //        // Scroll through the results
        //        while (rdr.Read())
        //        {
        //            CarDataInfo obj = new CarDataInfo(rdr.GetInt32(0), rdr.GetInt16(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetByte(5), rdr.GetString(6), rdr.GetDateTime(7), rdr.GetString(8));

        //            //Add each item to the arraylist
        //            list.Add(obj);
        //        }
        //    }

        //    log.Debug("=================END getCarDataList=================");

        //    return list;
        //}

        ///// <summary>
        ///// 이미 존재하는 차량 정보인지 검색
        ///// </summary>
        ///// <param name="number"></param>
        ///// <returns></returns>
        //public bool existsCarData(String number)
        //{
        //    log.Debug("=================START existsCarData=================");
        //    log.Debug("number = " + number);

        //    object existCount = null;
        //    String existsCarData = "SELECT COUNT(*) FROM CarData WHERE number='" + number + "'";
        //    existCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, existsCarData, null);

        //    log.Debug("=================END existsCarData=================");

        //    if (Convert.ToInt32(existCount) == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }

        //}

        /// <summary>
        /// 이미 존재하는 차량 정보인지 검색
        /// </summary>
        /// <param name="header"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool existsCarData(String header, String number)
        {
            log.Debug("=================START existsCarData=================");
            log.Debug("header = " + header);
            log.Debug("number = " + number);

            object existCount = null;
            String existsCarData = "SELECT COUNT(*) FROM CarData WHERE header=N'" + header + "' AND number='" + number + "'";
            existCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, existsCarData, null);

            log.Debug("=================END existsCarData=================");

            if (Convert.ToInt32(existCount) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool existsCarData(String header, String number, Int32 companyCode)
        {
            log.Debug("=================START existsCarData=================");
            log.Debug("header = " + header);
            log.Debug("number = " + number);
            log.Debug("companyCode = " + companyCode);

            object existCount = null;
            String existsCarData = "SELECT COUNT(*) FROM CarData WHERE header=N'" + header + "' AND number='" + number + "' AND companyCode=" + companyCode;
            existCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, existsCarData, null);

            log.Debug("=================END existsCarData=================");

            if (Convert.ToInt32(existCount) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        ///// <summary>
        ///// 이미 존재하는 차량 정보인지 검색
        ///// </summary>
        ///// <param name="header"></param>
        ///// <param name="number"></param>
        ///// <returns></returns>
        //public bool existsCarData(String header, String number,String handler)
        //{
        //    log.Debug("=================START existsCarData=================");
        //    log.Debug("header = " + header);
        //    log.Debug("number = " + number);
        //    log.Debug("handler = " + handler);

        //    object existCount = null;
        //    String existsCarData = "SELECT COUNT(*) FROM CarData WHERE header='"+header+"' AND number='"+number+"' AND handler = '"+handler+"'";
        //    existCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, existsCarData, null);

        //    log.Debug("=================END existsCarData=================");

        //    if (Convert.ToInt32(existCount) == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }

        //}

        public bool existsCarHandlerData(Int32 carCode, String handler)
        {
            log.Debug("=================START existsCarData=================");
            log.Debug("carCode = " + carCode);
            log.Debug("handler = " + handler);

            object existCount = null;
            String existsCarData = "SELECT COUNT(*) FROM CarHandler WHERE carCode=" + carCode + " AND handler=N'" + handler + "'";
            existCount = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, existsCarData, null);

            log.Debug("=================END existsCarData=================");

            if (Convert.ToInt32(existCount) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 차량 등록
        /// </summary>
        /// <param name="carData"></param>
        /// <returns></returns>
        public int insertCarData(CarDataInfo carData)
        {
            log.Debug("=================START insertCarData=================");
            log.Debug("carData = " + carData.ToString());

            String sql_insert = "INSERT INTO CarData (carCategoryCode,header,number,reject,[rejectContent],regDate,carType,companyName,companyCode)";
            sql_insert += " VALUES";
            sql_insert += " (" + carData.CarCategoryCode + ",N'" + carData.Header + "','" + carData.Number + "'," + carData.Reject + ",N'" + carData.RejectContent.Replace("'", "''") + "',GETDATE()," + carData.CarType + ",N'" + carData.CompanyName + "'," + carData.CompanyCode + ")";

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_insert, null);

            log.Debug("=================END insertCarData=================");

            return result;
        }

        /// <summary>
        /// 차량 수정
        /// </summary>
        /// <param name="carData"></param>
        /// <returns></returns>
        public int updateCarData(CarDataInfo carData)
        {
            log.Debug("=================START updateCarData=================");
            log.Debug("carData = " + carData.ToString());

            StringBuilder sql_car_data_update = new StringBuilder();

            sql_car_data_update.Append("UPDATE CarData SET ");
            sql_car_data_update.Append("carCategoryCode=" + carData.CarCategoryCode + ",");
            sql_car_data_update.Append("header=N'" + carData.Header + "',");
            sql_car_data_update.Append("number='" + carData.Number + "',");
            //sql_car_data_update.Append("handler='" + carData.Handler + "',");
            sql_car_data_update.Append("reject=N'" + carData.Reject + "',");
			sql_car_data_update.Append("rejectContent=N'" + carData.RejectContent.Replace("'", "''") + "',");
            sql_car_data_update.Append("carType=" + carData.CarType + ",");
            sql_car_data_update.Append("companyName=N'" + carData.CompanyName + "',");
            sql_car_data_update.Append("companyCode=" + carData.CompanyCode + " ");
            sql_car_data_update.Append(" WHERE carCode=" + carData.CarCode);

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_car_data_update.ToString(), null);

            log.Debug("=================END updateCarData=================");

            return result;
        }

        public int updateCarData_header(CarDataInfo carData)
        {
            log.Debug("=================START updateCarData=================");
            log.Debug("carData = " + carData.ToString());

            StringBuilder sql_car_data_update = new StringBuilder();

            sql_car_data_update.Append("UPDATE CarData SET ");
            sql_car_data_update.Append("header=N'" + carData.Header + "'");
            sql_car_data_update.Append(" WHERE carCode=" + carData.CarCode);

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_car_data_update.ToString(), null);

            log.Debug("=================END updateCarData=================");

            return result;
        }

        /// <summary>
        /// 차량 삭제
        /// </summary>
        /// <param name="carCode"></param>
        /// <returns></returns>
        public int deleteCarData(Int16 carCode)
        {
            log.Debug("=================START deleteCarData=================");
            log.Debug("carCode = " + carCode.ToString());

            String sql_car_data_delete = "DELETE FROM CarData WHERE carCode=" + carCode;

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_car_data_delete, null);

            log.Debug("=================END deleteCarData=================");

            return result;
        }

        /// <summary>
        /// 운전자 리스트 가져오기
        /// </summary>
        /// <param name="carCode"></param>
        /// <returns></returns>
        public List<CarHandlerInfo> selectCarHandlerList(string carCode)
        {
            log.Debug("=================START selectCarHandlerList=================");
            log.Debug("carCode = " + carCode.ToString());

            List<CarHandlerInfo> list = new List<CarHandlerInfo>();
            StringBuilder sql = new StringBuilder();

            sql.Append(@"
                    SELECT	carHandlerCode,
                            carCode,
                            handler,
                            handlerPhone,
                            regDate,
                            VisFlag
                    FROM	CarHandler
                    WHERE	carCode=" + carCode + @"
                    ORDER BY handler
                      ");

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql.ToString(), null))
            {
                while (rdr.Read())
                {
                    // Scroll through the results
                    CarHandlerInfo obj = new CarHandlerInfo();
                    obj = bindCarHandlerInfo(rdr, obj);

                    //Add each item to the arraylist
                    list.Add(obj);
                }
            }

            return list;

            log.Debug("=================END selectCarHandlerList=================");
        }

        /// <summary>
        /// 승인된 운전자 리스트 가져오기
        /// </summary>
        /// <param name="carCode"></param>
        /// <returns></returns>
        public List<CarHandlerInfo> selectPermitCarHandlerList(string carCode)
        {
            log.Debug("=================START selectPermitCarHandlerList=================");
            log.Debug("carCode = " + carCode.ToString());

            List<CarHandlerInfo> list = new List<CarHandlerInfo>();
            StringBuilder sql = new StringBuilder();

            sql.Append(@"
                    SELECT	carHandlerCode,
                            carCode,
                            handler,
                            handlerPhone,
                            regDate,
                            VisFlag
                    FROM	CarHandler
                    WHERE	carCode=" + carCode + @"
                      AND  VisFlag = 'Y'
                    ORDER BY handler
                      ");

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql.ToString(), null))
            {
                while (rdr.Read())
                {
                    // Scroll through the results
                    CarHandlerInfo obj = new CarHandlerInfo();
                    obj = bindCarHandlerInfo(rdr, obj);

                    //Add each item to the arraylist
                    list.Add(obj);
                }
            }

            return list;

            log.Debug("=================END selectPermitCarHandlerList=================");
        }



        /// <summary>
        /// 운전자 등록
        /// </summary>
        /// <param name="carHandler"></param>
        /// <returns></returns>
        public int insertCarHandler(CarHandlerInfo carHandler)
        {
            log.Debug("=================START insertCarHandler=================");
            log.Debug("carHandler = " + carHandler.ToString());

            String sql_insert = "INSERT INTO CarHandler (carCode,handler,handlerPhone,regDate,VisFlag)";
            sql_insert += "VALUES";
            sql_insert += "(" + carHandler.CarCode + ",N'" + carHandler.Handler + "','" + carHandler.Phone + "',GETDATE(),'Y')";

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_insert, null);

            return result;

            log.Debug("=================END insertCarHandler=================");
            
        }

        /// <summary>
        /// 운전자 수정
        /// </summary>
        /// <param name="carHandler"></param>
        /// <returns></returns>
        public int updateCarHandler(CarHandlerInfo carHandler)
        {
            log.Debug("=================START updateCarHandler=================");
            log.Debug("carHandler = " + carHandler.ToString());

            StringBuilder sql = new StringBuilder();

            sql.Append(@"UPDATE CarHandler SET handler=N'" + carHandler.Handler + "',handlerPhone='" + carHandler.Phone + "',VisFlag='" + carHandler.VisFlag + @"'
                        WHERE carhandlerCode=" + carHandler.CarHandlerCode);
            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql.ToString(), null);

            return result;

            log.Debug("=================END updateCarHandler=================");

        }

        /// <summary>
        /// 2011-02-15-김민우: 입문 처리 시 운전자 전화번호 정보 수정
        /// </summary>
        /// <param name="carHandler"></param>
        /// <returns></returns>
        public int updateCarHandlerPhone(CarHandlerInfo carHandler)
        {
            log.Debug("=================START updateCarHandlerPhone=================");
          
            StringBuilder sql = new StringBuilder();

            sql.Append(@"UPDATE CarHandler SET handlerPhone='" + carHandler.Phone + @"'
                        WHERE carHandlerCode= " + carHandler.CarHandlerCode);
                          //AND handler = '" + carHandler.Handler+ @"'");                                        
            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql.ToString(), null);

            return result;

            log.Debug("=================END updateCarHandlerPhone=================");

        }

        /// <summary>
        /// 운전자 삭제
        /// </summary>
        /// <param name="carCode"></param>
        /// <returns></returns>
        public int deleteCarHandler(CarHandlerInfo carHandler)
        {
            log.Debug("=================START deleteCarhandler=================");
            log.Debug("carHandler = " + carHandler.ToString());

            StringBuilder sql = new StringBuilder();

            sql.Append(@"DELETE FROM CarHandler WHERE carHandlerCode=" + carHandler.CarHandlerCode);

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql.ToString(), null);

            return result;

            log.Debug("=================END deleteCarhandler=================");
        }

        /// <summary>
        /// 최종 등록된 carCode 가져오기
        /// </summary>
        /// <returns></returns>
        public int selectMaxCarCode()
        {
            log.Debug("=================START selectMaxCarCode=================");

            object maxID = null;

            String sql = "SELECT MAX(carCode) FROM CarData";

            maxID = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql.ToString(), null);

            if (maxID == null)
            {
                return Convert.ToInt32("0");
            }
            else
            {
                return Convert.ToInt32(maxID);
            }

            log.Debug("=================END selectMaxCarCode=================");
        }

        /// <summary>
        /// 최종 등록된 carHandlerCode 가져오기
        /// </summary>
        /// <returns></returns>
        public int selectMaxCarHandlerCode()
        {
            log.Debug("=================START selectMaxCarHandlerCode=================");

            object maxID = null;

            String sql = "SELECT MAX(carHandlerCode) FROM CarHandler";

            maxID = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql.ToString(), null);

            if (maxID == null)
            {
                return Convert.ToInt32("0");
            }
            else
            {
                return Convert.ToInt32(maxID);
            }

            log.Debug("=================END selectMaxCarHandlerCode=================");
        }

        /// <summary>
        /// 차량 입출문 조회
        /// </summary>
        /// <param name="keyWord"></param>
        /// <param name="key"></param>
        /// <param name="searchStartDate"></param>
        /// <param name="searchEndDate"></param>
        /// <returns></returns>
        public List<CarVisitDataInfo> selectCarVisitDataList(String keyWord, String key, String searchStartDate, String searchEndDate)
        {
            log.Debug("=================START selectCarVisitDataList=================");

            List<CarVisitDataInfo> list = new List<CarVisitDataInfo>();

            StringBuilder sql = new StringBuilder();
            sql.Append(@"
                            SELECT	b.carCode,
		                            d.carCategoryCode,
		                            b.header,
		                            b.number,
		                            b.reject,
		                            b.rejectContent,
		                            b.carType,
		                            b.companyName,
		                            c.carHandlerCode,
		                            c.handler,
		                            c.handlerPhone,
		                            a.carVisitDataCode,
		                            CONVERT(varchar(19),a.inTime,120) AS inTime,
		                            CONVERT(varchar(19),a.outTime,120) AS outTime,
		                            a.employeeName,
		                            a.etc,
		                            a.regDate
                            FROM	CarVisitData a,
		                            CarData b,
		                            Carhandler c,
		                            CarCategory d
                            WHERE	a.carCode = b.carCode
	                                AND a.carHandlerCode = c.carHandlerCode
	                                AND b.carCategoryCode = d.carCategoryCode ");

            if (!String.IsNullOrEmpty(key))
            {
                if (keyWord.Equals("handler")) sql.Append(" AND c." + keyWord + " LIKE '%" + key + "%' ");
                else sql.Append(" AND b." + keyWord + " LIKE '%" + key + "%' ");
            }

            if (!String.IsNullOrEmpty(searchStartDate) && !String.IsNullOrEmpty(searchEndDate))
            {
                sql.Append(" AND CONVERT(varchar(10),a.regDate,120) BETWEEN '" + searchStartDate + "' AND '" + searchEndDate + "'");
            }

            sql.Append(" ORDER BY a.carVisitDataCode DESC");

            //Execute the query against the database
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql.ToString(), null))
            {
                // Scroll through the results
                while (rdr.Read())
                {
                    CarVisitDataInfo obj = new CarVisitDataInfo();
                    obj = binCarVisitDataInfo(rdr, obj);

                    //Add each item to the arraylist
                    list.Add(obj);
                }
            }

            log.Debug("=================END selectCarVisitDataList=================");

            return list;
        }

        /// <summary>
        /// 차량 입출문 등록
        /// </summary>
        /// <param name="carVisitDataInfo"></param>
        /// <returns></returns>
        public int insertCarVisitData(String type, CarVisitDataInfo carVisitDataInfo)
        {
            log.Debug("=================START insertCarVisitData=================");
            log.Debug("type = " + type.ToString());
            log.Debug("carVisitDataInfo = " + carVisitDataInfo.ToString());

            StringBuilder sql = new StringBuilder();

            if (type.Equals("input"))
            {
                sql.Append(@"INSERT INTO CarVisitData (carCode,inTime,employeeName,etc,regDate,carHandlerCode)
                        VALUES (" + carVisitDataInfo.CarDataInfo.CarCode + ",GETDATE(),N'" + carVisitDataInfo.EmployeeName + "',N'" + carVisitDataInfo.Etc + "(지급)',GETDATE()," + carVisitDataInfo.CarHandlerInfo.CarHandlerCode + ")");
            }
            else
            {
                sql.Append(@"INSERT INTO CarVisitData (carCode,outTime,employeeName,etc,regDate,carHandlerCode)
                        VALUES (" + carVisitDataInfo.CarDataInfo.CarCode + ",GETDATE(),N'" + carVisitDataInfo.EmployeeName + "',N'" + carVisitDataInfo.Etc + "',GETDATE()," + carVisitDataInfo.CarHandlerInfo.CarHandlerCode + ")");
            }

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql.ToString(), null);

            return result;

            log.Debug("=================END insertCarVisitData=================");   
        }

        /// <summary>
        /// 출문
        /// </summary>
        /// <param name="visitDatacode"></param>
        /// <returns></returns>
        public int updateOutTime(int carVisitDataCode)
        {
            log.Debug("=================START updateOutTime=================");
            log.Debug("carVisitDataCode = " + carVisitDataCode);

            StringBuilder sql_update = new StringBuilder();

            sql_update.Append("UPDATE CarVisitData SET outTime=GETDATE(), etc = substring(etc,1,CHARINDEX('(',etc)-1) + '(반납)' WHERE carVisitDataCode=" + carVisitDataCode);

            //sql_update.Append("UPDATE CarVisitData SET outTime=GETDATE() WHERE carVisitDataCode=" + carVisitDataCode);

            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update.ToString(), null);

            log.Debug("=================END updateOutTime=================");

            return result;
        }

        private CarDataInfo bindCarDataInfo(SqlDataReader rdr, CarDataInfo obj)
        {
            obj.CarhandlerInfoList = new List<CarHandlerInfo>();
            obj.CarhandlerInfoList.Add(new CarHandlerInfo());

            obj.CarCode = rdr.GetInt32(0);
            obj.CarCategoryCode = rdr.GetInt16(1);

            if (rdr.IsDBNull(2)) obj.Header = null;
            else obj.Header = rdr.GetString(2);

            obj.Number = rdr.GetString(3);
            obj.CarType = rdr.GetInt32(4).ToString();

            if (rdr.IsDBNull(5)) obj.CompanyName = null;
            else obj.CompanyName = rdr.GetString(5);

            if (rdr.IsDBNull(6)) obj.CarhandlerInfoList[0].Handler = null;
            else obj.CarhandlerInfoList[0].Handler = rdr.GetString(6);

            if (rdr.IsDBNull(7)) obj.CarhandlerInfoList[0].Phone = null;
            else obj.CarhandlerInfoList[0].Phone = rdr.GetString(7);

            obj.Reject = rdr.GetByte(8);
            obj.RejectContent = rdr.GetString(9);
            obj.RegDate = rdr.GetDateTime(10);
            obj.CodeName = rdr.GetString(11);
            obj.CarhandlerInfoList[0].CarHandlerCode = rdr.GetInt32(12);

            if (rdr.IsDBNull(13)) obj.CompanyCode = 0;
            else obj.CompanyCode = rdr.GetInt32(13);

            return obj;
        }

        private CarHandlerInfo bindCarHandlerInfo(SqlDataReader rdr, CarHandlerInfo obj)
        {
            obj.CarHandlerCode = rdr.GetInt32(0);
            obj.CarCode = rdr.GetInt32(1);

            if (rdr.IsDBNull(2)) obj.Handler = null;
            else obj.Handler = rdr.GetString(2);

            if (rdr.IsDBNull(3)) obj.Phone = null;
            else obj.Phone = rdr.GetString(3);

            obj.RegDate = rdr.GetDateTime(4);

            if (rdr.IsDBNull(5)) obj.VisFlag = null;
            else obj.VisFlag = rdr.GetString(5);

            return obj;
        }

        private CarVisitDataInfo binCarVisitDataInfo(SqlDataReader rdr, CarVisitDataInfo obj)
        {
            obj.CarDataInfo = new CarDataInfo(); // 차량정보
            obj.CarHandlerInfo = new CarHandlerInfo(); // 운전자 정보

            obj.CarDataInfo.CarCode = rdr.GetInt32(0);
            obj.CarDataInfo.CarCategoryCode = rdr.GetInt16(1);

            if (rdr.IsDBNull(2)) obj.CarDataInfo.Header = null;
            else obj.CarDataInfo.Header = rdr.GetString(2);

            obj.CarDataInfo.Number = rdr.GetString(3);
            obj.CarDataInfo.Reject = rdr.GetByte(4);
            obj.CarDataInfo.RejectContent = rdr.GetString(5);
            obj.CarDataInfo.CarType = rdr.GetInt32(6).ToString();

            if (rdr.IsDBNull(7)) obj.CarDataInfo.CompanyName = null;
            else obj.CarDataInfo.CompanyName = rdr.GetString(7);

            obj.CarHandlerInfo.CarHandlerCode = rdr.GetInt32(8);

            if (rdr.IsDBNull(9)) obj.CarHandlerInfo.Handler = null;
            else obj.CarHandlerInfo.Handler = rdr.GetString(9);

            if (rdr.IsDBNull(10)) obj.CarHandlerInfo.Phone = null;
            else obj.CarHandlerInfo.Phone = rdr.GetString(10);

            obj.CarVistDataCode = rdr.GetInt32(11);

            if (rdr.IsDBNull(12)) obj.InTime = "-";
            else obj.InTime = rdr.GetString(12);
            //else obj.InTime = HanaMicron.COMS.Utility.DateUtility.getDateFormatColon(rdr.GetDateTime(12));

            if (rdr.IsDBNull(13)) obj.OutTime = "-";
            else obj.OutTime = rdr.GetString(13);
            //else obj.OutTime = HanaMicron.COMS.Utility.DateUtility.getDateFormatColon(rdr.GetDateTime(13));

            if (rdr.IsDBNull(14)) obj.EmployeeName = null;
            else obj.EmployeeName = rdr.GetString(14);

            if (rdr.IsDBNull(15)) obj.Etc = null;
            else obj.Etc = rdr.GetString(15);

            obj.RegDate = rdr.GetDateTime(16).ToString("yyyy.MM.dd");

            return obj;
        }
        #endregion
    }
}