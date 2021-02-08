using UnityEngine;
using UnityEngine.SceneManagement;

namespace TrashBucked.Scripts
{
    public class Player : MonoBehaviour
    {
        public float speed;
        public float playerHealthPoint;
        protected Rigidbody PlayerRigidbody;

        private void Start()
        {
            PlayerRigidbody = GetComponent<Rigidbody>();
        }
        protected void Move()
        {
            var moveHorizontal = -Input.GetAxis("Horizontal");
            var moveVertical = -Input.GetAxis("Vertical");
            
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            
            PlayerRigidbody.AddForce(movement * speed);
        }

        protected void TakeDamage(int damageAmount)
        {
            playerHealthPoint -= damageAmount;
            if (playerHealthPoint <= 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

        internal void TakeHeal(int healAmount)
        {
            Debug.Log(playerHealthPoint);
            if (playerHealthPoint >= 15)
            {
                return;
            }
            playerHealthPoint += healAmount;
            Debug.Log(playerHealthPoint + "after");
        }

        protected Player(float speed)
        {
            this.speed = speed;
        }
     
    }
}
