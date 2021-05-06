using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Model;

namespace HanaMicron.COMS.BLL
{
	/// <summary>
	/// 차량,차종 BLL      xe, Loại xe, BBL
	/// </summary>
    public class Car
    {
		private static readonly ICar dal = HanaMicron.COMS.DALFactory.DataAccess.CreateCar();

		/// <summary>
		/// 차종 정보 가져오기        Thông tin loại xe 
		/// </summary>
		/// <param name="carCategoryID"></param>
		/// <returns></returns>
        public CarCategoryInfo getCarCategory(String carCategoryID)
        {
            return dal.getCarCategory(carCategoryID);
        }

		/// <summary>
		/// 차종 목록  danh mục loại xe
		/// </summary>
		/// <param name="txtKey"></param>
		/// <param name="pageNo"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
        public List<CarCategoryInfo> getCarCategoryList(String txtKey)
        {
            return dal.getCarCategoryList(txtKey);
        }

		/// <summary>
		/// 차종 숫자   Loại xe (chỉ số)
		/// </summary>
		/// <param name="txtKey"></param>
		/// <returns></returns>
        public Int32 getCarCategoryTotal(String txtKey)
        {
			return dal.getCarCategoryTotal(txtKey);
        }

		/// <summary>
		/// 차종 수정   sửa loại xe
		/// </summary>
		/// <param name="carCategoryCode"></param>
		/// <param name="codeName"></param>
		/// <returns></returns>
        public int updateCarCategory(String carCategoryCode, String codeName, String status)
        {
            return dal.updateCarCategory(carCategoryCode, codeName, status);
        }

		/// <summary>
		/// 차종 저장   lưu loại xe 
		/// </summary>
		/// <param name="codeName"></param>
		/// <returns></returns>
        public int insertCarCategory(String codeName,String status)
        {
			return dal.insertCarCategory(codeName,status);
        }

		/// <summary>
		/// 차종 삭제  xóa loại xe 
		/// </summary>
		/// <param name="carCategoryCode"></param>
		/// <returns></returns>
        public int deleteCarCategory(Int16 carCategoryCode)
        {
			return dal.deleteCarCategory(carCategoryCode);
        }

		/// <summary>
		/// 차량 정보 가져오기   Thông tin xe
		/// </summary>
		/// <param name="carCode"></param>
		/// <returns></returns>
        public CarDataInfo getCarData(String type, int code)
        {
            return dal.getCarData(type, code);
        }

		/// <summary>
		/// 차량 숫자     xe (chỉ số)
		/// </summary>
		/// <param name="txtKey"></param>
		/// <returns></returns>
        public int getCarDataTotal(String txtKey)
        {
			return dal.getCarDataTotal(txtKey);
        }

		/// <summary>
		/// 차량 목록 danh mục xe
		/// </summary>
		/// <param name="txtKey"></param>
		/// <param name="pageNo"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
        public List<CarDataInfo> getCarDataList(String type, String txtKey)
        {
            return dal.getCarDataList(type, txtKey);
        }

        /// <summary>
        /// 이미 등록된 차량 여부  
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool existsCarData(String header, String number)
        {
            return dal.existsCarData(header, number);
        }

        /// <summary>
        /// 2018-12-26-임종우 : 업체정보 추가하여 이미 등록 된 차량 검색
        /// </summary>
        /// <param name="header"></param>
        /// <param name="number"></param>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public bool existsCarData(String header, String number, Int32 companyCode)
        {
            return dal.existsCarData(header, number, companyCode);
        }

        /// <summary>
        /// 2010-05-18-임종우 : 이미 등록된 차량 운전자 여부
        /// </summary>
        /// <param name="carCode"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public bool existsCarHandlerData(Int32 carCode, String handler)
        {
            return dal.existsCarHandlerData(carCode, handler);
        }

		/// <summary>
		/// 차량 저장
		/// </summary>
		/// <param name="carData"></param>
		/// <returns></returns>
        public int insertCarData(CarDataInfo carData)
        {
			return dal.insertCarData(carData);
        }

		/// <summary>
		/// 차량 수정
		/// </summary>
		/// <param name="carData"></param>
		/// <returns></returns>
        public int updateCarData(CarDataInfo carData)
        {
			return dal.updateCarData(carData);
        }

