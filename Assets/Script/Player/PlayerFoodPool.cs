using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerFoodPool : MonoBehaviour
    {
        public static PlayerFoodPool instance;
        public List<GameObject> pooledObject;
        public GameObject objectToPoll;
        public int amount;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            pooledObject = new List<GameObject>();
            for (int i = 0; i < amount; i++)
            {
                GameObject temp = Instantiate(objectToPoll);
                temp.SetActive(false);
                pooledObject.Add(temp);
            }
        }

        public GameObject GetFoodObject()
        {
            for (int i = 0; i < amount; i++)
            {
                if (!pooledObject[i].activeInHierarchy)
                {
                    return pooledObject[i];
                }
            }

            return null;
        }
    }
}
