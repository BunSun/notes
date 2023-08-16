using System.Windows.Forms;

namespace BSun.Notes.WindowsApp
{
   partial class NotesListForm
   {
      private void InitializeComponent()
      {
         this.listBoxNotes = new System.Windows.Forms.ListBox();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.openNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.newNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.menuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // listBoxNotes
         // 
         this.listBoxNotes.FormattingEnabled = true;
         this.listBoxNotes.Location = new System.Drawing.Point(12, 27);
         this.listBoxNotes.Name = "listBoxNotes";
         this.listBoxNotes.Size = new System.Drawing.Size(200, 238);
         this.listBoxNotes.TabIndex = 0;
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        this.fileToolStripMenuItem
    });
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(800, 24);
         this.menuStrip1.TabIndex = 1;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        this.openNoteToolStripMenuItem,
        this.newNoteToolStripMenuItem
    });
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "File";
         // 
         // openNoteToolStripMenuItem
         // 
         this.openNoteToolStripMenuItem.Name = "openNoteToolStripMenuItem";
         this.openNoteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
         this.openNoteToolStripMenuItem.Text = "Open Note";
         this.openNoteToolStripMenuItem.Click += new System.EventHandler(this.openNoteToolStripMenuItem_Click);
         // 
         // newNoteToolStripMenuItem
         // 
         this.newNoteToolStripMenuItem.Name = "newNoteToolStripMenuItem";
         this.newNoteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
         this.newNoteToolStripMenuItem.Text = "New Note";
         this.newNoteToolStripMenuItem.Click += new System.EventHandler(this.newNoteToolStripMenuItem_Click);
         // 
         // NotesListForm
         // 
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.listBoxNotes);
         this.Controls.Add(this.menuStrip1);
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "NotesListForm";
         this.Text = "Notes List";
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      private MenuStrip menuStrip1;
      private ToolStripMenuItem fileToolStripMenuItem;
      private ToolStripMenuItem openNoteToolStripMenuItem;
      private ToolStripMenuItem newNoteToolStripMenuItem;

      // Weitere Methoden und Event-Handler...
   }
}
