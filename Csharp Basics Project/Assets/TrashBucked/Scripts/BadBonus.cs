using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TrashBucked.Scripts
{
    public sealed class BadBonus : InteractiveObject, IFlay, IRotation

    {
        private float _lengthFlay;
        private float _speedRotation;

        private void Awake()
        {
            _lengthFlay = Random.Range(1.0f, 5.0f);
            _speedRotation = Random.Range(10.0f, 50.0f);
        }

        protected override void Interaction()
        {
            // speed down or smth like that
        }

        public void Fly()
        {
            var localPosition = transform.localPosition;
            localPosition = new Vector3(
                localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }
    }
}