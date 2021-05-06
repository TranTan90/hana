/// 
/// 작성자 : 임종우
/// 작성일 : 2008-10-08
/// 
/// 설명
/// 이 파일은 내방 및 반출 관리 시스템중에서 운전자 관리에 필요한 모델을 선언한 파일입니다.
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
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;

/// <summary>
/// Model Object
/// </summary>
namespace HanaMicron.COMS.Model
{
	/// <summary>
	/// 운전자 정보
	/// </summary>
    public class CarHandlerInfo
    {
        //
	    // TODO: 생성자 논리를 여기에 추가합니다.
	    //
        private int carHandlerCode;
        private int carCode;
        private String handler;
        private String phone;
        private DateTime regDate;
        private String visFlag;

        public int CarHandlerCode
        {
            get { return carHandlerCode; }
            set { carHandlerCode = value; }
        }

        public int CarCode
        {
            get { return carCode; }
            set { carCode = value; }
        }

        public String Handler
        {
            get { return handler; }
            set { handler = value; }
        }

        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public DateTime RegDate
        {
            get { return regDate; }
            set { regDate = value; }
        }

        public String VisFlag
        {
            get { return visFlag; }
            set { visFlag = value; }
        }
    }
}