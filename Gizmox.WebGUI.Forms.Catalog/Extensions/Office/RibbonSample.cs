/*
' Visual WebGui - http://www.visualwebgui.com
' Copyright (c) 2008
' by Gizmox Inc. ( http://www.gizmox.com )
' Gizmox Assessment Source License 
' 
' Developers, who wish to access and view source code under Gizmox Assessment Source License, 
' must agree to this license. 
' Read it carefully ( http://www.visualwebgui.com/Silverlight/VWGWebmail/demolicense/tabid/476/Default.aspx ). 
' This license prohibits all use of source code other than the viewing of the source code 
' for assessment purposes only
' 
' THIS PROGRAM IS DISTRIBUTED IN THE HOPE THAT IT WILL BE USEFUL, 
' BUT WITHOUT ANY WARRANTY; WITHOUT EVEN THE IMPLIED WARRANTY OF MERCHANTABILITY 
' OR FITNESS FOR A PARTICULAR PURPOSE.
*/

#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using System.IO;

#endregion

namespace Gizmox.WebGUI.Forms.Catalog.Extensions.Office
{
    [Serializable()]
    public partial class RibbonSample : UserControl
    {
        #region Members

        protected int mintUserId = 0;
        protected string mstrUserName = string.Empty;

        #endregion

        #region C'tor
        /// <summary>
        /// Initializes a new instance of the <see cref="WriteEmailForm"/> class.
        /// </summary>
        public RibbonSample()
        {
            InitializeComponent();
            InitializateRibbonBar();
        }
        #endregion

        #region Methods

        private void InitializateRibbonBar()
        {
            ISupportsRibbonBar objSupportsRibbonBar = mobjRichTextEditor as ISupportsRibbonBar;

            if (objSupportsRibbonBar != null)
            {
                objSupportsRibbonBar.ApplyGroup(mobjBasicTextRibbonBarGroup, "BasicText");
                objSupportsRibbonBar.ApplyGroup(mobjProffingRibbonBarGroup, "Proofing");
                objSupportsRibbonBar.ApplyGroup(mobjClipboardRibbonBarGroup, "Clipboard");
                objSupportsRibbonBar.ApplyGroup(mobjFonRibbonBarGroup, "Font");
                objSupportsRibbonBar.ApplyGroup(mobjParagraphRibbonBarGroup, "Paragraph");
                objSupportsRibbonBar.ApplyGroup(mobjZoomRibbonBarGroup, "Zoom");
            }
        }


        #endregion
    }
}
