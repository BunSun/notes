using System;
using System.IO;

namespace BSun.Notes.Core
{
   public sealed class NoteModel : INoteModel
   {
      private string _title;
      private string _text;
      private string _filePath;
      private string _originalFilePath;

      public event EventHandler Saved;
      public string Category { get; set; }

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
         // Überprüfe, ob ein Dateipfad für die Note festgelegt wurde
         if (string.IsNullOrEmpty(_filePath))
         {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string notesFolderPath = Path.Combine(desktopPath, "Notes");
            Directory.CreateDirectory(notesFolderPath);
            _filePath = Path.Combine(notesFolderPath, $"{Title}.txt");
         }

         // Generiere den neuen Dateipfad basierend auf dem aktuellen Titel
         string newFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Notes", $"{Title}.txt");

         // Wenn der ursprüngliche Dateipfad vorhanden ist und sich von dem neuen Dateipfad unterscheidet,
         // dann lösche die ursprüngliche Datei, da der Titel geändert wurde
         if (!string.IsNullOrEmpty(_originalFilePath) && _originalFilePath != newFilePath)
         {
            if (File.Exists(_originalFilePath))
            {
               File.Delete(_originalFilePath);
            }
         }

         // Aktualisiere _filePath auf den neuen Dateipfad und speichere den Text dort
         _filePath = newFilePath;
         File.WriteAllText(_filePath, Text);

         // Benachrichtige über das Speichern
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
         _originalFilePath = noteFilePath;
      }
   }
}
