using System;
using System.Data;
using System.Configuration;
using Gizmox.WebGUI.Common.Configuration;
using System.IO;
using System.Xml;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Catalog
{
    /// <summary>
    /// 
    /// </summary>

    [Serializable()]
    public class CatalogSettings
    {
        #region Class Members

        /// <summary>
        /// Catalog config
        /// </summary>
        private static CatalogSettings mobjCATConfig = null;

        /// <summary>
        /// VWG config
        /// </summary>
        private static Config mobjVWGConfig = null;

        /// <summary>
        /// 
        /// </summary>
        private XmlElement mobjCatalogSettingsSection = null;

        #endregion

        #region C'Tor/D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogSettings"/> class.
        /// </summary>
        /// <param name="objSection">The configuration section.</param>
        internal CatalogSettings(XmlElement objCatalogSettingsSection)
        {
            mobjCatalogSettingsSection = objCatalogSettingsSection;
        }

        /// <summary>
        /// Initializes the <see cref="CatalogSettings"/> class.
        /// </summary>
        static CatalogSettings()
        {
            // Get configuration instances
            mobjVWGConfig = Config.GetInstance();
            mobjCATConfig = CatalogSettings.GetInstance();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the catalog config section.
        /// </summary>
        /// <value>The catalog config section.</value>
        private XmlElement CATConfigSection
        {
            get
            {
                return mobjCatalogSettingsSection;
            }
        }

        /// <summary>
        /// Gets the catalog config.
        /// </summary>
        /// <value>The catalog config.</value>
        private static CatalogSettings CATConfig
        {
            get
            {
                return mobjCATConfig;
            }
        }

        /// <summary>
        /// Gets the webgui config.
        /// </summary>
        /// <value>The webgui config.</value>
        private static Config VWGConfig
        {
            get
            {
                return mobjVWGConfig;
            }
        }

        /// <summary>
        /// Gets the project CHM directory.
        /// </summary>
        /// <value>The project CHM directory.</value>
        public static string ProjectCHM
        {
            get
            {
                return Path.Combine(VWGConfig.GetDirectory("Data"), "Help.chm");
            }
        }

        /// <summary>
        /// Gets the catalog configured modules.
        /// </summary>
        /// <value>The catalog configured modules.</value>
        public static XmlNodeList CatalogModules
        {
            get
            {
                return CATConfig.CATConfigSection.SelectNodes("CatalogModules/CatalogModules");
            }
        }

        /// <summary>
        /// Gets the catalog module.
        /// </summary>
        /// <param name="strName">Name of the STR.</param>
        /// <returns></returns>
        public static XmlElement GetCatalogModule(string strName)
        {
            return (XmlElement)CATConfig.CATConfigSection.SelectSingleNode(string.Format("CatalogModules/CatalogModule[@Name='{0}']",strName));
        }

        /// <summary>
        /// Gets a catalog module type.
        /// </summary>
        /// <param name="strType">Catalog module type.</param>
        /// <returns></returns>
        private static Type GetCatalogModuleType(string strType)
        {
            if (strType.IndexOf(",")>=0)
            {
                return Type.GetType(strType, false);
            }
            else
            {
                return Type.GetType(string.Format("Gizmox.WebGUI.Forms.Catalog.{0}, {1}", strType, typeof(CatalogSettings).Assembly.FullName), false);
            }
        }

        /// <summary>
        /// Gets the type of the catalog module name by module.
        /// </summary>
        /// <param name="strModuleName">Module name.</param>
        public static Type GetCatalogModuleTypeByModuleName(string strModuleName)
        {
            // Get module definition
            XmlElement objSubCatalogModuleDefinition = CatalogSettings.GetCatalogModule(strModuleName);
            if (objSubCatalogModuleDefinition != null)
            {
                // Try to get module type definition
                return CatalogSettings.GetCatalogModuleType(objSubCatalogModuleDefinition.GetAttribute("Type"));
            }
            else
            {
                return null;
            }
        }

        public static void HandleApplicationHostToolBarClick(IHostedApplication objHostedApplication, ToolBar objToolBar, ToolBarButton objToolBarButton, EventArgs objEventArgs)
        {
            
            HostedToolBarToggleButton objHostedToolBarToggleButton = objToolBarButton.Tag as HostedToolBarToggleButton;
            if (objHostedToolBarToggleButton != null)
            {
                if (objHostedToolBarToggleButton.Group != "")
                {
                    if (!objToolBarButton.Pushed)
                    {
                        objToolBarButton.Pushed = true;
                        return;
                    }
                    else
                    {
                        objHostedToolBarToggleButton.Pushed = objToolBarButton.Pushed;
                        foreach (ToolBarButton objButton in objToolBar.Buttons)
                        {
                            HostedToolBarToggleButton objCurrentButton = objButton.Tag as HostedToolBarToggleButton;
                            if (objCurrentButton != null && objCurrentButton != objHostedToolBarToggleButton)
                            {
                                if (objCurrentButton.Group == objHostedToolBarToggleButton.Group)
                                {
                                    objButton.Pushed = false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    objHostedToolBarToggleButton.Pushed = objToolBarButton.Pushed;
                }

            }
            objHostedApplication.OnToolBarButtonClick((HostedToolBarButton)objToolBarButton.Tag, objEventArgs);
        }

        /// <summary>
        /// Initializes the catalog module.
        /// </summary>
        /// <param name="objHostedApplication">The obj hosted application.</param>
        /// <param name="objHostedToolBar">The obj hosted tool bar.</param>
        /// <param name="objClickEventHandler">The obj click event handler.</param>
        public static void InitializeCatalogModule(IHostedApplication objHostedApplication,ToolBar objHostedToolBar, EventHandler objClickEventHandler)
        {
            // Initialize ToolBar application
            objHostedApplication.InitializeApplication();

            // Get hosted toolbar elements
			HostedToolBarElement[] objToolBarElements = objHostedApplication.GetToolBarElements();

            // Check that toolbar needs to be updated
			if(!(objHostedToolBar.Buttons.Count==0 && objToolBarElements.Length==0))
			{
                // Clear toolbar buttons
				objHostedToolBar.Buttons.Clear();

                // Loop all toolbar elements
				foreach(HostedToolBarElement objToolBarElement in objToolBarElements)
				{
					
                    // Get current toolbar button element
					HostedToolBarButton objHostedToolBarButton = objToolBarElement as HostedToolBarButton;
					if(objHostedToolBarButton!=null)
					{
                        // Create new toolbar button
						ToolBarButton objToolBarButton = new ToolBarButton();
						objToolBarButton.ToolTipText = objHostedToolBarButton.ToolTipText;
						objToolBarButton.Image = objHostedToolBarButton.Image;
						objToolBarButton.Text = objHostedToolBarButton.Text;
						objToolBarButton.Tag = objHostedToolBarButton;
						
                        // Try to get toggle button element
						HostedToolBarToggleButton objHostedToolBarToggleButton = objToolBarElement as HostedToolBarToggleButton;
						if(objHostedToolBarToggleButton!=null)
						{
                            // Change toggle style
							objToolBarButton.Style = ToolBarButtonStyle.ToggleButton;
							objToolBarButton.Pushed = objHostedToolBarToggleButton.Pushed;
						}

                        // Attache event handler
						objToolBarButton.Click+=new EventHandler(objClickEventHandler);

                        // Add button and update toolbar
						objHostedToolBar.Buttons.Add(objToolBarButton);
						objHostedToolBar.Update();
					}

                    // If is seperator
					HostedToolBarSeperator objHostedToolBarSeperator = objToolBarElement as HostedToolBarSeperator;
					if(objHostedToolBarSeperator!=null)
					{
                        // Create seperator and add to toolbar
						ToolBarButton objToolBarSeperator = new ToolBarButton();
						objToolBarSeperator.Style = ToolBarButtonStyle.Separator;
						objHostedToolBar.Buttons.Add(objToolBarSeperator);
						
					}
				}
			}
			else if(objHostedToolBar.Buttons.Count!=0 && objToolBarElements.Length==0)
			{
                // Clear buttons if required
				objHostedToolBar.Buttons.Clear();
			}
        }

        /// <summary>
        /// Gets the catalog configured sections.
        /// </summary>
        /// <value>The catalog configured sections.</value>
        public static XmlNodeList CatalogSections
        {
            get
            {
                return CATConfig.CATConfigSection.SelectNodes("CatalogTree/CatalogSection");
            }
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Gets an instance of the catalog settings.
        /// </summary>
        /// <returns></returns>
        internal static CatalogSettings GetInstance()
        {
            return (CatalogSettings)ConfigurationManager.GetSection("WebGUICatalog");
        } 

        #endregion
    }


    #region CatalogConfigHandle class

    /// <summary>
    /// 
    /// </summary>

    [Serializable()]
    internal class CatalogConfigHandler : IConfigurationSectionHandler
    {
        #region IConfigurationSectionHandler Members


        /// <summary>
        /// Creates a configuration object from the given section.
        /// </summary>
        /// <param name="objParent">Section parent.</param>
        /// <param name="objConfigContext">Configuration context.</param>
        /// <param name="objSection">The current section.</param>
        /// <returns></returns>
        public object Create(object objParent, object objConfigContext, XmlNode objSection)
        {
            return new CatalogSettings((XmlElement)objSection);
        }

        #endregion

    }

    #endregion

    #region CatalogModuleRouter class

    /// <summary>
    /// Catalog module form router 
    /// </summary>

    [Serializable()]
    public class CatalogModuleRouter : IFormFactory
    {

        #region ModuleForm class

        /// <summary>
        /// The actual form that will be displayed
        /// </summary>

        [Serializable()]
        private class ModuleForm : Form
        {
            /// <summary>
            /// The current hosted application
            /// </summary>
            private IHostedApplication mobjCurrentHostedApplication = null;

            /// <summary>
            /// The current toolbar
            /// </summary>
            private ToolBar mobjToolBar = null;

            /// <summary>
            /// Initializes a new instance of the <see cref="ModuleForm"/> class.
            /// </summary>
            /// <param name="objModule">The module control.</param>
            public ModuleForm(Control objModuleControl)
            {
                // Add module contlrol
                objModuleControl.Dock = DockStyle.Fill;
                this.Controls.Add(objModuleControl);

                // Create toolbar if is hosted application
                mobjCurrentHostedApplication = objModuleControl as IHostedApplication;
                if (mobjCurrentHostedApplication != null)
                {
                    mobjToolBar = new ToolBar();
                    mobjToolBar.Dock = DockStyle.Top;
                    this.Controls.Add(mobjToolBar);
                    CatalogSettings.InitializeCatalogModule(mobjCurrentHostedApplication, mobjToolBar, new EventHandler(ToolBarButton_Click));
                }


            }

            /// <summary>
            /// Handles the Click event of the ToolBarButton control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            private void ToolBarButton_Click(object sender, EventArgs e)
            {
                if (mobjCurrentHostedApplication != null)
                {
                    CatalogSettings.HandleApplicationHostToolBarClick(mobjCurrentHostedApplication, this.mobjToolBar, (ToolBarButton)sender, e);
                }
            }
        }

        #endregion

        #region IFormFactory Members

        /// <summary>
        /// Creates the application main form.
        /// </summary>
        /// <param name="strCurrentPage">The current page code.</param>
        /// <param name="arrArguments">The application arguments.</param>
        /// <returns>
        /// A form object that will be the main form of the application.
        /// </returns>
        public IForm CreateForm(string strCurrentPage, params object[] arrArguments)
        {
            // Get the current context
            IContext objContext = VWGContext.Current;

            // The module to be dislayed
            Type objModuleType = null;

            // The module control to be displayed
            Control objModuleControl = null;

            // Check valid context and arguments
            if(objContext!=null && objContext.Arguments!=null)
            {
                // Get module type
                string strModuleName = (string)objContext.Arguments["module"];
                if (strModuleName != null)
                {
                    objModuleType = CatalogSettings.GetCatalogModuleTypeByModuleName(strModuleName);
                }
            }

            // Check for valid control
            if (objModuleType == null)
            {
                objModuleType = typeof(UserControl);
            }

            // Create module control
            objModuleControl = (Control)Activator.CreateInstance(objModuleType);

            // Return a new module form
            return new ModuleForm(objModuleControl);
        }

        #endregion
    } 

    #endregion
}
