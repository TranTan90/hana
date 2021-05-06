using System;
using System.Collections.Generic;
using System.Text;

namespace HanaMicron.COMS.Utility
{
	/// <summary>
	/// 날짜 관련 유틸리티
	/// </summary>
    public static class DateUtility
    {
        // 형식: 2009년6일10일
        public static String getDateFormat(DateTime date)
        {
            String[] dates = date.GetDateTimeFormats();
            
            return dates[5];
        }

        // 형식: 2009-06-10 11:10
        public static String getDateFormat2(DateTime date)
        {
            String[] dates = date.GetDateTimeFormats();

            return dates[60];
        }

        /// <summary>
        /// DateTime -> HH:mm:ss 로 변환
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static String getDateFormatColon(DateTime date)
        {
            String dates = date.ToString("HH:mm:ss");

            return dates;
        }
    }
}
