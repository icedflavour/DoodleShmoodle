using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBar : MonoBehaviour
{
    public int numSelectors = 3;
    public Rigidbody2D[] childBlocks;
    // Start is called before the first frame update
    void Start()
    {
        childBlocks = new Rigidbody2D[numSelectors];
        for (int i = 0; i < numSelectors; i++)
        {
            childBlocks[i] = transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>();
        }
    }

    public void DestroyFakeBar()
    {
        for (int i = 0; i < numSelectors; i++)
        {
            
            childBlocks[i].AddRelativeForce(Vector2.up * 10f, ForceMode2D.Impulse);
        }
    }

}
