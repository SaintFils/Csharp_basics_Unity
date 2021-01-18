using System;

namespace Trash.Scripts
{
    public sealed class PlayerBall : Player
    {
        public PlayerBall(float speed) : base(speed)
        {
            
        }

        private void FixedUpdate()
        {
            Move();
        }
    }
}