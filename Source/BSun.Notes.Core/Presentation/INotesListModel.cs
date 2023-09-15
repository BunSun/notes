using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BSun.Notes.Core.Presentation
{
   public interface INotesListModel
   {
      event EventHandler NotesDataSourceChanged;

      // Schritt 1 - Wie sagen wir dem Controller, dass wir Daten benötigen?
      event EventHandler<NeedNotesEventArgs> NeedNotes;

      // Überlegung 1 - Notwendig für Databinding
      IList NotesDataSource { get; }
   }
}
