using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;
using System.Xml;


namespace Gizmox.WebGUI.Forms.Catalog
{
    /// <summary>
    /// Summary description for MainForm.
    /// </summary>
    [Serializable()]
	public class MainForm : BaseForm
    {

        private Gizmox.WebGUI.Forms.Panel mobjPanelCategory;

        public MainForm()
        {
            InitializeCatalogSections();

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            this.Load += new EventHandler(MainForm_Load);
        }

        protected override void InitialzeWorspace()
        {
            this.mobjPanelCategory = new Gizmox.WebGUI.Forms.Panel();

            // 
            // mobjPanelCategory
            // 
            this.mobjPanelCategory.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.mobjPanelCategory.ClientSize = new System.Drawing.Size(482, 694);
            this.mobjPanelCategory.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanelCategory.Location = new System.Drawing.Point(243, 28);
            this.mobjPanelCategory.Name = "mobjPanelCategory";
            this.mobjPanelCategory.PanelType = Gizmox.WebGUI.Forms.PanelType.Titled;
            this.mobjPanelCategory.Size = new System.Drawing.Size(482, 694);
            this.mobjPanelCategory.TabIndex = 2;
            this.mobjPanelCategory.Text = "Category";

            this.Controls.Add(this.mobjPanelCategory);
        }

        protected override void ClearWorspace()
        {
            mobjPanelCategory.Controls.Clear();
        }

        protected override void AddWorspaceControl(Control objControl)
        {
            mobjPanelCategory.Controls.Add(objControl);
        }



        /// <summary>
        /// Initializes the catalog category node.
        /// </summary>
        /// <param name="objCategoryNode">The obj category node.</param>
        /// <param name="objNodeDefinition">The obj node definition.</param>
        private void InitializeCatalogCategoryNode(CategoryNode objCategoryNode, XmlElement objNodeDefinition)
        {
            // Loop all sub category nodes
            foreach (XmlElement objSubCategoryDefinition in objNodeDefinition.SelectNodes("CatalogNode"))
            {
                // The sub category node
                CategoryNode objSubCategoryNode = null;

                // If has a module defined
                if (objSubCategoryDefinition.HasAttribute("Module"))
                {
                    // Try to get module type definition
                    Type objSubCatalogModuleMappedType = CatalogSettings.GetCatalogModuleTypeByModuleName(objSubCategoryDefinition.GetAttribute("Module"));
                    if (objSubCatalogModuleMappedType != null)
                    {
                        objSubCategoryNode = objCategoryNode.AddCategory(objSubCategoryDefinition.GetAttribute("Label"), objSubCatalogModuleMappedType);
                    }
                }
                else
                {
                    objSubCategoryNode = objCategoryNode.AddCategory(objSubCategoryDefinition.GetAttribute("Label"));
                }

                if (objSubCategoryNode != null)
                {
                    // If is a defalut module
                    if (objSubCategoryDefinition.GetAttribute("Default") == "True")
                    {
                        objSubCategoryNode.SetDefault();
                    }
                }
                else
                {
                    object a = 1;
                }

                // Initialize sub module definition
                InitializeCatalogCategoryNode(objSubCategoryNode, objSubCategoryDefinition);
            }
        }


        /// <summary>
        /// Initializes the catalog sections.
        /// </summary>
        private void InitializeCatalogSections()
        {
            // Loop all catalog sections
            foreach (XmlElement objCatalogSection in CatalogSettings.CatalogSections)
            {
                // The section category node
                CategoryNode objCategoryNode = null;

                // If has icon
                if (objCatalogSection.HasAttribute("Icon"))
                {
                    // Create section
                    objCategoryNode = this.RootCategory.AddCategory(objCatalogSection.GetAttribute("Label"), objCatalogSection.GetAttribute("Icon"));
                }
                else
                {
                    // Create section
                    objCategoryNode = this.RootCategory.AddCategory(objCatalogSection.GetAttribute("Label"));
                }

                // Initialize recursivly
                InitializeCatalogCategoryNode(objCategoryNode, objCatalogSection);
            }


        }

        void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //this.Context.CurrentUICulture = new System.Globalization.CultureInfo("he-IL");
        }
    }
}
