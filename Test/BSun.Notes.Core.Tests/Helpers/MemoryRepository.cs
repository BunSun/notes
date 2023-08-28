namespace BSun.Notes.Core.Tests.Helpers
{
   public sealed class MemoryRepository<T> : IRepository<T> where T : class
   {
      public List<T> Items { get; } = new();

      public T Read(Func<T, bool> predicate)
      {
         return Items.FirstOrDefault(predicate);
      }

      public IEnumerable<T> ReadAll()
      {
         return Items;
      }

      public bool Write(T item)
      {
         if (!Items.Contains(item))
         {
            Items.Add(item);
         }

         return true;
      }
   }
}
