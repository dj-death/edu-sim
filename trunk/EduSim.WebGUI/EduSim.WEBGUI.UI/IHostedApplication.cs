using System;

using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.Catalog
{
	/// <summary>
	/// Summary description for IHostedApplication.
	/// </summary>
	public interface IHostedApplication
	{
		void InitializeApplication();

		HostedToolBarElement[] GetToolBarElements();

		void OnToolBarButtonClick(HostedToolBarButton objButton,EventArgs objEvent);
	}

	#region HostedToolBarElements 

	
    [Serializable()]
    public abstract class HostedToolBarElement
	{
	}


    [Serializable()]
    public class HostedToolBarSeperator : HostedToolBarElement
	{
	}


    [Serializable()]
    public class HostedToolBarButton : HostedToolBarElement
	{
		private ResourceHandle mobjImage = null;
		private string mstrToolTipText = "";
        private string mstrText = "";
		private object mobjTag = null;

		public HostedToolBarButton(string strToolTipText) : this(strToolTipText,null,null)
		{
		}

		public  HostedToolBarButton(string strToolTipText, ResourceHandle objImage): this(strToolTipText,"",objImage,null)
		{
		}

        public HostedToolBarButton(string strToolTipText, ResourceHandle objImage, object objTag): this(strToolTipText, "", objImage, objTag)
        {

        }

		public  HostedToolBarButton(string strToolTipText, string strText, ResourceHandle objImage,object objTag)
		{
			this.mstrToolTipText = strToolTipText;
			this.mobjImage = objImage;
			this.mobjTag = objTag;
            this.mstrText = strText;
		}

		public ResourceHandle Image
		{
			get
			{
				return this.mobjImage;
			}
			set
			{
				this.mobjImage = value;
			}
		}

		public string ToolTipText
		{
			get
			{
				return this.mstrToolTipText;
			}
			set
			{
				this.mstrToolTipText = value;
			}
		}

        public string Text
        {
            get
            {
                return this.mstrText;
            }
            set
            {
                this.mstrText = value;
            }
        }


		public object Tag
		{
			get
			{
				return this.mobjTag;
			}
			set
			{
				this.mobjTag = value;
			}
		}
	}


    [Serializable()]
    public class HostedToolBarToggleButton : HostedToolBarButton
	{
		private bool mblnPushed = false;
		private string mstrGroup = "";

		public HostedToolBarToggleButton(string strToolTipText) : base(strToolTipText)
		{
		}

		public  HostedToolBarToggleButton(string strToolTipText, ResourceHandle objImage): base(strToolTipText,objImage)
		{
		}

		public  HostedToolBarToggleButton(string strToolTipText, ResourceHandle objImage,object objTag): base(strToolTipText,objImage,objTag)
		{
			
		}

		public  HostedToolBarToggleButton(string strToolTipText, ResourceHandle objImage,object objTag,bool blnPushed): base(strToolTipText,objImage,objTag)
		{
			mblnPushed = blnPushed;
		}

		public  HostedToolBarToggleButton(string strToolTipText, ResourceHandle objImage,object objTag,string strGroup): base(strToolTipText,objImage,objTag)
		{
			mstrGroup = strGroup;
		}

		public HostedToolBarToggleButton(string strToolTipText,string strText, ResourceHandle objImage, object objTag)
			: base(strToolTipText, strText, objImage, objTag)
		{

		}

        public HostedToolBarToggleButton(string strToolTipText,string strText, ResourceHandle objImage, object objTag,string strGroup)
            : base(strToolTipText, strText, objImage, objTag)
        {
			mstrGroup = strGroup;
        }

		public bool Pushed
		{
			get
			{
				return mblnPushed;
			}
			set
			{
				mblnPushed = value;
			}
		}

		public string Group
		{
			get
			{
				return mstrGroup;
			}
			set
			{
				mstrGroup = value;
			}
		}
	}
	#endregion
}
