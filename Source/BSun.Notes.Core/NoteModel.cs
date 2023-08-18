using System;
using System.IO;

namespace BSun.Notes.Core
{
   public sealed class NoteModel : INoteModel
   {
      private string _title;
      private string _text;
      private string _filePath;

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
         if (string.IsNullOrEmpty(_filePath)) // Verwende den gespeicherten Dateipfad, falls vorhanden
         {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string notesFolderPath = Path.Combine(desktopPath, "Notes");
            Directory.CreateDirectory(notesFolderPath);
            _filePath = Path.Combine(notesFolderPath, $"{Title}.txt"); // Speichere den Dateipfad
         }

         File.WriteAllText(_filePath, Text);
         Saved?.Invoke(this, EventArgs.Empty);
      }
      public void Load(string noteFilePath)
      {
         if (File.Exists(noteFilePath))
         {
            _filePath = noteFilePath; // Speichere den Dateipfad
            Title = Path.GetFileNameWithoutExtension(noteFilePath);
            Text = File.ReadAllText(noteFilePath);
         }
      }
   }
}
