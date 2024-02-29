using MyProject2.Abstracts.Inputs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MyProject2.Inputs
{

    public class InputReader : MyInputs
    {
        PlayerInput _playerInput;
        public float Horizontal {  get; private set; }

        public bool IsJump => _playerInput.currentActionMap.actions[1].WasPressedThisFrame();
        public InputReader(PlayerInput playerInput)
        {
            _playerInput= playerInput;
            _playerInput.currentActionMap.actions[0].performed += OnHorizontalMove;
            
        }

        
        void OnHorizontalMove(InputAction.CallbackContext obj)
        {
            Horizontal = obj.ReadValue<float>();

        }
    }

}

