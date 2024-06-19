using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "EnemyStatus", menuName = "Enemy/EnemyStaus")]
    public class EnemyStatus : ScriptableObject
    {
        public float speed;
        public float maxHealth;
        public float currentHealt;
        public int score;

        public void InitHealth()
        {
            currentHealt = maxHealth;
        }
    }
}
