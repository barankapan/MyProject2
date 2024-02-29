using MyProject2.Abstracts.Controllers;
using MyProject2.Abstracts.Inputs;
using MyProject2.Abstracts.Movements;
using MyProject2.Inputs;
using MyProject2.Managers;
using MyProject2.Movements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

namespace MyProject2.Controllers
{
    public class PlayerController : MyCharacterController ,IEntityController

    {
   
        [SerializeField] float _jumpForce =  8000f;
   
        IMover _horizontalMover;
        IJump _jumpWithRigidBody;
        MyInputs _inputs;
        float _horizontal;
        bool _isJump;
        bool _isDead = false;
      
        private void Awake()
        {
            _horizontalMover = new HorizontalMover(entityController:this);
            _jumpWithRigidBody = new JumpWithRigidBody(playerController:this);
            _inputs = new InputReader(GetComponent<PlayerInput>());
        }
        
        private void Update()
        {    
            if (_isDead) return;
            _horizontal = _inputs.Horizontal;
            if (_inputs.IsJump )
            {
                _isJump= true;
            }

            
        }
        private void FixedUpdate()
        {
            _horizontalMover.FixedTick(_horizontal);
           if(_isJump )
            {
                _jumpWithRigidBody.FixedTick(_jumpForce);
                
            }
            
        }
         void OnCollisionEnter(Collision collision)
        {
            IEntityController entityController = collision.collider.GetComponent<IEntityController>();
            if(entityController != null) {
                _isDead = true;
                GameManager.Instance.StopGame();
               
            }
        }
    }

}

