#region Using

using System;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Configuration;
using System.Collections.Specialized;

#endregion 

namespace Gizmox.WebGUI.Forms.Catalog.Applications.ClassBrowser
{
	/// <summary>
	/// Summary description for ConsoleInfo.
	/// </summary>

    [Serializable()]
    public class ConsoleInfo
	{

		#region Static Members

		/// <summary>
		/// Holds all root namespaces
		/// </summary>
		private static ArrayList mobjNamespaces;

		/// <summary>
		/// Holds all types
		/// </summary>
		private static ArrayList mobjTypes;

		#endregion 

		#region Static Methods

		/// <summary>
		/// Get all the types that this type is derived from
		/// </summary>
		/// <param name="objType"></param>
		/// <returns></returns>
		public static Type[] GetHierarcyObjects(Type objType)
		{
			ArrayList objTypes = new ArrayList();
			Type objCurrent = objType.BaseType;
			while(objCurrent!=null)
			{
				objTypes.Add(objCurrent);
				objCurrent = objCurrent.BaseType;
			}
			return (Type[])objTypes.ToArray(typeof(Type));
		}

		/// <summary>
		/// Get parameters string of a given method
		/// </summary>
		/// <param name="objMethod"></param>
		/// <returns></returns>
		public static string GetParameters(MethodInfo objMethod)
		{
			StringBuilder objBuffer = new StringBuilder();
			foreach(ParameterInfo objParameter in objMethod.GetParameters())
			{
				if(objBuffer.Length>0) objBuffer.Append(" ,");
				objBuffer.Append(objParameter.ParameterType.Name + " " + objParameter.Name);
			}
			return objBuffer.ToString();
		}

		/// <summary>
		/// Get all root namespaces
		/// </summary>
		public static ICollection Namespaces
		{
			get
			{
				if(mobjNamespaces==null)
				{
					mobjNamespaces = new ArrayList();

					foreach(Type objType in Types)
					{
						if(objType.Namespace!=null)
						{
							NamespaceInfo objRootNamespace = NamespaceInfo.GetRootNamespace(objType);
							if(!mobjNamespaces.Contains(objRootNamespace))
							{
								mobjNamespaces.Add(objRootNamespace);
							}
						}
					}
				}
				return mobjNamespaces;
			}
		}

		/// <summary>
		/// Get all types
		/// </summary>
		private static ICollection Types
		{
			get
			{
				if(mobjTypes==null)
				{
					mobjTypes = new ArrayList();

					NameValueCollection objNamespaceSettings = (NameValueCollection)ConfigurationManager.GetSection("ClassBrowser");
					for (int i=0;i<objNamespaceSettings.Count;i++) 
					{
						Assembly objAssembly = Assembly.Load(objNamespaceSettings[i].ToString());
						Type[] objTypes = objAssembly.GetTypes();
						foreach(Type objType in objTypes)
						{
							mobjTypes.Add(objType);
						}
					}
				}

				return mobjTypes;
			}
		}

		/// <summary>
		/// Get the root namespace object of a namespace
		/// </summary>
		/// <param name="strNamespace"></param>
		/// <returns></returns>
		private static string GetNamespaceRoot(string strNamespace)
		{
			string[] arrNamespace = strNamespace.Split('.');
			return arrNamespace[0];
		}

		/// <summary>
		/// Get namespaces for a given name space
		/// </summary>
		/// <param name="strNamespace"></param>
		/// <returns></returns>
		public static ICollection GetNamespaces(string strNamespace)
		{
			ArrayList objNamespaceList = new ArrayList();

			if(strNamespace!=null)
			{
				string[] arrNamespace = strNamespace.Split('.');
				NamespaceInfo objCurrentNamespace = null;
				foreach(NamespaceInfo objNamespace in mobjNamespaces)
				{
					if(objNamespace.Name==arrNamespace[0])
					{
						objCurrentNamespace = objNamespace;

						objNamespaceList.Add(objNamespace);
						break;
					}
				}
				if(objCurrentNamespace!=null)
				{

					for(int intIndex=1;intIndex< arrNamespace.Length;intIndex++)
					{
						if(objCurrentNamespace!=null)
						{
							foreach(NamespaceInfo objNamespace in objCurrentNamespace.Namespaces)
							{
								if(objNamespace.Name==arrNamespace[intIndex])
								{
									objCurrentNamespace = objNamespace;
									objNamespaceList.Add(objNamespace);
									break;
								}
							}
						}
					}
				}
			}

			return objNamespaceList;
		}
		

		#endregion 

	}
}
