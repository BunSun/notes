using System;
using System.Drawing;
using System.Windows.Forms;
using BSun.Notes.Core;

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
         // To customize application configuration such as set high DPI settings or default font,
         // see https://aka.ms/applicationconfiguration.
         //ApplicationConfiguration.Initialize();    

         // Instantiate the NoteModel
         var noteModel = new NoteModel();

         // Instantiate the NoteController with the NoteModel
         var noteController = new NoteController(noteModel);

         // Run the application with Form1 and the NoteController
         Application.Run(new MainForm(noteController));
      }
   }
}
