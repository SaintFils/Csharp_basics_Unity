using UnityEngine;

namespace Geekbrains.Test
{
    internal sealed class Enemy : MonoBehaviour, IApplyDamage
    {
        public void ApplyDamage()
        {
            Debug.Log("ApplyDamage");
        }
    }
}
