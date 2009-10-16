using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;
using System.Text;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Behaviors
{
	/// <summary>
	/// Summary description for UploadBehavior.
	/// </summary>

    [Serializable()]
    public class UploadBehavior : UserControl
	{
		private Gizmox.WebGUI.Forms.Button mobjButtonUpload;
		private Gizmox.WebGUI.Forms.Label mobjLabelFile;



		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public UploadBehavior()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();


		}

		


		#region Component Designer generated code
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


		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mobjButtonUpload = new Gizmox.WebGUI.Forms.Button();
			this.mobjLabelFile = new Gizmox.WebGUI.Forms.Label();
			this.SuspendLayout();
			// 
			// mobjButtonUpload
			// 
			this.mobjButtonUpload.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.mobjButtonUpload.ClientSize = new System.Drawing.Size(112, 23);
			this.mobjButtonUpload.Location = new System.Drawing.Point(8, 16);
			this.mobjButtonUpload.Name = "mobjButtonUpload";
			this.mobjButtonUpload.Size = new System.Drawing.Size(112, 23);
			this.mobjButtonUpload.TabIndex = 0;
			this.mobjButtonUpload.Text = "Upload";
			this.mobjButtonUpload.Click += new System.EventHandler(this.mobjButtonUpload_Click);
			// 
			// mobjLabelFile
			// 
			this.mobjLabelFile.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjLabelFile.ClientSize = new System.Drawing.Size(544, 544);
			this.mobjLabelFile.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.mobjLabelFile.Location = new System.Drawing.Point(8, 48);
			this.mobjLabelFile.Name = "mobjLabelFile";
            this.mobjLabelFile.Size = new System.Drawing.Size(544, 544);
			this.mobjLabelFile.TabIndex = 1;
			// 
			// UploadBehavior
			// 
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(632, 560);
			this.Controls.Add(this.mobjLabelFile);
			this.Controls.Add(this.mobjButtonUpload);
			this.Size = new System.Drawing.Size(632, 560);
			this.ResumeLayout(false);

		}
		#endregion

		private void mobjButtonUpload_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog objFile = new OpenFileDialog();
			objFile.FileOk+=new CancelEventHandler(objFile_FileOk);
            objFile.MaxFileSize = 1000000;
            //objFile.Filter = "Image files(*.bmp;*.gif;*.jpg)|*.bmp;*.gif;*.jpg";
            objFile.Multiselect = true ;
			objFile.ShowDialog();
		}

		private void objFile_FileOk(object sender, CancelEventArgs e)
		{
			OpenFileDialog objFileDialog = (OpenFileDialog)sender;
            StringBuilder objText = new StringBuilder();
            foreach (string strFile in objFileDialog.FileNames)
            {
                objText.Append(strFile);
                objText.Append("\n");
            }
            objText.AppendFormat(" \nTotal number of files:{0}", objFileDialog.FileNames.Length);
            this.mobjLabelFile.Text = objText.ToString();
		}
	}
}
