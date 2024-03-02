using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    
    private Transform target;

    void Start()
    {
      GameObject player = GameObject.Find("Player");
      target = player.transform;
    }

    void FixedUpdate()
    {
        if (transform.position.y < target.position.y) 
        {
            Destroy(gameObject, 5f);
        }
    }
}
