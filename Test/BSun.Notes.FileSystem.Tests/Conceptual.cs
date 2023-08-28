using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

         var expectedContent = string.Join(Environment.NewLine, title, text);

         var note = new FileSystemNote
         {
            FileName = fileName,
            Text = "Text",
            Title = "Title",
         };

         var repository = new FileSystemRepository(".");

         repository.Write(note);

         // Erwartung:
         // - Datei "foo.note" mit Inhalt "Text" und Titel "Title" existiert
         Assert.True(System.IO.File.Exists(System.IO.Path.Combine(".", fileName)));

         var actualContent = System.IO.File.ReadAllText(System.IO.Path.Combine(".", fileName));
         Assert.Equal(expectedContent, actualContent);
      }
   }
}

namespace BSun.Notes.FileSystem
{
}
