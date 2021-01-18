using UnityEngine;

namespace TrashBucked.Scripts
{
    public class Player : MonoBehaviour
    {
        public float speed;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        protected void Move()
        {
            var moveHorizontal = -Input.GetAxis("Horizontal");
            var moveVertical = -Input.GetAxis("Vertical");
            
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            
            _rigidbody.AddForce(movement * speed);
        }

        protected Player(float speed)
        {
            this.speed = speed;
        }
     
    }
}
