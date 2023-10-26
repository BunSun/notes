using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using BSun.Notes.Core;

namespace BSun.Notes.FileSystem
{
   public sealed class FileSystemRepository : Core.IRepository<Core.Note>
   {
      public const string Extension = ".txt";

      private readonly string _directoryName;

      public FileSystemRepository(string directoryName)
      {
         _directoryName = directoryName;
      }

      public Note Read(Func<Note, bool> predicate)
      {
         throw new NotImplementedException();
      }

      public IEnumerable<Note> ReadAll()
      {
         var results = new List<Core.Note>();
         foreach (var path in Directory.GetFiles(_directoryName))
         {
            var lines = File.ReadAllLines(path);
            var title = lines[0];
            var text = string.Join(Environment.NewLine, lines.Skip(1));

            var note = new FileSystemNote { Path = path, Text = text, Title = title };

            results.Add(note);
         }


         return results;
      }

      public bool Write(Note item)
      {
         // Type Cast
         //var fileSystemNote = (FileSystemNote)item;

         if (item is not FileSystemNote fileSystemNote)
         {
            fileSystemNote = new FileSystemNote
            {
               Path = GetFileNameForTitle(item.Title),
               Text = item.Text,
               Title = item.Title,
            };

            //return false;
         }

         var path = System.IO.Path.Combine(_directoryName, fileSystemNote.Path);

         // Entferne den Titel aus fileSystemNote.Text

         var textLines = fileSystemNote.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
         if (textLines.Length > 1)
         {
            fileSystemNote.Text = string.Join(Environment.NewLine, textLines.Skip(1));
         }

         // Prüfen, ob die Datei bereits existiert
         if (System.IO.File.Exists(path))
         {
            var existingContent = System.IO.File.ReadAllText(path);

            // Überprüfen, ob der Titel bereits im Inhalt der Datei existiert
            if (!existingContent.StartsWith(fileSystemNote.Title))
            {
               // Wenn nicht, dann füge den Titel und den Text hinzu
               var contents = string.Join(Environment.NewLine, fileSystemNote.Title, fileSystemNote.Text);
               System.IO.File.WriteAllText(path, contents);
            }
            else
            {
               // Wenn der Titel bereits existiert, ersetze nur den Text nach dem Titel
               var lines = existingContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
               if (lines.Length > 0)
               {
                  // Ersetze alles nach dem ersten Zeilenumbruch mit dem neuen Text
                  lines[1] = fileSystemNote.Text;
                  var updatedContent = string.Join(Environment.NewLine, lines[0], fileSystemNote.Text);
                  System.IO.File.WriteAllText(path, updatedContent);
               }
            }
         }
         else
         {
            // Wenn die Datei nicht existiert, schreibe Titel und Text
            var contents = string.Join(Environment.NewLine, fileSystemNote.Title, fileSystemNote.Text);
            System.IO.File.WriteAllText(path, contents);
         }


         return true;
      }

      public string GetFileNameForTitle(string title)
      {
         var invalidFileNameChars = System.IO.Path.GetInvalidFileNameChars();
         var result = new string(title.Select(x => invalidFileNameChars.Contains(x) ? '-' : x).ToArray());

         return result + Extension;
      }
   }
}
