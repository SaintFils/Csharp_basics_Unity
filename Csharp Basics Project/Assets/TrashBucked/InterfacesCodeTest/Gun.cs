using System;
using UnityEngine;

namespace Geekbrains.Test
{
    internal class Gun : MonoBehaviour
    {
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    if (hit.collider.TryGetComponent(out IApplyDamage enemy))
                    {
                        enemy.ApplyDamage();
                    }
                }
            }
        }
    }
}
