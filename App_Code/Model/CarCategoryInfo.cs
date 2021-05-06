/// 
/// 작성자 : 김준용
/// 작성일 : 2007-05-21
/// 
/// 설명
/// 이 파일은 내방 및 반출 관리 시스템중에서 차량 관리에 필요한 차량 모델을 선언한 파일입니다.
/// Database 컬럼 구조와 동일하게 매칭된 멤버 변수 구조를 가지고 있습니다.
/// 
/// 파일을 수정할 경우 수정자와 수정 내용을 입력하여 주십시요
/// 수정자 : 
/// 수정일 : 
/// 수정 내용
///
///
///
///
///
using System;
using System.Collections.Generic;
using System.Text;

namespace HanaMicron.COMS.Model
{
	/// <summary>
	/// 차종 정보
	/// </summary>
    public class CarCategoryInfo
    {
        private Int16 carCategoryCode;
        private String codeName;
        private DateTime regDate;
        private String status;

        public CarCategoryInfo() { }
        public CarCategoryInfo(Int16 carCategoryCode, String codeName, DateTime regDate)
        {
            this.carCategoryCode = carCategoryCode;
            this.codeName = codeName;
            this.regDate = regDate;
        }
        public CarCategoryInfo(Int16 carCategoryCode, String codeName, DateTime regDate, String status)
        {
            this.carCategoryCode = carCategoryCode;
            this.codeName = codeName;
            this.regDate = regDate;
            this.status = status;
        }

        public Int16 CarCategoryCode
        {
            get { return this.carCategoryCode; }
            set { this.carCategoryCode = value; }
        }

        public String CodeName
        {
            get { return this.codeName; }
            set { this.codeName = value; }
        }

        public DateTime RegDate
        {
            get { return this.regDate; }
            set { this.regDate = value; }
        }

        public String Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public String ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append("carCategoryCode : " + carCategoryCode + "\n");
            str.Append("codeName : " + codeName + "\n");
            str.Append("regDate : " + regDate + "\n");
            str.Append("status : " + status + "\n");
            
            return str.ToString();
        }
    }
}
