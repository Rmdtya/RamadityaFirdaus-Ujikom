using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{
    public static EnemyPooling instance;
    public List<GameObject> cowPooledObject;
    public List<GameObject> deerPooledObject;
    public List<GameObject> dogPooledObject;
    public List<GameObject> horsePooledObject;
    public GameObject[] enemyObject;
    public int amount;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cowPooledObject = new List<GameObject>();
        deerPooledObject = new List<GameObject>();
        dogPooledObject = new List<GameObject>();
        horsePooledObject = new List<GameObject>();

        for (int j = 0; j < enemyObject.Length; j++)
        {
            for (int i = 0; i < amount; i++)
            {
                if (j == 0)
                {
                    GameObject temp = Instantiate(enemyObject[j]);
                    temp.SetActive(false);
                    cowPooledObject.Add(temp);
                }
                else if (j == 1)
                {
                    GameObject temp = Instantiate(enemyObject[j]);
                    temp.SetActive(false);
                    deerPooledObject.Add(temp);
                }
                else if (j == 2)
                {
                    GameObject temp = Instantiate(enemyObject[j]);
                    temp.SetActive(false);
                    dogPooledObject.Add(temp);
                }
                else if (j == 3)
                {
                    GameObject temp = Instantiate(enemyObject[j]);
                    temp.SetActive(false);
                    horsePooledObject.Add(temp);
                }
            }
        }

    }


    public GameObject GetCowObject()
    {
        for (int i = 0; i < amount; i++)
        {
            if (!cowPooledObject[i].activeInHierarchy)
            {
                return cowPooledObject[i];
            }
        }

        return null;
    }

    public GameObject GetDeerObject()
    {
        for (int i = 0; i < amount; i++)
        {
            if (!deerPooledObject[i].activeInHierarchy)
            {
                return deerPooledObject[i];
            }
        }

        return null;
    }

    public GameObject GetDogObject()
    {
        for (int i = 0; i < amount; i++)
        {
            if (!dogPooledObject[i].activeInHierarchy)
            {
                return dogPooledObject[i];
            }
        }

        return null;
    }

    public GameObject GetHorseObject()
    {
        for (int i = 0; i < amount; i++)
        {
            if (!horsePooledObject[i].activeInHierarchy)
            {
                return horsePooledObject[i];
            }
        }

        return null;
    }
}
