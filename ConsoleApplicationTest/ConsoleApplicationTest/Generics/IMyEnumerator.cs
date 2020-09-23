using System;

namespace ConsoleApplicationTest.Generics1
{
    public interface IEnumerator
    {
        object Current { get; }

        bool MoveNext();

        void Reset();
    }

    public interface IEnumerator<T> : IEnumerator
    {
        new T Current { get; }
    }

    public interface IEnumerable
    {
        IEnumerator GetEnumerator();
    }

    public interface IEnumerable<T> : IEnumerable
    {
        new IEnumerator<T> GetEnumerator();
    }
}