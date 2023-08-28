using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSun.Notes.Core;
using static System.Net.Mime.MediaTypeNames;

namespace BSun.Notes.FileSystem.Tests
{
   public sealed class Conceptual
   {
      [Fact]
      public void WriteConcept()
      {
         const string fileName = "foo.note";
         const string text = "Text";
         const string title = "Title";

         // Ensure file does not exist.
         var path = System.IO.Path.Combine(".", fileName);
         if (System.IO.File.Exists(path)) { System.IO.File.Delete(path); }

         var expectedContent = string.Join(Environment.NewLine, title, text);
         var note = new FileSystemNote
         {
            FileName = fileName,
            Text = "Text",
            Title = "Title",
         };

         var repository = new FileSystemRepository(".");
         repository.Write(note);

         Assert.True(System.IO.File.Exists(path));

         var actualContent = System.IO.File.ReadAllText(System.IO.Path.Combine(".", fileName));
         Assert.Equal(expectedContent, actualContent);
      }

      [Fact]
      public void Foo()
      {
         const string directoryName = ".";

         var note = new Note { Text = "Text", Title = "FooMit\\bösesZeichen" };
         var model = new NoteModel(note);
         var repository = new FileSystemRepository(directoryName);
         var fileName = repository.GetFileNameForTitle(note.Title);

         // Ensure file does not exist.
         var path = System.IO.Path.Combine(directoryName, fileName);
         if (System.IO.File.Exists(path)) { System.IO.File.Delete(path); }

         var subject = new NoteController(model, repository);

         subject.SaveNote();

         Assert.True(System.IO.File.Exists(path));

         var actualContent = System.IO.File.ReadAllText(System.IO.Path.Combine(".", fileName));
         var expectedContent = string.Join(Environment.NewLine, note.Title, note.Text);
         Assert.Equal(expectedContent, actualContent);
      }
   }
}

namespace BSun.Notes.FileSystem
{
}
