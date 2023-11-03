using System.ComponentModel;
using BSun.Notes.Core.Presentation;
using Moq;

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
      [Fact]
      public void LoadNotesShouldInvokeReadAllOnRepositoryAndUpdateModel()
      {
         // Arrange
         var mockRepository = new Mock<IRepository<Note>>();
         var notes = new List<Note>
            {
                new Note { Title = "Note1", Text = "Content1" },
                new Note { Title = "Note2", Text = "Content2" }
            };
         mockRepository.Setup(repo => repo.ReadAll()).Returns(notes);

         var model = new NotesListModel();
         var controller = new NotesListController(model, mockRepository.Object);

         // Act
         controller.LoadNotes();

         // Assert
         Assert.Equal(notes.Count, ((BindingList<Note>)model.NotesDataSource).Count);
         mockRepository.Verify(repo => repo.ReadAll(), Times.Once);
      }

      [Fact]
      public void NewNote_ShouldCreateNewNoteAndRaiseNewNoteClickedEvent()
      {
         // Arrange
         var mockRepository = new Mock<IRepository<Note>>();
         var model = new NotesListModel();
         var controller = new NotesListController(model, mockRepository.Object);

         var eventRaised = false;
         model.NewNoteClicked += (sender, args) => eventRaised = true;

         // Act
         controller.NewNote();

         // Assert
         Assert.True(eventRaised, "The NewNoteClicked event was not raised.");
      }

      [Fact]
      public void DeleteNote_ShouldRaiseDeleteNoteRequestedEvent()
      {
         // Arrange
         var mockRepository = new Mock<IRepository<Note>>();
         var model = new NotesListModel();
         var controller = new NotesListController(model, mockRepository.Object);

         string? deletedFilePath = null;
         controller.DeleteNoteRequested += (path) => deletedFilePath = path;

         var testNotePath = "test/path/note.txt";

         // Act
         controller.DeleteNote(testNotePath);

         // Assert
         Assert.NotNull(deletedFilePath);
         Assert.Equal(testNotePath, deletedFilePath);
      }
      [Fact]
      public void OpenNote_ShouldRaiseOpenNoteRequestedEvent()
      {
         // Arrange
         var mockRepository = new Mock<IRepository<Note>>();
         var model = new NotesListModel();
         var controller = new NotesListController(model, mockRepository.Object);

         NoteController openedNoteController = null;
         controller.OpenNoteRequested += (noteController) => openedNoteController = noteController;

         var testNotePath = "test/path/note.txt";

         // Act
         controller.OpenNote(testNotePath);

         // Assert
         Assert.NotNull(openedNoteController);
         // Zusätzliche Überprüfungen können hier eingefügt werden, falls notwendig.
      }

   }
}
