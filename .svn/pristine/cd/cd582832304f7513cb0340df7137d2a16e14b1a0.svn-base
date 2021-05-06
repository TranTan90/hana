using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Model;

/// Bisiness Logic Layer 
namespace HanaMicron.COMS.BLL
{
	/// <summary>
	/// 내방 정보 BLL
	/// </summary>
	public class VisitorData
	{
		private static readonly IVisitorData dal = HanaMicron.COMS.DALFactory.DataAccess.CreateVisitorData();

		public VisitorDataInfo selectVisitorData(string visitorDataCode)
		{
			return dal.selectVisitorData(visitorDataCode);
		}

		public List<VisitorDataInfo> selectVisitorDataList(string keyWord, string key)
		{
			return dal.selectVisitorDataList(keyWord, key);
		}

		public List<VisitorDataInfo> selectVisitorDataList(string visitDataCode)
		{
			return dal.selectVisitorDataList(visitDataCode);
		}

		public int selectVisitorDataTotal(string keyWord, string key)
		{
			return dal.selectVisitorDataTotal(keyWord, key);
		}

		public int updateVisitorData(VisitorDataInfo visitorDataInfo)
		{
			return dal.updateVisitorData(visitorDataInfo);
		}

		public int updateOutTime(VisitorDataInfo visitorDataInfo)
		{
			return dal.updateOutTime(visitorDataInfo);
		}

		public int updateInTime(VisitorDataInfo visitorDataInfo)
		{
			return dal.updateInTime(visitorDataInfo);
		}

		public int insertVisitorData(VisitorDataInfo visitorDataInfo)
		{
			return dal.insertVisitorData(visitorDataInfo);
		}

		public int deleteVisitorData(VisitorDataInfo visitorDataInfo)
		{
			return dal.deleteVisitorData(visitorDataInfo);
		}

        public int selectMaxVisitorDataCode()
        {
            return dal.selectMaxVisitorDataCode();
        }

        public bool checkTodayVisitorData(string visitorCode)
        {
            return dal.checkTodayVisitorData(visitorCode);
        }
	}
}
