using MyProject2.Abstracts.Movements;
using MyProject2.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyProject2.Movements
{
    public class JumpWithRigidBody  :IJump
    {
        
        Rigidbody _rigidbody;
        public bool CanJump => _rigidbody.velocity.y != 0f;
        public JumpWithRigidBody(PlayerController playerController)
        {
                _rigidbody = playerController.GetComponent<Rigidbody>();    

        }
        public void FixedTick(float jumpForce)
        {
            if (CanJump)
               return;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up * Time.deltaTime * jumpForce);

        }
     }  

    }

