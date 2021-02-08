using UnityEngine;

namespace Geekbrains.Test
{
    internal class EnemyBody : MonoBehaviour, IApplyDamage
    {
        public void ApplyDamage()
        {
            Debug.Log("ApplyDamage for EnemyBody");
        }
    }
}
