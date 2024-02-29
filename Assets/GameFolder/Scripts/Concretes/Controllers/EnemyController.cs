using MyProject2.Abstracts.Controllers;
using MyProject2.Enums;
using MyProject2.Managers;
using MyProject2.Movements;
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace MyProject2.Controllers
{
    public class EnemyController : MyCharacterController, IEntityController
    {
        [SerializeField] EnemyEnum _enemyEnum;
        [SerializeField] float _maxLifeTime = 7f;
        VerticalMovement _verticalMovement;
        float _currentLifeTime = 0f;

        public EnemyEnum EnemyType => _enemyEnum;


        private void Awake()
        {
            _verticalMovement = new VerticalMovement(this);
        }
        private void Update()
        {
            _currentLifeTime += Time.deltaTime;

            if (_currentLifeTime> _maxLifeTime)
            {
                _currentLifeTime = 0f;
                KillYourSelf();
            }
        }
        private void FixedUpdate()
        {
            _verticalMovement.FixedTick();
        }

        private void KillYourSelf()
        {
            EnemyManager.Instance.SetPool(this);
        }
        public void SetMoveSpeed(float moveSpeed = 10f)
        { 
            if (moveSpeed < _moveSpeed)
            {
                return;
            }

            _moveSpeed = moveSpeed;
        }
    }

}
