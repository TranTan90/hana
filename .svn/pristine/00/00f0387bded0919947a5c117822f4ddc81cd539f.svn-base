using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.Model;

namespace HanaMicron.COMS.IDAL
{
	/// <summary>
	/// 방문목적 DAL Interface
	/// </summary>
    public interface IVisitObject
    {
        VisitObjectInfo selectVisitObject(String visitObjectCode);

		List<VisitObjectInfo> selectVisitObjectList();

        List<VisitObjectInfo> selectVisitObjectList(String a);

		int updateVisitObject(VisitObjectInfo visitObjectInfo);

		int insertVisitObject(VisitObjectInfo visitObjectInfo);

		int deleteVisitObject(VisitObjectInfo visitObjectInfo);
    }
}
