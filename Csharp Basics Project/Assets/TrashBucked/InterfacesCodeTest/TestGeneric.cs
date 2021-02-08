using System;
using System.Collections.Generic;
using static UnityEngine.Debug;

namespace Geekbrains.Test
{
    internal sealed class TestGeneric
    {
        private void Main()
        {
            Display(1);
            Display(1d);
            Display<decimal>(1m);
            Display(1f);
            Display("1f");
        }
        
        private void Display<T>(T t)
        {
            Log(t);

            var enemy = FactoryEnemy<Enemy<int>, int>(100);
            enemy.Move();
        }

        private T FactoryEnemy<T, T2>(T2 hp) where T : IInit<T2>, new()
        where T2 : struct
        {
            var e = new T();
            e.Init(hp);
            return e;
        }

        internal class Enemy<T> : IInit<T>
        {
            public void Move()
            {
                throw new System.NotImplementedException();
            }

            public void Init(T value)
            {
                /*using (Health health = new Health())
                {
                }*/
                
            }
        }

        interface IInit<T>
        {
            void Init(T value);
        }

        /*internal class Health : IDisposable
        {
            public void Dispose()
            {
                var player = new Player<int>();
                player.Hp = 1;
                List<int> t;
                ListInteractableObject o = new ListInteractableObject();
                foreach (InteractiveObject interactiveObject in o)
                {
                    
                }

                Log(o["One"]);
            }
        }*/

        internal class Player<T> : ICloneable, IComparer<Player<T>>
        {
            public T Hp;
            public object Clone()
            {
                return MemberwiseClone();
            }

            public int Compare(Player<T> x, Player<T> y)
            {
                throw new NotImplementedException();
            }
        }
    }
}
