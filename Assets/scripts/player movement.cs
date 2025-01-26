using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        body.velocity = Vector3.zero;
    }

    private void Update()
    {
        Vector2 axis = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            axis.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            axis.x = 1;
        }

        //if (Input.GetKey(KeyCode.S))
        //{
        //    axis.y = -1;
        //}
        //else if (Input.GetKey(KeyCode.W))
        //{
        //    axis.y = 1;
        //}

        body.velocity = new Vector2(axis.x * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }
 }