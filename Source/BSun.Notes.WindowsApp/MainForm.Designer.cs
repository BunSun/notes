using System.Drawing;
using System.Windows.Forms;

namespace BSun.Notes.WindowsApp
{
   partial class MainForm
   {
      // private System.ComponentModel.IContainer components = null;
      private TextBox textBoxTitle;
      private TextBox textBoxText;
      private Button buttonSave;

      private void InitializeComponent()
      {
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonNewNote = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(90, 30);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(200, 22);
            this.textBoxTitle.TabIndex = 0;
            this.textBoxTitle.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged_1);
            // 
            // textBoxText
            // 
            this.textBoxText.Location = new System.Drawing.Point(90, 60);
            this.textBoxText.Multiline = true;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(200, 100);
            this.textBoxText.TabIndex = 1;
            this.textBoxText.TextChanged += new System.EventHandler(this.textBoxText_TextChanged_1);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(90, 180);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click_1);
            // 
            // buttonNewNote
            // 
            this.buttonNewNote.Location = new System.Drawing.Point(296, 31);
            this.buttonNewNote.Name = "buttonNewNote";
            this.buttonNewNote.Size = new System.Drawing.Size(27, 19);
            this.buttonNewNote.TabIndex = 3;
            this.buttonNewNote.Text = "+";
            this.buttonNewNote.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(581, 261);
            this.Controls.Add(this.buttonNewNote);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.textBoxText);
            this.Controls.Add(this.buttonSave);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      private Button buttonNewNote;
   }

}
