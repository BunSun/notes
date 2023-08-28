using System;
using System.Collections.Generic;

namespace BSun.Notes.Core
{
   public interface IRepository<T> where T : class
   {
      T Read(Func<T, bool> predicate);

      IEnumerable<T> ReadAll();

      bool Write(T item);
   }
}
