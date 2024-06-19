using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        private PlayerInputManager _playerInputManager;
        private PlayerLocomotion _playerLocomotion;
        private Animator _animator;

        private void Awake()
        {
            _playerInputManager = GetComponent<PlayerInputManager>();
            _playerLocomotion = GetComponent<PlayerLocomotion>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _playerInputManager.HandleMovementInput();
        }

        private void FixedUpdate()
        {
            _playerLocomotion.HandleMovement();
        }
    }
}
