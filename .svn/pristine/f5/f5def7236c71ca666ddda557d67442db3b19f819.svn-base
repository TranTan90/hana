using System;
using System.Collections.Generic;
using System.Text;
using HanaMicron.COMS.IDAL;
using HanaMicron.COMS.Model;

/// Bisiness Logic Layer 
namespace HanaMicron.COMS.BLL
{
	/// <summary>
	/// 사무실 BLL
	/// </summary>
	public class Office
	{
		private static readonly IOffice dal = HanaMicron.COMS.DALFactory.DataAccess.CreateOffice();

		public OfficeInfo selectOffice(String officeCode)
		{
			return dal.selectOffice(officeCode);
		}

		public List<OfficeInfo> selectOfficeList(String keyWord, String key)
		{
			return dal.selectOfficeList(keyWord, key);
		}

		public int selectOfficeTotal(String keyWord, String key)
		{
			return dal.selectOfficeTotal(keyWord, key);
		}

		public int updateOffice(OfficeInfo office)
		{
			return dal.updateOffice(office);
		}

		public int insertOffice(OfficeInfo office)
		{
			return dal.insertOffice(office);
		}

		public int deleteOffice(OfficeInfo office)
		{
			return dal.deleteOffice(office);
		}
	}
}
