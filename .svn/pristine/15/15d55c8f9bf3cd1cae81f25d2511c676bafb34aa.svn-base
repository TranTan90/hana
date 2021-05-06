using System.Reflection;
using System.Configuration;
using System;

/// Data Access Layer Factory Class
namespace HanaMicron.COMS.DALFactory
{

    /// <summary>
	/// web.config 에 선언된 WebDAL 설정에 따라 Data Access Layer Object 를 생성한다.
    /// </summary>
    public sealed class DataAccess
    {

        // Look up the DAL implementation we should be using
        private static readonly string path = ConfigurationManager.AppSettings["WebDAL"];

        private DataAccess() { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public static HanaMicron.COMS.IDAL.ICar CreateCar()
		{
			string className = path + ".Car";
			//return (HanaMicron.COMS.IDAL.ICar)Assembly.Load(path).CreateInstance(className);
			
			Type t = Type.GetType("HanaMicron.COMS.IDAL.ICar");
			return (HanaMicron.COMS.IDAL.ICar)Assembly.GetAssembly(t).CreateInstance(className);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static HanaMicron.COMS.IDAL.ICompany CreateCompany()
		{
			string className = path + ".Company";
			//return (HanaMicron.COMS.IDAL.ICompany)Assembly.Load(path).CreateInstance(className);

			Type t = Type.GetType("HanaMicron.COMS.IDAL.ICompany");
			return (HanaMicron.COMS.IDAL.ICompany)Assembly.GetAssembly(t).CreateInstance(className);
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static HanaMicron.COMS.IDAL.IVisitor CreateVisitor()
		{
			string className = path + ".Visitor";
			//return (HanaMicron.COMS.IDAL.IVisitor)Assembly.Load(path).CreateInstance(className);

			Type t = Type.GetType("HanaMicron.COMS.IDAL.IVisitor");
			return (HanaMicron.COMS.IDAL.IVisitor)Assembly.GetAssembly(t).CreateInstance(className);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static HanaMicron.COMS.IDAL.IDepartment CreateDepartment()
		{
			string className = path + ".Department";

			Type t = Type.GetType("HanaMicron.COMS.IDAL.IDepartment");
			return (HanaMicron.COMS.IDAL.IDepartment)Assembly.GetAssembly(t).CreateInstance(className);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static HanaMicron.COMS.IDAL.IEmployee CreateEmployee()
		{
			string className = path + ".Employee";

			Type t = Type.GetType("HanaMicron.COMS.IDAL.IEmployee");
			return (HanaMicron.COMS.IDAL.IEmployee)Assembly.GetAssembly(t).CreateInstance(className);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static HanaMicron.COMS.IDAL.IManager CreateManager()
		{
			string className = path + ".Manager";

			Type t = Type.GetType("HanaMicron.COMS.IDAL.IManager");
			return (HanaMicron.COMS.IDAL.IManager)Assembly.GetAssembly(t).CreateInstance(className);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static HanaMicron.COMS.IDAL.IVisitObject CreateVisitObject()
		{
			string className = path + ".VisitObject";

			Type t = Type.GetType("HanaMicron.COMS.IDAL.IVisitObject");
			return (HanaMicron.COMS.IDAL.IVisitObject)Assembly.GetAssembly(t).CreateInstance(className);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static HanaMicron.COMS.IDAL.IOffice CreateOffice()
		{
			string className = path + ".Office";

			Type t = Type.GetType("HanaMicron.COMS.IDAL.IOffice");
			return (HanaMicron.COMS.IDAL.IOffice)Assembly.GetAssembly(t).CreateInstance(className);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static HanaMicron.COMS.IDAL.IVisitData CreateVisitData()
		{
			string className = path + ".VisitData";

			Type t = Type.GetType("HanaMicron.COMS.IDAL.IVisitData");
			return (HanaMicron.COMS.IDAL.IVisitData)Assembly.GetAssembly(t).CreateInstance(className);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static HanaMicron.COMS.IDAL.IVisitorData CreateVisitorData()
		{
			string className = path + ".VisitorData";

			Type t = Type.GetType("HanaMicron.COMS.IDAL.IVisitorData");
			return (HanaMicron.COMS.IDAL.IVisitorData)Assembly.GetAssembly(t).CreateInstance(className);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static HanaMicron.COMS.IDAL.ITakeOutObject CreateTakeOutObject()
		{
			string className = path + ".TakeOutObject";

			Type t = Type.GetType("HanaMicron.COMS.IDAL.ITakeOutObject");
			return (HanaMicron.COMS.IDAL.ITakeOutObject)Assembly.GetAssembly(t).CreateInstance(className);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static HanaMicron.COMS.IDAL.ITakeOutPathStart CreateTakeOutPathStart()
		{
			string className = path + ".TakeOutPathStart";

			Type t = Type.GetType("HanaMicron.COMS.IDAL.ITakeOutPathStart");
			return (HanaMicron.COMS.IDAL.ITakeOutPathStart)Assembly.GetAssembly(t).CreateInstance(className);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static HanaMicron.COMS.IDAL.ITakeOutPathEnd CreateTakeOutPathEnd()
		{
			string className = path + ".TakeOutPathEnd";

			Type t = Type.GetType("HanaMicron.COMS.IDAL.ITakeOutPathEnd");
			return (HanaMicron.COMS.IDAL.ITakeOutPathEnd)Assembly.GetAssembly(t).CreateInstance(className);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static HanaMicron.COMS.IDAL.IDisApprovalCategory CreateDisApprovalCategory()
		{
			string className = path + ".DisApprovalCategory";

			Type t = Type.GetType("HanaMicron.COMS.IDAL.IDisApprovalCategory");
			return (HanaMicron.COMS.IDAL.IDisApprovalCategory)Assembly.GetAssembly(t).CreateInstance(className);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static HanaMicron.COMS.IDAL.IUnit CreateUnit()
		{
			string className = path + ".Unit";

			Type t = Type.GetType("HanaMicron.COMS.IDAL.IUnit");
			return (HanaMicron.COMS.IDAL.IUnit)Assembly.GetAssembly(t).CreateInstance(className);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static HanaMicron.COMS.IDAL.ITakeOutItemCategory CreateTakeOutItemCategory()
		{
			string className = path + ".TakeOutItemCategory";

			Type t = Type.GetType("HanaMicron.COMS.IDAL.ITakeOutItemCategory");
			return (HanaMicron.COMS.IDAL.ITakeOutItemCategory)Assembly.GetAssembly(t).CreateInstance(className);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static HanaMicron.COMS.IDAL.ITakeOutItemData CreateTakeOutItemData()
		{
			string className = path + ".TakeOutItemData";

			Type t = Type.GetType("HanaMicron.COMS.IDAL.ITakeOutItemData");
			return (HanaMicron.COMS.IDAL.ITakeOutItemData)Assembly.GetAssembly(t).CreateInstance(className);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static HanaMicron.COMS.IDAL.ITakeOutData CreateTakeOutData()
		{
			string className = path + ".TakeOutData";

			Type t = Type.GetType("HanaMicron.COMS.IDAL.ITakeOutData");
			return (HanaMicron.COMS.IDAL.ITakeOutData)Assembly.GetAssembly(t).CreateInstance(className);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static HanaMicron.COMS.IDAL.IElecApprove CreateElecApprove()
        {
            string className = path + ".ElecApprove";

            Type t = Type.GetType("HanaMicron.COMS.IDAL.IElecApprove");
            return (HanaMicron.COMS.IDAL.IElecApprove)Assembly.GetAssembly(t).CreateInstance(className);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static HanaMicron.COMS.IDAL.ISecCardData CreateSecCardData()
        {
            string className = path + ".SecCardData";

            Type t = Type.GetType("HanaMicron.COMS.IDAL.ISecCardData");
            return (HanaMicron.COMS.IDAL.ISecCardData)Assembly.GetAssembly(t).CreateInstance(className);
        }
    }
}