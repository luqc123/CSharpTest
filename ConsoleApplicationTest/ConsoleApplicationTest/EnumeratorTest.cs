using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    public sealed class EnumeratorTest
    {
        public static void Main()
        {
            //var test = new EnumeratorTest();
            //test.Test1();
            //var test2 = new MusicTitles();
            //test2.Test2();
            var test3 = new GameMoves();
            test3.Test3();
        }

        private class HelloCollection
        {
            public IEnumerator<string> GetEnumerator()
            {
                yield return "Hello";
                yield return "World";
            }
        }

                                                     
        public void Test1()
        {
            var helloCollection = new HelloCollection();
            foreach (var s in helloCollection)
                Console.WriteLine(s);
        }
    }

    public sealed class HelloCollection
    {
        public IEnumerator GetEumerator()
        {
            return new Enumerator(0);
        }

        public class Enumerator : IEnumerator<string>, IEnumerator, IDisposable
        {
            private int state;
            private string current;

            public Enumerator(int state)
            {
                this.state = state;
            }

            bool IEnumerator.MoveNext()
            {
                switch (state)
                {
                    case 0:
                        current = "Hello";
                        state = 1;
                        return true;
                    case 1:
                        current = "World";
                        state = 2;
                        return true;
                    case 2:
                        break;
                }

                return false;
            }

            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            string IEnumerator<string>.Current
            {
                get
                {
                    return current;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return current;
                }
            }

            void IDisposable.Dispose()
            {

            }
        }
    }

    public sealed class MusicTitles
    {
        String[] names= { "Tubular Bells", "Hergest Ridge", "Ommadawn", "Platinum" };

        public IEnumerator<String> GetEnumerator()
        {
            for(Int32 i = 0; i < 4; i++)
            {
                yield return names[i];
            }   
        }

        public IEnumerable<String> Reverse()
        {
            for(int i = 3; i >= 0; i--)
            {
                yield return names[i];
            }
        }

        public IEnumerable<String> Subset(Int32 index, Int32 length)
        {
            for (Int32 i = index; i < length + index; i++)
                yield return names[i];
        }

        public void Test2()
        {
            var titles = new MusicTitles();
            foreach (var title in titles)
                Console.WriteLine(title);
            Console.WriteLine();
            Console.WriteLine("Reverse");
            foreach (var title in titles.Reverse())
                Console.WriteLine(title);
            Console.WriteLine("Subset(0,2)");
            foreach(var title in titles.Subset(0,2))
                Console.WriteLine(title);
        }
    }

    public sealed class GameMoves
    {
        public void Test3()
        {
            var game = new GameMoves();
            IEnumerator enumerator = game.Cross();
            while (enumerator.MoveNext())
                enumerator = enumerator.Current as IEnumerator;
        }
        
        private IEnumerator cross;
        private IEnumerator circle;

        public GameMoves()
        {
            this.cross = Cross();
            this.circle = Circle();
        }

        private Int32 move = 0;
        const Int32 MaxMoves = 9;
        public IEnumerator Cross()
        {
            while(true)
            {
                Console.WriteLine("Cross,move {0}", move);
                if (++move > MaxMoves)
                    yield break;
                yield return circle;
            }
        }
        
        public IEnumerator Circle()
        {
            while (true)
            {
                Console.WriteLine("Circle,move {0}", move);
                if (++move >= MaxMoves)
                    yield break;
                yield return cross;
            }
        }
    }
}
