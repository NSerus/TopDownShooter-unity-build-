using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterDestroyer : MonoBehaviour
{
    public float waitTime = 4f;
    void OnTriggerEnter2D(Collider2D other)
    {       
        Destroy(other.gameObject);          
    }
    private void Start()
    {
        Destroy(gameObject, waitTime);
    }
}
