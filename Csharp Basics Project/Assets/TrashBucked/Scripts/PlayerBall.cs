using System;
using UnityEngine;

namespace TrashBucked.Scripts
{
    public sealed partial class PlayerBall : Player
    {
       private void FixedUpdate()
        {
            Move();
            Jump();
        }

       public PlayerBall(float speed) : base(speed)
       {
       }
    }
}