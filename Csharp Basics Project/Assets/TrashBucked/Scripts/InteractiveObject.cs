using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TrashBucked.Scripts
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        public bool IsInteractable { get; } = true;
        protected abstract void Interaction(Collider other);

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.GetComponent<PlayerBall>())
            {
                return;
            }
            Interaction(other);
            Destroy(gameObject);
        }

        private void Start()
        {
            ((IAction)this).Action();
            ((IInitialization)this).Action();
        }

        void IAction.Action()
        {
            if (GetComponent<GoodBonus>())
            {
                if (TryGetComponent(out Renderer renderer))
                {
                    renderer.sharedMaterial.color = Random.ColorHSV();
                }
            }
        }

        void IInitialization.Action()
        {

        } 
    }
}