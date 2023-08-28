using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSun.Notes.Core.Tests
{
   public sealed class NoteControllerTests
   {
      [Fact]
      public void WriteToRepositorySucceeds()
      {
         // Arrange
         var note = new Note { Title = "Test", Text = "Test" };
         var model = new NoteModel(note);
         var repository = new Helpers.MemoryRepository<Note>();
         var subject = new NoteController(model, repository);

         // Act
         subject.SaveNote();

         // Assert
         Assert.Contains(note, repository.Items);
      }
   }
}
