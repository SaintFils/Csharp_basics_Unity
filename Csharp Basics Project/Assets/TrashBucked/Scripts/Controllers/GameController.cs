using System;
using UnityEngine;

namespace TrashBucked.Scripts
{
    public sealed class GameController : MonoBehaviour
    {
        private InteractiveObject[] _interactiveObjects;

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
        }

        private void Update()
        {
            for (int i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObjects = _interactiveObjects[i];
                if(interactiveObjects == null) continue;
                if (interactiveObjects is IFlay fly)
                {
                    fly.Fly();
                }

                if (interactiveObjects is IFlicker flicker)
                {
                    flicker.Flicker();
                }

                if (interactiveObjects is IRotation rotation)
                {
                    rotation.Rotation();
                }
            }
        }
    }
}