using UnityEngine;

namespace TrashBucked.Scripts
{
    public sealed class GoodBonus : InteractiveObject, IFlay, IFlicker
    {
        [SerializeField] private int _healAmount = 1;
        private Material _material;
        private float _flySpeedControl = 0.25f;
        private float _lengthFlay;
        private DisplayBonuses _displayBonuses;
      
        private void Awake()
        {
            _material = GetComponent<Renderer>().sharedMaterial;
            _lengthFlay = Random.Range(0.3f, 0.8f);
            _displayBonuses = new DisplayBonuses();
        }
        
        protected override void Interaction(Collider other)
        {
            //_displayBonuses.Display(5);
            other.GetComponent<PlayerBall>().TakeHeal(_healAmount);
        }

        public void Fly() 
        {
            var localPosition = transform.localPosition;
            localPosition = new Vector3(localPosition.x, 
                Mathf.PingPong((Time.time * _flySpeedControl), _lengthFlay),
                localPosition.z);
            transform.localPosition = localPosition;
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }
    }
}