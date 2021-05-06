using System;
using System.Collections.Generic;
using System.Text;

namespace HanaMicron.COMS.Utility
{
	/// <summary>
	/// 자바스크립트 라이브러리
	/// <p>
	/// 프로젝트 명 : 하나마이크론(주) 내방 반출입 관리 프로그램 \n
	/// Name Space : HanaMicron.COMS.Utility \n
	/// File Name : JavaScriptBuilder.cs  \n \n
	/// 작성자 : 김준용(house@hanamicron.co.kr) \n
	/// 작성자 소속 : 하나마이크론(주) 정보시스템팀 \n
	/// 작성일 : 2007-06-22 \n \n
	/// 수정일 :  \n
	/// 수정자 :  \n
	/// 수정 내용 :  \n
	/// </p>
	/// </summary>
	public static class JavaScriptBuilder
	{
		/// <summary>
		/// alert 창 띄우기
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public static String alert(String message)
		{
			StringBuilder rtStr = new StringBuilder();
			rtStr.Append("<script language=\"javascript\" type=\"text/javascript\">");
			rtStr.Append("alert(\"" + message + "\");");
			rtStr.Append("history.go(-1)\n");
			rtStr.Append("</script>");

			return rtStr.ToString();
		}

        /// <summary>
        /// 2010-05-19-임종우 : 메세지창만 띄우는 funtion 추가
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static String alertOnly(String message)
        {
            StringBuilder rtStr = new StringBuilder();
            rtStr.Append("<script language=\"javascript\" type=\"text/javascript\">");
            rtStr.Append("alert(\"" + message + "\");");
            rtStr.Append("</script>");

            return rtStr.ToString();
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="url"></param>
		/// <returns></returns>
		public static String alert(String message, String url)
		{
			StringBuilder rtStr = new StringBuilder();
			rtStr.Append("<script language=\"javascript\" type=\"text/javascript\">");
			rtStr.Append("alert(\"" + message + "\");");
			rtStr.Append("window.location='" + url + "';\n");
			rtStr.Append("</script>");

			return rtStr.ToString();
		}

		/// <summary>
		/// confirm move
		/// </summary>
		/// <param name="message"></param>
		/// <param name="url"></param>
		/// <returns></returns>
		public static String confirmMove(String message, String url)
		{
			StringBuilder rtStr = new StringBuilder();
			rtStr.Append("<script language=\"javascript\" type=\"text/javascript\">");
			rtStr.Append("if (" + message + ") window.location=\"" + url + "\";");
			rtStr.Append("else return false;");
			rtStr.Append("</script>");

			return rtStr.ToString();
		}

		/// <summary>
		/// 창닫기
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public static String close(String message)
		{
			StringBuilder rtStr = new StringBuilder();
			rtStr.Append("<script language=\"javascript\" type=\"text/javascript\">");
			if (!String.IsNullOrEmpty(message))
			{
				rtStr.Append("alert('" + message + "');\n");
			}
			rtStr.Append("self.close();\n");
			rtStr.Append("</script>");
			return rtStr.ToString();
		}

		public static String selfCloseOpenerReload(String message)
		{
			StringBuilder rtStr = new StringBuilder();
			rtStr.Append("<script language=\"javascript\" type=\"text/javascript\">");
			if (!String.IsNullOrEmpty(message))
			{
				rtStr.Append("alert('" + message + "');\n");
			}
			rtStr.Append("self.close();\n");
			rtStr.Append("opener.location.reload();\n");
			rtStr.Append("</script>");
			return rtStr.ToString();
		}
        //2012-02-25-김민우: alert창 확인 누르면 POPUP창 호출한 화면 갱신
        public static String selfCloseOpenerReload(String message, String url)
        {
            StringBuilder rtStr = new StringBuilder();
            rtStr.Append("<script language=\"javascript\" type=\"text/javascript\">");
            rtStr.Append("alert(\"" + message + "\");");
            rtStr.Append("self.close();\n");
            rtStr.Append("opener.location='" + url + "';\n");
            rtStr.Append("</script>");

            return rtStr.ToString();
        }


	}
}
