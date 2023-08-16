using System;
using System.IO;

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
         string notesFolderPath = Path.Combine(desktopPath, "Notes");

         // Erstelle den Ordner, wenn er nicht existiert
         Directory.CreateDirectory(notesFolderPath);

         string noteFilePath = Path.Combine(notesFolderPath, $"{Title}.txt");
         File.WriteAllText(noteFilePath, Text);

         Saved?.Invoke(this, EventArgs.Empty);
      }
      public void Load(string noteFilePath)
      {
         if (File.Exists(noteFilePath))
         {
            Title = Path.GetFileNameWithoutExtension(noteFilePath);
            Text = File.ReadAllText(noteFilePath);
         }
      }
   }
}
