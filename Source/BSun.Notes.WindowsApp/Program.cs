   using System;
   using System.Windows.Forms;

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
            //var noteModel = new NoteModel();
            //var noteController = new NoteController(noteModel);

            //Application.Run(new MainForm(noteController));

            Application.Run(new NotesListForm());
         }
      }
   }
