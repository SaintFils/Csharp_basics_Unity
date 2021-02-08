namespace Geekbrains.Test
{
    internal sealed class ExampleInterface
    {
        interface IMag
        {
            void SetDamage();
        }

        interface IOrg
        {
            void SetDamage();
        }

        internal class Org : IOrg
        {
            public void SetDamage()
            {
                throw new System.NotImplementedException();
            }
        }

        internal class MagOrg : IMag, IOrg
        {
            void IMag.SetDamage()
            {
            }

            void IOrg.SetDamage()
            {
            }

            public void SetDamage()
            {
            }
        }

        private void Main()
        {
            var magOrg = new MagOrg();
            magOrg.SetDamage();
            
            ((IMag)magOrg).SetDamage();
            ((IOrg)magOrg).SetDamage();

            NameMethod(new Unit());

            void NameMethod(IUnit unit)
            {
                
            }
        }


        interface IUnit
        {
            float Hp { get; }
            void Move(int t);
            void Move();
        }

        private class Unit2 : IUnit
        {
            public float Hp { get; }
            public void Move(int t)
            {
                throw new System.NotImplementedException();
            }

            public void Move()
            {
                throw new System.NotImplementedException();
            }
        }

        private class Unit : IUnit
        {
            public float Hp { get; }
            public void Move(int t)
            {
                throw new System.NotImplementedException();
            }

            public void Move()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
