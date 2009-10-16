using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Behaviors
{
	/// <summary>
	/// Summary description for ResultsUsage.
	/// </summary>

    [Serializable()]
    public class ResultsUsage : UserControl
	{
		
		
		private Gizmox.WebGUI.Forms.Button mobjButtonSubmit;
		private Gizmox.WebGUI.Forms.TextBox mobjTextResult;
		private System.ComponentModel.IContainer components;

		public ResultsUsage()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();


		}

		

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}

				
			}



			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mobjButtonSubmit = new Gizmox.WebGUI.Forms.Button();
			this.mobjTextResult = new Gizmox.WebGUI.Forms.TextBox();
			this.SuspendLayout();
			// 
			// mobjButtonSubmit
			// 
			this.mobjButtonSubmit.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.mobjButtonSubmit.ClientSize = new System.Drawing.Size(75, 23);
			this.mobjButtonSubmit.Location = new System.Drawing.Point(208, 184);
			this.mobjButtonSubmit.Name = "mobjButtonSubmit";
			this.mobjButtonSubmit.Size = new System.Drawing.Size(75, 23);
			this.mobjButtonSubmit.TabIndex = 0;
			this.mobjButtonSubmit.Text = "Submit";
			this.mobjButtonSubmit.Click += new System.EventHandler(this.mobjButtonSubmit_Click);
			// 
			// mobjTextResult
			// 
			this.mobjTextResult.AcceptsReturn = true;
			this.mobjTextResult.AcceptsTab = true;
			this.mobjTextResult.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.mobjTextResult.ClientSize = new System.Drawing.Size(272, 152);
			this.mobjTextResult.Lines = new string[0];
			this.mobjTextResult.Location = new System.Drawing.Point(8, 24);
			this.mobjTextResult.MaxLength = 0;
			this.mobjTextResult.Multiline = true;
			this.mobjTextResult.Name = "mobjTextResult";
			this.mobjTextResult.ReadOnly = false;
			this.mobjTextResult.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
			this.mobjTextResult.Size = new System.Drawing.Size(272, 152);
			this.mobjTextResult.TabIndex = 1;
			this.mobjTextResult.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
			this.mobjTextResult.Validator = null;
			this.mobjTextResult.WordWrap = false;
			// 
			// ResultsUsage
			// 
			this.ClientSize = new System.Drawing.Size(656, 656);
			this.Controls.Add(this.mobjTextResult);
			this.Controls.Add(this.mobjButtonSubmit);
			this.Size = new System.Drawing.Size(656, 656);
			this.ResumeLayout(false);

		}
		#endregion



		private void mobjButtonSubmit_Click(object sender, System.EventArgs e)
		{
			this.Context.Results["test"] = this.mobjTextResult.Text;
			this.Form.Close();
		}
	}
}
