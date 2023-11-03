namespace BSun.Notes.Core
{
   public sealed class NoteController
   {
      private readonly IRepository<Note> _repository;

      private readonly NoteModel _model;

      public NoteController(NoteModel model, IRepository<Note> repository)
      {
         _model = model;
         _repository = repository;
      }

      public INoteModel Model { get { return _model; } }


      public void ChangeText(string text)
      {
         _model.Text = text;
      }

      public void ChangeTitle(string title)
      {
         _model.Title = title;
      }

      public void SaveNote()
      {
      bool succeeded = _repository.Write(_model.Note);
         
         if (succeeded)
         {
            _model.RaiseSaved();
            // TODO Trigger model?
         }
      }
   }
}
