using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed = 100f;
    public Transform target;

    private void Start()
    {
        target = FindObjectOfType<Player>().GetComponent<Transform>();
    }
    
    void FixedUpdate()
    {
        if(target.position.y > gameObject.transform.position.y && target != null) 
        {
            Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            gameObject.transform.position = Vector3.Lerp(transform.position, newPos, speed);
        }
    }
}
