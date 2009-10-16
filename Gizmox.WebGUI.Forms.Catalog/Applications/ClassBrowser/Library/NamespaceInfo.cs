#region Using

using System;
using System.Collections;

#endregion 

namespace Gizmox.WebGUI.Forms.Catalog.Applications.ClassBrowser
{
	/// <summary>
	/// Represents a namespace
	/// </summary>

    [Serializable()]
    public class NamespaceInfo
	{
		#region Class Members

		/// <summary>
		/// All the namespaces with in this namespace
		/// </summary>
		private Hashtable	mobjNamespaces	= new Hashtable();

		/// <summary>
		/// All the types with in this namespace
		/// </summary>
		private ArrayList	mobjTypes		= new ArrayList();

		/// <summary>
		/// The parent namespace
		/// </summary>
		private NamespaceInfo	mobjParent		= null;

		/// <summary>
		/// The namespace name
		/// </summary>
		private string			mstrName		= "";

		/// <summary>
		/// The root namespaces
		/// </summary>
		private static Hashtable	mobjRootNamespaces	= new Hashtable();

		#endregion 

		#region C'Tor\D'Tor

		/// <summary>
		/// Creates a new <see cref="NamespaceInfo"/> instance.
		/// </summary>
		/// <param name="strName">The namespace name</param>
		public NamespaceInfo(string strName)
		{
			mstrName = strName;
		}

		/// <summary>
		/// Creates a new <see cref="NamespaceInfo"/> instance.
		/// </summary>
		/// <param name="objParent">The parent namespace</param>
		/// <param name="strName">The namespace name</param>
		public NamespaceInfo(NamespaceInfo	objParent,string strName)
		{
			mobjParent = objParent;
			mstrName = strName;
		}

		#endregion 

		#region Methods

		/// <summary>
		/// Loads a namespace or a type
		/// </summary>
		/// <param name="arrNamespace">namespace sections.</param>
		/// <param name="intIndex">namespace section index.</param>
		/// <param name="objType">type.</param>
		public void Load(string[] arrNamespace,int intIndex,Type objType)
		{
			if(arrNamespace.Length==intIndex+1)
			{
				mobjTypes.Add(objType);
			}
			else
			{
				NamespaceInfo objNamespace = mobjNamespaces[arrNamespace[intIndex+1]] as NamespaceInfo;
				if(objNamespace==null)
				{
					mobjNamespaces[arrNamespace[intIndex+1]] = objNamespace = new NamespaceInfo(this,arrNamespace[intIndex+1]);
					objNamespace.Load(arrNamespace,intIndex+1,objType);
				}
				else
				{
					objNamespace.Load(arrNamespace,intIndex+1,objType);
				}
			}
		}

		/// <summary>
		/// Gets the root namespace for a given type and loads the all the relevant namespaces.
		/// </summary>
		/// <param name="objType">type.</param>
		/// <returns></returns>
		public static NamespaceInfo GetRootNamespace(Type objType)
		{
			string[] arrNamespace = objType.Namespace.Split('.');
			NamespaceInfo objRootNamespace = mobjRootNamespaces[arrNamespace[0]] as NamespaceInfo;
			if(objRootNamespace==null)
			{
				mobjRootNamespaces[arrNamespace[0]] = objRootNamespace = new NamespaceInfo(arrNamespace[0]);
				objRootNamespace.Load(arrNamespace,0,objType);
			}
			else
			{
				objRootNamespace.Load(arrNamespace,0,objType);
			}
			return objRootNamespace;
		}

		#endregion 

		#region Properties

		/// <summary>
		/// Gets the namespace parent namespace.
		/// </summary>
		/// <value></value>
		public NamespaceInfo ParentNamespace
		{
			get
			{
				return mobjParent;
			}
		}

		/// <summary>
		/// Gets the namespace name.
		/// </summary>
		/// <value></value>
		public string Name
		{
			get
			{
				return mstrName;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this namespace has namespaces.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this namespace has namespaces; otherwise, <c>false</c>.
		/// </value>
		public bool HasNamespaces
		{
			get
			{
				return mobjNamespaces.Count>0;
			}
		}

		/// <summary>
		/// Gets the namespace namespaces.
		/// </summary>
		/// <value></value>
		public ICollection Namespaces
		{
			get
			{
				return mobjNamespaces.Values;
			}
		}

		/// <summary>
		/// Gets the namespace types.
		/// </summary>
		/// <value></value>
		public ICollection Types
		{
			get
			{
				return mobjTypes;
			}
		}

		/// <summary>
		/// Gets the namespace full name.
		/// </summary>
		/// <value></value>
		public string FullName
		{
			get
			{
				ArrayList objNames = new ArrayList();
				NamespaceInfo objNamespace = this;
				while(objNamespace!=null)
				{
					objNames.Add(objNamespace.Name);
					objNamespace = objNamespace.ParentNamespace;
				}

				objNames.Reverse();
				return string.Join(".",(string[])objNames.ToArray(typeof(string)));
			}
		}

		#endregion 
	}
}