        /// <summary>
        /// 2010-05-19-임종우 : 차량 header 수정 추가
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        public int updateCarData_header(CarDataInfo carData)
        {
            return dal.updateCarData_header(carData);
        }

		/// <summary>
		/// 차량 삭제
		/// </summary>
		/// <param name="carCode"></param>
		/// <returns></returns>
        public int deleteCarData(Int16 carCode)
        {
			return dal.deleteCarData(carCode);
        }

        /// <summary>
        /// 운전자 리스트 조회
        /// </summary>
        /// <param name="carCode"></param>
        /// <returns></returns>
        public List<CarHandlerInfo> selectCarHandlerList(String carCode)
        {
            return dal.selectCarHandlerList(carCode);
        }

        /// <summary>
        /// 승인된 운전자 리스트 조회
        /// </summary>
        /// <param name="carCode"></param>
        /// <returns></returns>
        public List<CarHandlerInfo> selectPermitCarHandlerList(String carCode)
        {
            return dal.selectPermitCarHandlerList(carCode);
        }

        /// <summary>
        /// 운전자 등록
        /// </summary>
        /// <param name="carHandler"></param>
        /// <returns></returns>
        public int insertCarHandler(CarHandlerInfo carHandler)
        {
            return dal.insertCarHandler(carHandler);
        }

        /// <summary>
        /// 운전자 수정
        /// </summary>
        /// <param name="carHandler"></param>
        /// <returns></returns>
        public int updateCarHandler(CarHandlerInfo carHandler)
        {
            return dal.updateCarHandler(carHandler);
        }

        /// <summary>
        /// 2011-02-15-김민우: 입문 처리 시 운전자 전화번호 정보 수정
        /// </summary>
        /// <param name="carHandler"></param>
        /// <returns></returns>
        public int updateCarHandlerPhone(CarHandlerInfo carHandler)
        {
            return dal.updateCarHandlerPhone(carHandler);
        }


        /// <summary>
        /// 운전자 삭제
        /// </summary>
        /// <param name="carHandlerInfo"></param>
        /// <returns></returns>
        public int deleteCarHandler(CarHandlerInfo carHandler)
        {
            return dal.deleteCarHandler(carHandler);
        }

        /// <summary>
        /// 최종 등록된 carCode 값 가져오기
        /// </summary>
        /// <returns></returns>
        public int selectMaxCarCode()
        {
            return dal.selectMaxCarCode();
        }

        /// <summary>
        /// 최종 등록된 carHandlerCode 가져오기
        /// </summary>
        /// <returns></returns>
        public int selectMaxCarHandlerCode()
        {
            return dal.selectMaxCarHandlerCode();
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
            if (!String.IsNullOrEmpty(key))
            {
                if (keyWord.Equals("carType"))
                {
                    if (key.Equals("Xe giao hàng (납품차)")) key = "1";
                    else if (key.Equals("Xe nhân viên (임직원차)")) key = "2";
                    else if (key.Equals("Xe công vụ (업무차)")) key = "3";
                    else if (key.Equals("Xe khách thăm (내방객차)")) key = "4";
                    else key= "5";
                }
            }

            return dal.selectCarVisitDataList(keyWord,key,searchStartDate,searchEndDate);
        }

        /// <summary>
        /// 차량 입출문 등록
        /// </summary>
        /// <param name="carVisitDataInfo"></param>
        /// <returns></returns>
        public int insertCarVisitData(String type, CarVisitDataInfo carVisitDataInfo)
        {
            return dal.insertCarVisitData(type,carVisitDataInfo);
        }

        /// <summary>
        /// 출문
        /// </summary>
        /// <param name="carVisitDataCode"></param>
        /// <returns></returns>
        public int updateOutTime(int carVisitDataCode)
        {
            return dal.updateOutTime(carVisitDataCode);
        }

        public String getCarTypeKor(String carType)
        {
            if (carType.Equals("1")) return "Xe giao hàng (납품차)";
            if (carType.Equals("2")) return "Xe nhân viên (임직원차)";
            if (carType.Equals("3")) return "Xe công vụ (업무차)";
            if (carType.Equals("4")) return "Xe khách thăm (내방객차)";
            if (carType.Equals("5")) return "Khác (기타)";

            return "";
        }
    }
}
