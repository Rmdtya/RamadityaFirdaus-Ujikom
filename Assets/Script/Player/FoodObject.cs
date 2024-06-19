using Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FoodObject : MonoBehaviour
{
    public float speed;
    public int hungerValue;
    public float lifeTime;

    private bool isMoving = false;
    [SerializeField] private Rigidbody rb;
    private Vector3 _moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        isMoving = true;
        StartCoroutine(CountdownLifeTime());
    }

    private void OnDisable()
    {
        isMoving = false;
    }

    private void Update()
    {
        if (isMoving)
        {
            _moveDirection = transform.forward * 1;

            _moveDirection.Normalize();
            _moveDirection.y = 0;
            _moveDirection = _moveDirection * speed;
            Vector3 movementVelocity = _moveDirection;

            rb.velocity = movementVelocity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyManager enemy = other.gameObject.GetComponent<EnemyManager>();

            enemy.DecreaseLifePoint(hungerValue);

            Debug.Log("Kena Enemy");
            gameObject.SetActive(false);
        }
    }

    IEnumerator CountdownLifeTime()
    {
        yield return new WaitForSeconds(lifeTime);

        gameObject.SetActive(false);
    }
}
