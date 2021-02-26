using UnityEngine;
using UnityEngine.SceneManagement;

namespace TrashBucked.Scripts
{
    public class Player : MonoBehaviour
    {
        public float movementSpeed;
        public float playerHealthPoint;
        protected Rigidbody PlayerRigidbody;
        private float _lastInput;

        private void Start()
        {
            PlayerRigidbody = GetComponent<Rigidbody>();
        }
        /*protected void Move()
        {
            var moveHorizontal = -Input.GetAxis(AxisManager.HORIZONTAL);
            var moveVertical = -Input.GetAxis(AxisManager.VERTICAL);
            
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            
            PlayerRigidbody.AddForce(movement * movementSpeed);
        }*/
        protected void Move(float xInput,float zInput )
        {
            PlayerRigidbody.velocity = new Vector3(-xInput * movementSpeed,
                PlayerRigidbody.velocity.y,
                -zInput * movementSpeed);
        }

        internal void TakeDamage(int damageAmount)
        {
            playerHealthPoint -= damageAmount;
            if (playerHealthPoint <= 0)
            {
                Invoke(nameof(RestartScene), 1.0f);
            }
        }

        private void RestartScene()
        {
                SceneManager.LoadScene("SampleScene");
        }

        internal void TakeHeal(int healAmount)
        {
            Debug.Log($"HP before heal {playerHealthPoint}");
            if (playerHealthPoint >= 15)
            {
                return;
            }
            playerHealthPoint += healAmount;
            Debug.Log($"HP after heal {playerHealthPoint}");
        }

        protected Player(float movementSpeed)
        {
            this.movementSpeed = movementSpeed;
        }
     
    }
}
