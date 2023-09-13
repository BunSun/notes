using System;
using System.IO;
using System.Windows.Forms;
using BSun.Notes.FileSystem;

namespace BSun.Notes.WindowsApp
{
   internal static class Program
   {
      /// <summary>
      ///  The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {

         //ApplicationConfiguration.Initialize();

         var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
         var notesFolderPath = Path.Combine(desktopPath, "Notes");
         Directory.CreateDirectory(notesFolderPath);

         var repository = new FileSystemRepository(notesFolderPath);
         var note = new Core.Note();


         var noteModel = new Core.NoteModel(new Core.Note());
         var noteController = new Core.NoteController(noteModel, repository);

         var notesListModel = new Core.Presentation.NotesListModel();
         var notesListController = new Core.Presentation.NotesListController(notesListModel, repository);

         //Application.Run(new MainForm(noteController));
         Application.Run(new NotesListForm(notesListController));

         //Application.Run(new NotesListForm());
      }
   }
}
