/* 프로젝트 명 : 하나마이크론(주) 종합 시스템 인사 기준 정보
 * 파일명 : StringUtil.cs
 * 작성자 : 김준용(house@hanamicron.co.kr)
 * 작성자 소속 : 하나마이크론(주) 정보시스템팀
 * 작성일 : 2007-06-05
 * 설명
 * 문자열 관련 라이브러리
 * 
 * 수정일 : 
 * 수정자 : 
 * 수정 내용 : 
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Web;

/// 유티리티
namespace HanaMicron.COMS.Utility
{
    /// <summary>
    /// 문자열 관리 유틸리티
    /// 
    /// </summary>
    public static class StringUtil
    {
        /// <summary>
        /// 문자열에 숫자가 있는지 검사
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Boolean isHaveNumber(String str)
        {
            RegexOptions options = RegexOptions.None;
            Regex regexNumber = new Regex(@"[\d]", options);
            return regexNumber.IsMatch(str);
        }

        /// <summary>
        /// 문자열에 영문 대소문자가 있는지 검사
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Boolean isHaveLetter(String str)
        {
            RegexOptions options = RegexOptions.None;
            Regex regexLetter = new Regex(@"[a-zA-Z]", options);
            return regexLetter.IsMatch(str);
        }

        /// <summary>
        /// 문자열에 특수문자가 있는지 검사
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Boolean isHaveSpecial(String str)
        {
            RegexOptions options = RegexOptions.None;
            Regex regexSpecial = new Regex(@"[\W]", options);
            return regexSpecial.IsMatch(str);
        }

		public static string ConvertDatabaseString(String str)
		{
			return str.Replace("'", "''");
		}

		/// <summary>
		/// Base64 encodes a string.
		/// </summary>
		/// <param name="input">A string</param>
		/// <returns>A base64 encoded string</returns>
		public static string Base64StringEncode(string input)
		{
			byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(input);
			return Convert.ToBase64String(encbuff);
		}

		/// <summary>
		/// Base64 decodes a string.
		/// </summary>
		/// <param name="input">A base64 encoded string</param>
		/// <returns>A decoded string</returns>
		public static string Base64StringDecode(string input)
		{
			byte[] decbuff = Convert.FromBase64String(input);
			return System.Text.Encoding.UTF8.GetString(decbuff);
		}

		/// <summary>
		/// A case insenstive replace function.
		/// </summary>
		/// <param name="input">The string to examine.</param>
		/// <param name="newValue">The value to replace.</param>
		/// <param name="oldValue">The new value to be inserted</param>
		/// <returns>A string</returns>
		public static string CaseInsenstiveReplace(string input, string newValue, string oldValue)
		{
			Regex regEx = new Regex(oldValue, RegexOptions.IgnoreCase | RegexOptions.Multiline);
			return regEx.Replace(input, newValue);
		}

		/// <summary>
		/// Replaces the first occurence of a string with the replacement value. The Replace
		/// is case senstive
		/// </summary>
		/// <param name="input">The string to examine</param>
		/// <param name="oldValue">The value to replace</param>
		/// <param name="newValue">the new value to be inserted</param>
		/// <returns>A string</returns>
		public static string ReplaceFirst(string input, string oldValue, string newValue)
		{
			Regex regEx = new Regex(oldValue, RegexOptions.Multiline);
			return regEx.Replace(input, newValue, 1);
		}

		/// <summary>
		/// Replaces the last occurence of a string with the replacement value.
		/// The replace is case senstive.
		/// </summary>
		/// <param name="input">The string to examine</param>
		/// <param name="oldValue">The value to replace</param>
		/// <param name="newValue">the new value to be inserted</param>
		/// <returns>A string</returns>
		public static string ReplaceLast(string input, string oldValue, string newValue)
		{
			int index = input.LastIndexOf(oldValue);
			if (index < 0)
			{
				return input;
			}
			else
			{
				StringBuilder sb = new StringBuilder(input.Length - oldValue.Length + newValue.Length);
				sb.Append(input.Substring(0, index));
				sb.Append(newValue);
				sb.Append(input.Substring(index + oldValue.Length, input.Length - index - oldValue.Length));
				return sb.ToString();
			}
		}

		/// <summary>
		/// Removes all the words passed in the filter words parameters. The replace is NOT case
		/// sensitive.
		/// </summary>
		/// <param name="input">The string to search.</param>
		/// <param name="filterWords">The words to repace in the input string.</param>
		/// <returns>A string.</returns>
		public static string FilterWords(string input, params string[] filterWords)
		{
			return StringUtil.FilterWords(input, char.MinValue, filterWords);
		}

		/// <summary>
		/// Removes all the words passed in the filter words parameters. The replace is NOT case
		/// sensitive.
		/// </summary>
		/// <param name="input">The string to search.</param>
		/// <param name="mask">A character that is inserted for each letter of the replaced word.</param>
		/// <param name="filterWords">The words to repace in the input string.</param>
		/// <returns>A string.</returns>
		public static string FilterWords(string input, char mask, params string[] filterWords)
		{
			string stringMask = mask == char.MinValue ? string.Empty : mask.ToString();
			string totalMask = stringMask;

			foreach (string s in filterWords)
			{
				Regex regEx = new Regex(s, RegexOptions.IgnoreCase | RegexOptions.Multiline);

				if (stringMask.Length > 0)
				{
					for (int i = 1; i < s.Length; i++)
						totalMask += stringMask;
				}

				input = regEx.Replace(input, totalMask);

				totalMask = stringMask;
			}

			return input;
		}

		/// <summary>
		/// MD5 encodes the passed string
		/// </summary>
		/// <param name="input">The string to encode.</param>
		/// <returns>An encoded string.</returns>
		public static string MD5String(string input)
		{
			// Create a new instance of the MD5CryptoServiceProvider object.
			MD5 md5Hasher = MD5.Create();

			// Convert the input string to a byte array and compute the hash.
			byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

			// Create a new Stringbuilder to collect the bytes
			// and create a string.
			StringBuilder sBuilder = new StringBuilder();

			// Loop through each byte of the hashed data 
			// and format each one as a hexadecimal string.
			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}

			// Return the hexadecimal string.
			return sBuilder.ToString();
		}

		/// <summary>
		/// Verified a string against the passed MD5 hash.
		/// </summary>
		/// <param name="input">The string to compare.</param>
		/// <param name="hash">The hash to compare against.</param>
		/// <returns>True if the input and the hash are the same, false otherwise.</returns>
		public static bool MD5VerifyString(string input, string hash)
		{
			// Hash the input.
			string hashOfInput = StringUtil.MD5String(input);

			// Create a StringComparer an comare the hashes.
			StringComparer comparer = StringComparer.OrdinalIgnoreCase;

			if (0 == comparer.Compare(hashOfInput, hash))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Left pads the passed input using the HTML non-breaking string entity (&nbsp;)
		/// for the total number of spaces.
		/// </summary>
		/// <param name="input">The string to pad.</param>
		/// <param name="totalSpaces">The total number to pad the string.</param>
		/// <returns>A padded string.</returns>
		public static string PadLeftHtmlSpaces(string input, int totalSpaces)
		{
			string space = "&nbsp;";
			return PadLeft(input, space, totalSpaces * space.Length);
		}

		/// <summary>
		/// Left pads the passed input using the passed pad string
		/// for the total number of spaces.  It will not cut-off the pad even if it 
		/// causes the string to exceed the total width.
		/// </summary>
		/// <param name="input">The string to pad.</param>
		/// <param name="pad">The string to uses as padding.</param>
		/// <param name="totalSpaces">The total number to pad the string.</param>
		/// <returns>A padded string.</returns>
		public static string PadLeft(string input, string pad, int totalWidth)
		{
			return StringUtil.PadLeft(input, pad, totalWidth, false);
		}

		/// <summary>
		/// Left pads the passed input using the passed pad string
		/// for the total number of spaces.  It will cut-off the pad so that  
		/// the string does not exceed the total width.
		/// </summary>
		/// <param name="input">The string to pad.</param>
		/// <param name="pad">The string to uses as padding.</param>
		/// <param name="totalSpaces">The total number to pad the string.</param>
		/// <returns>A padded string.</returns>
		public static string PadLeft(string input, string pad, int totalWidth, bool cutOff)
		{
			if (input.Length >= totalWidth)
				return input;

			int padCount = pad.Length;
			string paddedString = input;

			while (paddedString.Length < totalWidth)
			{
				paddedString += pad;
			}

			// trim the excess.
			if (cutOff)
				paddedString = paddedString.Substring(0, totalWidth);

			return paddedString;
		}

		/// <summary>
		/// Right pads the passed input using the HTML non-breaking string entity (&nbsp;)
		/// for the total number of spaces.
		/// </summary>
		/// <param name="input">The string to pad.</param>
		/// <param name="totalSpaces">The total number to pad the string.</param>
		/// <returns>A padded string.</returns>
		public static string PadRightHtmlSpaces(string input, int totalSpaces)
		{
			string space = "&nbsp;";
			return PadRight(input, space, totalSpaces * space.Length);
		}

		/// <summary>
		/// Right pads the passed input using the passed pad string
		/// for the total number of spaces.  It will not cut-off the pad even if it 
		/// causes the string to exceed the total width.
		/// </summary>
		/// <param name="input">The string to pad.</param>
		/// <param name="pad">The string to uses as padding.</param>
		/// <param name="totalSpaces">The total number to pad the string.</param>
		/// <returns>A padded string.</returns>
		public static string PadRight(string input, string pad, int totalWidth)
		{
			return StringUtil.PadRight(input, pad, totalWidth, false);
		}

		/// <summary>
		/// Right pads the passed input using the passed pad string
		/// for the total number of spaces.  It will cut-off the pad so that  
		/// the string does not exceed the total width.
		/// </summary>
		/// <param name="input">The string to pad.</param>
		/// <param name="pad">The string to uses as padding.</param>
		/// <param name="totalSpaces">The total number to pad the string.</param>
		/// <returns>A padded string.</returns>
		public static string PadRight(string input, string pad, int totalWidth, bool cutOff)
		{
			if (input.Length >= totalWidth)
				return input;

			string paddedString = string.Empty;

			while (paddedString.Length < totalWidth - input.Length)
			{
				paddedString += pad;
			}

			// trim the excess.
			if (cutOff)
				paddedString = paddedString.Substring(0, totalWidth - input.Length);

			paddedString += input;

			return paddedString;
		}

		/// <summary>
		/// Removes the new line (\n) and carriage return (\r) symbols.
		/// </summary>
		/// <param name="input">The string to search.</param>
		/// <returns>A string</returns>
		public static string RemoveNewLines(string input)
		{
			return StringUtil.RemoveNewLines(input, false);
		}

		/// <summary>
		/// Removes the new line (\n) and carriage return (\r) symbols.
		/// </summary>
		/// <param name="input">The string to search.</param>
		/// <param name="addSpace">If true, adds a space (" ") for each newline and carriage
		/// return found.</param>
		/// <returns>A string</returns>
		public static string RemoveNewLines(string input, bool addSpace)
		{
			string replace = string.Empty;
			if (addSpace)
				replace = " ";

			string pattern = @"[\r|\n]";
			Regex regEx = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);

			return regEx.Replace(input, replace);
		}

		/// <summary>
		/// Reverse a string.
		/// </summary>
		/// <param name="input">The string to reverse</param>
		/// <returns>A string</returns>
		public static string Reverse(string input)
		{
			if (input.Length <= 1)
				return input;

			char[] c = input.ToCharArray();
			StringBuilder sb = new StringBuilder(c.Length);
			for (int i = c.Length - 1; i > -1; i--)
				sb.Append(c[i]);

			return sb.ToString();
		}

		/// <summary>
		/// Converts a string to sentence case.
		/// </summary>
		/// <param name="input">The string to convert.</param>
		/// <returns>A string</returns>
		public static string SentenceCase(string input)
		{
			if (input.Length < 1)
				return input;

			string sentence = input.ToLower();
			return sentence[0].ToString().ToUpper() + sentence.Substring(1);
		}

		/// <summary>
		/// Converts all spaces to HTML non-breaking spaces
		/// </summary>
		/// <param name="input">The string to convert.</param>
		/// <returns>A string</returns>
		public static string SpaceToNbsp(string input)
		{
			string space = "&nbsp;";
			return input.Replace(" ", space);
		}

		/// <summary>
		/// Removes all HTML tags from the passed string
		/// </summary>
		/// <param name="input">The string whose values should be replaced.</param>
		/// <returns>A string.</returns>
		public static string StripTags(string input)
		{
			Regex stripTags = new Regex("<(.|\n)+?>");
			return stripTags.Replace(input, "");
		}

		/// <summary>
		/// Converts a string to title case.
		/// </summary>
		/// <param name="input">The string to convert.</param>
		/// <returns>A string.</returns>
		public static string TitleCase(string input)
		{
			return TitleCase(input, true);
		}

		/// <summary>
		/// Converts a string to title case.
		/// </summary>
		/// <param name="input">The string to convert.</param>
		/// <param name="ignoreShortWords">If true, does not capitalize words like
		/// "a", "is", "the", etc.</param>
		/// <returns>A string.</returns>
		public static string TitleCase(string input, bool ignoreShortWords)
		{
			List<string> ignoreWords = null;
			if (ignoreShortWords)
			{
				//TODO: Add more ignore words?
				ignoreWords = new List<string>();
				ignoreWords.Add("a");
				ignoreWords.Add("is");
				ignoreWords.Add("was");
				ignoreWords.Add("the");
			}

			string[] tokens = input.Split(' ');
			StringBuilder sb = new StringBuilder(input.Length);
			foreach (string s in tokens)
			{
				if (ignoreShortWords == true
					&& s != tokens[0]
					&& ignoreWords.Contains(s.ToLower()))
				{
					sb.Append(s + " ");
				}
				else
				{
					sb.Append(s[0].ToString().ToUpper());
					sb.Append(s.Substring(1).ToLower());
					sb.Append(" ");
				}
			}

			return sb.ToString().Trim();
		}

		/// <summary>
		/// Removes multiple spaces between words
		/// </summary>
		/// <param name="input">The string to trim.</param>
		/// <returns>A string.</returns>
		public static string TrimIntraWords(string input)
		{
			Regex regEx = new Regex(@"[\s]+");
			return regEx.Replace(input, " ");
		}

		/// <summary>
		/// Converts the input plain-text to HTML version, replacing carriage returns
		/// and spaces with <br /> and &nbsp;
		/// </summary>
		public static string ConvertToHtml(string content)
		{
			content = HttpUtility.HtmlEncode(content);
			content = content.Replace("  ", "&nbsp;&nbsp;").Replace("\t", "&nbsp;&nbsp;&nbsp;").Replace("\n", "<br />");
			return content;
		}

		/// <summary>
		/// Wraps the passed string up the 
		/// until the next whitespace on or after the total charCount has been reached
		/// for that line.  Uses the environment new line
		/// symbol for the break text.
		/// </summary>
		/// <param name="input">The string to wrap.</param>
		/// <param name="charCount">The number of characters per line.</param>
		/// <returns>A string.</returns>
		public static string WordWrap(string input, int charCount)
		{
			return StringUtil.WordWrap(input, charCount, false, Environment.NewLine);
		}

		/// <summary>
		/// Wraps the passed string up the total number of characters (if cuttOff is true)
		/// or until the next whitespace (if cutOff is false).  Uses the environment new line
		/// symbol for the break text.
		/// </summary>
		/// <param name="input">The string to wrap.</param>
		/// <param name="charCount">The number of characters per line.</param>
		/// <param name="cutOff">If true, will break in the middle of a word.</param>
		/// <returns>A string.</returns>
		public static string WordWrap(string input, int charCount, bool cutOff)
		{
			return StringUtil.WordWrap(input, charCount, cutOff, Environment.NewLine);
		}

		/// <summary>
		/// Wraps the passed string up the total number of characters (if cuttOff is true)
		/// or until the next whitespace (if cutOff is false).  Uses the passed breakText
		/// for lineBreaks.
		/// </summary>
		/// <param name="input">The string to wrap.</param>
		/// <param name="charCount">The number of characters per line.</param>
		/// <param name="cutOff">If true, will break in the middle of a word.</param>
		/// <param name="breakText">The line break text to use.</param>
		/// <returns>A string.</returns>
		public static string WordWrap(string input, int charCount, bool cutOff,
			string breakText)
		{
			StringBuilder sb = new StringBuilder(input.Length + 100);
			int counter = 0;

			if (cutOff)
			{
				while (counter < input.Length)
				{
					if (input.Length > counter + charCount)
					{
						sb.Append(input.Substring(counter, charCount));
						sb.Append(breakText);
					}
					else
					{
						sb.Append(input.Substring(counter));
					}
					counter += charCount;
				}
			}
			else
			{
				string[] strings = input.Split(' ');
				for (int i = 0; i < strings.Length; i++)
				{
					counter += strings[i].Length + 1; // the added one is to represent the inclusion of the space.
					if (i != 0 && counter > charCount)
					{
						sb.Append(breakText);
						counter = 0;
					}

					sb.Append(strings[i] + ' ');
				}
			}
			return sb.ToString().TrimEnd(); // to get rid of the extra space at the end.
		}

		/// <summary>
		/// A wrapper around HttpUtility.HtmlEncode
		/// </summary>
		/// <param name="input">The string to be encoded</param>
		/// <returns>An encoded string</returns>
		public static string HtmlSpecialEntitiesEncode(string input)
		{
			return HttpUtility.HtmlEncode(input);
		}

		/// <summary>
		/// A wrapper around HttpUtility.HtmlDecode
		/// </summary>
		/// <param name="input">The string to be decoded</param>
		/// <returns>The decode string</returns>
		public static string HtmlSpecialEntitiesDecode(string input)
		{
			return HttpUtility.HtmlDecode(input);
		}

		/// <summary>
		/// 주민 등록 번호 검사
		/// </summary>
		/// <param name="firstPart"></param>
		/// <param name="lastPart"></param>
		/// <returns></returns>
		public static bool CheckSocialNumber(string firstPart, string lastPart)
		{
			string socialNo = firstPart.Trim() + lastPart.Trim();

			// 정규식 패턴 문자열입니다. 6자리의 정수 + [1, 2, 3, 4 중 택 1] + 6자리의 정수
			string pattern = @"\d{6}[1234]\d{6}";

			// 입력 내역과 정규식 패턴이 일치하면 이 조건문을 통과합니다.
			if (!Regex.Match(socialNo, pattern, RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace).Success)
				return false;

			// 20세기 출생자와 21세기 출생자를 구분합니다.
			string birthYear = ('2' >= socialNo[6]) ? "19" : "20";

			// 연도 두 자리를 추출하여 추가합니다.
			birthYear += socialNo.Substring(0, 2);

			// 월 단위 두 자리를 추출합니다.
			string birthMonth = socialNo.Substring(2, 2);

			// 일 단위 두 자리를 추출합니다.
			string birthDate = socialNo.Substring(4, 2);

			try
			{
				// 정수로 변환을 시도합니다. 예외가 생기면 catch 블럭으로 이동됩니다.
				int bYear = int.Parse(birthYear);
				int bMonth = int.Parse(birthMonth);
				int bDate = int.Parse(birthDate);

				// 20세기보다 이전연도, 21세기보다 이후연도,
				// 월 표기 수가 1보다 작은 값, 월 표기 수가 12보다 큰 값,
				// 일 표기 수가 1보다 작은 값, 일 표기 수가 12보다 큰 값에 해당되면
				// catch 블럭으로 이동됩니다.
				if (bYear < 1900 || bYear > 2100 || bMonth < 1 || bMonth > 12 || bDate < 1 || bDate > 31)
					throw new Exception("잘못된 날짜 표현입니다.");
			}
			catch { return false; }

			// 고유 알고리즘입니다.
			int[] buffer = new int[13];

			for (int i = 0; i < buffer.Length; i++)
				buffer[i] = Int32.Parse(socialNo[i].ToString());

			int summary = 0;
			int[] multipliers = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5 };

			for (int i = 0; i < 12; i++)
				summary += (buffer[i] *= multipliers[i]);

			return !((11 - (summary % 11)) % 10 != buffer[12]);
		}

        //김민우
        /// <summary>
        /// 생년월일 검사
        /// </summary>
        /// <param name="firstPart"></param>
        /// <param name="lastPart"></param>
        /// <returns></returns>
        public static bool CheckBirthDay(string firstPart)
        {
            string birthDay = firstPart.Trim();

            // 정규식 패턴 문자열입니다. 6자리의 정수
            string pattern = @"\d{6}";

            // 입력 내역과 정규식 패턴이 일치하면 이 조건문을 통과합니다.
            if (!Regex.Match(birthDay, pattern, RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace).Success)
                return false;

            // 연도 두 자리를 추출하여 추가합니다.
            string birthYear = birthDay.Substring(0, 2);

            // 월 단위 두 자리를 추출합니다.
            string birthMonth = birthDay.Substring(2, 2);

            // 일 단위 두 자리를 추출합니다.
            string birthDate = birthDay.Substring(4, 2);

            try
            {
                // 정수로 변환을 시도합니다. 예외가 생기면 catch 블럭으로 이동됩니다.
                int bYear = int.Parse(birthYear);
                int bMonth = int.Parse(birthMonth);
                int bDate = int.Parse(birthDate);

                // 20세기보다 이전연도, 21세기보다 이후연도,
                // 월 표기 수가 1보다 작은 값, 월 표기 수가 12보다 큰 값,
                // 일 표기 수가 1보다 작은 값, 일 표기 수가 12보다 큰 값에 해당되면
                // catch 블럭으로 이동됩니다.
                if (bYear < 0 || bYear > 99 || bMonth < 1 || bMonth > 12 || bDate < 1 || bDate > 31)
                    throw new Exception("잘못된 날짜 표현입니다.");
               
            }
            catch { return false; }
            return true;
        }


        /// <summary>
        /// 주어진 길이의 랜덤 숫자를 생성 합니다.
        /// </summary>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static String GetRandomNumber(int maxLength)
        {
            Random random = new Random(maxLength);
            //String randomString = String.Empty;
            String randomString = "";

            String RNDValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            for (int i = 0; i < maxLength; i++)
            {
                //int randomInteger = random.Next(0,9);
                int randomInteger = random.Next(36);
                //randomString += randomInteger.ToString();
                randomString += RNDValue.Substring(randomInteger, 1);
            }
            return randomString;
        }

		/// <summary>
		/// 주어진 길이의 난수(영어숫자혼합)를 생성 합니다.
        /// 2012-08-18-김민우: 
		/// </summary>
		/// <param name="maxLength"></param>
		/// <returns></returns>
		public static String GetRandomNumber(Random random, int maxLength)
		{
			//Random random = new Random(maxLength);
			//String randomString = String.Empty;
            String randomString = "";

            String RNDValue = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

			for (int i = 0; i < maxLength; i++)
			{
				//int randomInteger = random.Next(0,9);
                int randomInteger = random.Next(36);
				//randomString += randomInteger.ToString();
                randomString += RNDValue.Substring(randomInteger,1);
			}
			return randomString;
		}

		/// <summary>
		/// 주어진 문자열에서 특수 문자를 제거한다.
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static String ReplaceSpecial(String str)
		{
			RegexOptions options = RegexOptions.None;
			Regex regexSpecial = new Regex(@"[\W]", options);
			return regexSpecial.Replace(str, "");
		}

        /// <summary>
        /// 주어진 길이만큼 글자 잘라내고 대체글자 넣기
        /// </summary>
        /// <param name="src"></param>
        /// <param name="toLength"></param>
        /// <param name="suffixStr"></param>
        /// <returns></returns>
        public static string GetShortString(string src, double toLength, string suffixStr)
        {
            double Length = 0;
            int i, j;
            string Value = src;

            for (i = 0, j = Value.Length; i < j; i++)
            {
                char C = Value[i];
                Length += (Char.GetUnicodeCategory(C).ToString() == "OtherLetter") ? 1.85 : 1;

                if (Length > toLength)
                {
                    break;
                }
            }

            String newString = "";

            if (Value.Length > i) newString = Value.Substring(0, i) + suffixStr;
            else newString = Value.Substring(0, i);

            return newString;
        }
	}
}
