using System;
using TrashBucked.Scripts.Managers;
using UnityEngine;

namespace TrashBucked.Scripts
{
    public sealed partial class PlayerBall : Player
    {
        private void Update()
        {
            Move(Input.GetAxis(AxisManager.HORIZONTAL), Input.GetAxis(AxisManager.VERTICAL));
        }

        private void FixedUpdate()
        {
            Jump();
        }

       public PlayerBall(float movementSpeed) : base(movementSpeed)
       {
       }
    }
}