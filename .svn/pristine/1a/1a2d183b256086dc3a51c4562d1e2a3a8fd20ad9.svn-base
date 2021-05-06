using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;

namespace HanaMicron.COMS.IDAL
{
	/// <summary>
	/// 차량,차종 DAL Interface
	/// </summary>
    public interface ICar
    {
		/// <summary>
		/// 차종 정보 가져오기
		/// </summary>
		/// <param name="carCategoryID"></param>
		/// <returns></returns>
        CarCategoryInfo getCarCategory(String carCategoryID);

		/// <summary>
		/// 차종 목록
		/// </summary>
		/// <param name="txtKey"></param>
		/// <param name="pageNo"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
        List<CarCategoryInfo> getCarCategoryList(String txtKey);

		/// <summary>
		/// 차종 숫자
		/// </summary>
		/// <param name="txtKey"></param>
		/// <returns></returns>
        Int32 getCarCategoryTotal(String txtKey);

		/// <summary>
		/// 차종 수정
		/// </summary>
		/// <param name="carCategoryCode"></param>
		/// <param name="codeName"></param>
		/// <returns></returns>
        int updateCarCategory(String carCategoryCode, String codeName, String status);

		/// <summary>
		/// 차종 저장
		/// </summary>
		/// <param name="codeName"></param>
		/// <returns></returns>
        int insertCarCategory(String codeName, String status);

		/// <summary>
		/// 차종 삭제
		/// </summary>
		/// <param name="carCategoryCode"></param>
		/// <returns></returns>
        int deleteCarCategory(Int16 carCategoryCode);

		/// <summary>
		/// 차량 정보 가져오기
		/// </summary>
		/// <param name="carCode"></param>
		/// <returns></returns>
        CarDataInfo getCarData(String type, int code);

		/// <summary>
		/// 차량 숫자
		/// </summary>
		/// <param name="txtKey"></param>
		/// <returns></returns>
        int getCarDataTotal(String txtKey);

		/// <summary>
		/// 차량 목록
		/// </summary>
		/// <param name="txtKey"></param>
		/// <param name="pageNo"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
        List<CarDataInfo> getCarDataList(String type, String txtKey);

        /// <summary>
        /// 이미 등록된 차량 여부
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        bool existsCarData(String header, String number);

        ///// <summary>
        ///// 이미 등록된 차량 여부
        ///// </summary>
        ///// <param name="header"></param>
        ///// <param name="number"></param>
        ///// <returns></returns>
        //bool existsCarData(String header, String number);

        /// <summary>
        /// 2010-05-18-임종우 : 이미 등록된 차량운전자 여부
        /// </summary>
        /// <param name="carCode"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        bool existsCarHandlerData(Int32 carCode, String handler);

		/// <summary>
		/// 차량 저장
		/// </summary>
		/// <param name="carData"></param>
		/// <returns></returns>
        int insertCarData(CarDataInfo carData);

		/// <summary>
		/// 차량 수정
		/// </summary>
		/// <param name="carData"></param>
		/// <returns></returns>
        int updateCarData(CarDataInfo carData);


        /// <summary>
        /// 2010-05-19-임종우 : 차량 header 수정 추가
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        int updateCarData_header(CarDataInfo carData);

		/// <summary>
		/// 차량 삭제
		/// </summary>
		/// <param name="carCode"></param>
		/// <returns></returns>
        int deleteCarData(Int16 carCode);

        /// <summary>
        /// 운전자 조회
        /// </summary>
        /// <param name="carCode"></param>
        /// <returns></returns>
        List<CarHandlerInfo> selectCarHandlerList(String carCode);

        /// <summary>
        /// 승인된 운전자 조회
        /// </summary>
        /// <param name="carCode"></param>
        /// <returns></returns>
        List<CarHandlerInfo> selectPermitCarHandlerList(String carCode);

        /// <summary>
        /// 운전자 등록
        /// </summary>
        /// <param name="carHandler"></param>
        /// <returns></returns>
        int insertCarHandler(CarHandlerInfo carHandler);

        /// <summary>
        /// 운전자 수정
        /// </summary>
        /// <param name="carHandler"></param>
        /// <returns></returns>
        int updateCarHandler(CarHandlerInfo carHandler);

        /// <summary>
        /// 2011-02-15-김민우: 입문 처리 시 운전자 전화번호 정보 수정
        /// </summary>
        /// <param name="carHandler"></param>
        /// <returns></returns>
        int updateCarHandlerPhone(CarHandlerInfo carHandler);

        /// <summary>
        /// 운전자 삭제
        /// </summary>
        /// <param name="carCode"></param>
        /// <returns></returns>
        int deleteCarHandler(CarHandlerInfo carHandler);
        
        /// <summary>
        /// 최종 등록된 CarCode 가져오기
        /// </summary>
        /// <returns></returns>
        int selectMaxCarCode();

        /// <summary>
        /// 최종 등록된 carHandlerCode 가져오기
        /// </summary>
        /// <returns></returns>
        int selectMaxCarHandlerCode();

        /// <summary>
        /// 차량 입출문 리스트 조회
        /// </summary>
        /// <param name="keyWord"></param>
        /// <param name="key"></param>
        /// <param name="searchStartDate"></param>
        /// <param name="searchEndDate"></param>
        /// <returns></returns>
        List<CarVisitDataInfo> selectCarVisitDataList(String keyWord, String key, String searchStartDate, String searchEndDate);

        /// <summary>
        /// 차량 입출문 등록
        /// </summary>
        /// <param name="carVisitDataInfo"></param>
        /// <returns></returns>
        int insertCarVisitData(String type, CarVisitDataInfo carVisitDataInfo);

        /// <summary>
        /// 출문
        /// </summary>
        /// <param name="carVisitDataCode"></param>
        /// <returns></returns>
        int updateOutTime(int carVisitDataCode);

        /// <summary>
        /// 2018-12-26-임종우 : 업체정보 추가하여 이미 등록 된 차량 검색
        /// </summary>
        /// <param name="header"></param>
        /// <param name="number"></param>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        bool existsCarData(string header, string number, int companyCode);
    }
}
