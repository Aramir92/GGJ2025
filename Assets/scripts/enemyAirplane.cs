using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAirplane : MonoBehaviour
{
    public Transform target;

    private Rigidbody2D rb;
    public float speed;

    private Vector2 targetDirection;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetDirection = (target.position - transform.position).normalized;
    }

    void Update()
    {
        rb.velocity = targetDirection * speed * Time.deltaTime;

        //if (transform.position.y < 50)
        //{
        //    Destroy(gameObject);
        //}
    }
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

    }
}
