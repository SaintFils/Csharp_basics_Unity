using UnityEngine;
using UnityEngine.SceneManagement;

namespace TrashBucked.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float baseMovementSpeed;
        [SerializeField] private float playerHealthPoint; //сменить название, конвенция
        
        private float _currentMovementSpeed;
        protected Rigidbody PlayerRigidbody;
        private float _lastInput;

        private void Start()
        {
            PlayerRigidbody = GetComponent<Rigidbody>();
            _currentMovementSpeed = baseMovementSpeed;
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
            PlayerRigidbody.velocity = new Vector3(-xInput * _currentMovementSpeed,
                PlayerRigidbody.velocity.y,
                -zInput * _currentMovementSpeed);
        }

        internal void SetSlowSpeed(float value)
        {
            _currentMovementSpeed *= value;
            Invoke(nameof(SetNormalSpeed), 2.0f);
        }

        internal void SetNormalSpeed()
        {
            _currentMovementSpeed = baseMovementSpeed;
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

        protected Player(float baseMovementSpeed)
        {
            this.baseMovementSpeed = baseMovementSpeed;
        }
     
    }
}
