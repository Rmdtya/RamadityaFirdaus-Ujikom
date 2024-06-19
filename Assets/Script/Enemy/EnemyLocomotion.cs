using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Enemy
{
    public class EnemyLocomotion : MonoBehaviour
    {
        private EnemyStatus _enemyStatus;

        Vector3 _moveDirection;
        Rigidbody _enemyRb;

        public void Initialize(EnemyStatus enemyStatus)
        {
            _enemyStatus = enemyStatus;
            _enemyRb = GetComponent<Rigidbody>();
        }

        public void HandleMovement()
        {
            _moveDirection = transform.forward * 1;

            _moveDirection.Normalize();
            _moveDirection.y = 0;
            _moveDirection = _moveDirection * _enemyStatus.speed;
            Vector3 movementVelocity = _moveDirection;

            _enemyRb.velocity = movementVelocity;
        }
    }
}
