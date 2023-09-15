using System;
using System.Collections.Generic;
using System.Text;

namespace BSun.Notes.Core.Presentation
{
   // Schritt 1 - EventArgs Spezialisierung zum Empfang der Daten.
   public sealed class NeedNotesEventArgs : EventArgs
   {
      public IEnumerable<Core.Note> Notes { get; set; }
   }
}
