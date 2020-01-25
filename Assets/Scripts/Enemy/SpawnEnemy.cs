using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject hazard;
    public GameObject spawnerBoundary;
    private int hazardCount = 10;
    private Transform Boundary;

    private Vector2 spawnValues;
    private float wait = 4f;
    
    void Update()
    {
        Boundary = spawnerBoundary.transform;
        spawnValues = new Vector2(Boundary.position.x, Boundary.position.y);  
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i <= Random.Range(0, hazardCount - 1); i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(spawnValues.x - 9, spawnValues.x + 11), Random.Range(spawnValues.y - 9, spawnValues.y + 9));
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
            }
            Destroy(gameObject);
        }
    }
}
