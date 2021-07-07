using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TrashBucked.Scripts
{
    public sealed class BadBonus : InteractiveObject, IFlay, IRotation

    {
        [SerializeField] private int _damageAmount = 1;
        private float _lengthFlay;
        private float _speedRotation;
        private float _flySpeedControl = 0.25f;

        private void Awake()
        {
            _lengthFlay = Random.Range(0.3f, 0.8f);
            _speedRotation = Random.Range(30.0f, 50.0f);
        }

        protected override void Interaction(Collider other)
        {
            other.GetComponent<PlayerBall>().TakeDamage(_damageAmount);
        }

        public void Fly()
        {
            var localPosition = transform.localPosition;
            localPosition = new Vector3(localPosition.x, 
                Mathf.PingPong((Time.time * _flySpeedControl), _lengthFlay),
                localPosition.z);
            transform.localPosition = localPosition;
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }
    }
}