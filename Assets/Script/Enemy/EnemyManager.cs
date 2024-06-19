using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        private EnemyLocomotion _enemyLocomotion;
        [SerializeField] private EnemyStatus _enemyStatus;
        private EnemyAnimator _enemyAnimator;

        [SerializeField] private Slider lifeBar;

        private bool isLife = false;

        private void Awake()
        {
            _enemyLocomotion = GetComponent<EnemyLocomotion>();
            _enemyLocomotion.Initialize(_enemyStatus);

            _enemyAnimator = GetComponent<EnemyAnimator>();
        }

        private void OnEnable()
        {
            isLife = true;
            _enemyStatus.InitHealth();
            lifeBar.maxValue = _enemyStatus.maxHealth;
            lifeBar.value = _enemyStatus.currentHealt;
        }

        private void FixedUpdate()
        {
            if (isLife)
            {
                _enemyLocomotion.HandleMovement();
            }
        }

        public void DecreaseLifePoint(int damage)
        {
            _enemyStatus.currentHealt -= damage;
            lifeBar.value = _enemyStatus.currentHealt;

            if(_enemyStatus.currentHealt <= 0)
            {
                GameplayManager.instance.UpdateScore(_enemyStatus.score);
                SoundManager.instance.PlayEatSound();
                isLife = false;
                gameObject.SetActive(false);
            }
        }


    }
}
