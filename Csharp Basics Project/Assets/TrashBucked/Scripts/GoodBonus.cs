﻿using UnityEngine;

namespace TrashBucked.Scripts
{
    public sealed class GoodBonus : InteractiveObject, IFlay, IFlicker
    {
        private Material _material;
        private float _lengthFlay;
        private DisplayBonuses _displayBonuses;
        private int _healAmount = 1;
      
        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(1.0f, 5.0f);
            _displayBonuses = new DisplayBonuses();
        }
        
        protected override void Interaction()
        {
            //_displayBonuses.Display(5);
            Debug.Log($"Before {GetComponent<PlayerBall>().playerHealthPoint}");
            gameObject.GetComponent<PlayerBall>().TakeHeal(_healAmount);
            Debug.Log(GetComponent<PlayerBall>().playerHealthPoint);
        }

        public void Fly() 
        {
            var localPosition = transform.localPosition;
            localPosition = new Vector3(localPosition.x, 
                Mathf.PingPong(Time.time, _lengthFlay),
                localPosition.z);
            transform.localPosition = localPosition;
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 2.0f));
        }
    }
}