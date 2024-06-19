using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerStatus", menuName = "Player/PlayerStatus")]
    public class PlayerStatus : ScriptableObject
    {
        public float speed;
    }
}
