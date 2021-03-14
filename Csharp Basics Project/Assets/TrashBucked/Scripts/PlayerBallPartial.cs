using System;
using TrashBucked.Scripts.Managers;
using UnityEngine;

namespace TrashBucked.Scripts
{
    public sealed partial class PlayerBall
    {
        private bool _isOnFloor = false;
        public float force;
       
        private void OnCollisionStay(Collision other)
        {
            if (other.collider.CompareTag(AxisManager.Floor)) _isOnFloor = true;
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.collider.CompareTag(AxisManager.Floor)) _isOnFloor = false;
        }
     
        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) & _isOnFloor)
            {
                PlayerRigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
            }
        }
    }
}