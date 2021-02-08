using UnityEngine;

namespace Geekbrains.Test
{
    internal sealed class NullObject
    {
        private void Main()
        {
            Example(new Test(), null);
        }

        private void Example(Test test, bool? isActive)
        {
            Debug.Log(test?.Name?.Na);

            var t = test ?? new Test();
            
            t.NameMethod();

            if (isActive.HasValue)
            {
                Debug.Log(isActive.Value);
            }
        }

        internal sealed partial class Test
        {
            public Name Name;
        }

        internal partial class Test
        {
            public void NameMethod()
            {
                
            }
        }

        internal class Name
        {
            public string Na;
        }
    }
}
