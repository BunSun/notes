using Xunit;
using System;
using BSun.Notes.Core;

namespace BSun.Conceptual.Presentation.Tests
{
   public class NoteModelTests
   {
      [Fact]
      public void Title_SetGet()
      {
         var model = new NoteModel();
         model.Title = "Test Title";
         Assert.Equal("Test Title", model.Title);
      }

      [Fact]
      public void Text_SetGet()
      {
         var model = new NoteModel();
         model.Text = "Test Text";
         Assert.Equal("Test Text", model.Text);
      }

      [Fact]
      public void Save_InvokesSavedEvent()
      {
         var model = new NoteModel();
         bool eventRaised = false;
         model.Saved += (sender, args) => { eventRaised = true; };
         model.Save();
         Assert.True(eventRaised);
      }

      [Fact]
      public void Save_NoEventHandler_NoException()
      {
         var model = new NoteModel();
         Assert.Null(Record.Exception(() => model.Save()));
      }
   }
}

