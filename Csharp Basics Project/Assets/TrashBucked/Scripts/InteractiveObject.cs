using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TrashBucked.Scripts
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        public bool IsInteractable { get; } = true;
        protected abstract void Interaction();

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.GetComponent<PlayerBall>())
            {
                return;
            }
            Interaction();
            Destroy(gameObject);
        }

        private void Start()
        {
            ((IAction)this).Action();
            ((IInitialization)this).Action();
        }

        void IAction.Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Random.ColorHSV();
            }
        }

        void IInitialization.Action() => Debug.Log("I was initialized");
    }
}