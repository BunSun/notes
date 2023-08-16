using System;
using System.IO;
using BSun.Notes.Core;

namespace BSun.Notes.Core
{
   public sealed class NoteModel : INoteModel
   {
      private string _title;
      private string _text;

      public event EventHandler Saved;

      public string Title
      {
         get { return _title; }
         set { _title = value; }
      }

      public string Text
      {
         get { return _text; }
         set { _text = value; }
      }

      public void Save()
      {
         string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
         string filePath = Path.Combine(desktopPath, $"{Title}.txt");

         using (StreamWriter writer = new StreamWriter(filePath))
         {
            writer.WriteLine($"{Text}");
         }

         Saved?.Invoke(this, EventArgs.Empty);
      }
   }
}

