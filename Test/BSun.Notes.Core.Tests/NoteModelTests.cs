using Xunit;
using System;
using BSun.Notes.Core;

namespace BSun.Conceptual.Presentation.Tests
{
   public class NoteModelTests
   {
      [Fact]
      public void ChangingTextRaisesEvent()
      {
         const string expected = "Test Text";

         var actual = string.Empty;
         var note = new Note();
         var subject = new NoteModel(note);
         subject.TextChanged += (sender, e) => { actual = note.Text; };

         subject.Text = expected;

         Assert.Equal(expected, actual);
      }

      [Fact]
      public void ChangingTitleRaisesEvent()
      {
         const string expected = "Test Title";

         var actual = string.Empty;
         var note = new Note();
         var subject = new NoteModel(note);
         subject.TitleChanged += (sender, e) => { actual = note.Title; };

         subject.Title = expected;

         Assert.Equal(expected, actual);
      }

      //[Fact]
      //public void Save_InvokesSavedEvent()
      //{
      //   var model = new NoteModel();
      //   bool eventRaised = false;
      //   model.Saved += (sender, args) => { eventRaised = true; };
      //   model.Save();
      //   Assert.True(eventRaised);
      //}

      //[Fact]
      //public void Save_NoEventHandler_NoException()
      //{
      //   var model = new NoteModel();
      //   Assert.Null(Record.Exception(() => model.Save()));
      //}
   }
}

