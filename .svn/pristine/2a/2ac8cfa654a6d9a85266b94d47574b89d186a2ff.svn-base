using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Model;

/// Bisiness Logic Layer 
namespace HanaMicron.COMS.BLL
{
	/// <summary>
	/// 방문목적 BLL
	/// </summary>
	public class VisitObject
	{
		private static readonly IVisitObject dal = HanaMicron.COMS.DALFactory.DataAccess.CreateVisitObject();

		public VisitObjectInfo selectVisitObject(String visitObjectCode)
		{
			return dal.selectVisitObject(visitObjectCode);
		}

		public List<VisitObjectInfo> selectVisitObjectList()
		{
			return dal.selectVisitObjectList();
		}

        public List<VisitObjectInfo> selectVisitObjectList(String a)
        {
            return dal.selectVisitObjectList(a);
        }

		public int updateVisitObject(VisitObjectInfo visitObjectInfo)
		{
			return dal.updateVisitObject(visitObjectInfo);
		}

		public int insertVisitObject(VisitObjectInfo visitObjectInfo)
		{
			return dal.insertVisitObject(visitObjectInfo);
		}

		public int deleteVisitObject(VisitObjectInfo visitObjectInfo)
		{
			return dal.deleteVisitObject(visitObjectInfo);
		}
	}
}
