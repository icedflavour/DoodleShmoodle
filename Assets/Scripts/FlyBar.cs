using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBar : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private float speed = 5f;
    private Rigidbody2D rb2d;
    public float xLeft;
    public float xRight;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2d.velocity = direction * speed;
        if (transform.position.x <= xLeft)
        {
            direction = Vector2.right;
        } else if ( transform.position.x >= xRight) 
        {
            direction = Vector2.left;
        }
    }
}
