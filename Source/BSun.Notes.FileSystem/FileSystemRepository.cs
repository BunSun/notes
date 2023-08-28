using System;
using System.Collections.Generic;
using BSun.Notes.Core;

namespace BSun.Notes.FileSystem
{
   public sealed class FileSystemRepository : Core.IRepository<Core.Note>
   {
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
         throw new NotImplementedException();
      }

      public bool Write(Note item)
      {
         // Type Cast
         //var fileSystemNote = (FileSystemNote)item;

         if (item is not FileSystemNote fileSystemNote)
         {
            return false;
         }

         var path = System.IO.Path.Combine(_directoryName, fileSystemNote.FileName);
         var contents = string.Join(Environment.NewLine, fileSystemNote.Title, fileSystemNote.Text);

         System.IO.File.WriteAllText(path, contents);

         return true;
      }
   }
}
