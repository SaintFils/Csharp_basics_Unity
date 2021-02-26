using System;
using TrashBucked.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

namespace TrashBucked.Scripts
{
    public sealed partial class PlayerBall : Player
    {
        private GoodBonus[] _points;

        private void Awake()
        {
            _points = FindObjectsOfType<GoodBonus>();
        }

        private void Update()
        {
            Move(Input.GetAxis(AxisManager.HORIZONTAL), Input.GetAxis(AxisManager.VERTICAL));
            Jump();
            if (_points.Length == DisplayBonuses.WinPoints)
            {
                SceneManager.LoadScene(SceneNameManager.SCENE, LoadSceneMode.Single);
            }
        }
        
       public PlayerBall(float movementSpeed) : base(movementSpeed)
       {
       }
    }
}