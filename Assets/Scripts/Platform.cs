using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;
    
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
        if (playerRB.velocity.y <= 0 )
        {
            playerRB.velocity = Vector2.up*jumpForce;
        } 
    }
}
