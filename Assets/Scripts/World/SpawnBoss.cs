using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBoss : MonoBehaviour
{
    public GameObject hazard;
    public GameObject spawnerBoundary;
    private Transform Boundary;
    private Vector2 spawnValues;

    public Text BossText;

    private bool Boss;
    private void Start()
    {
        Boss = false;
        Boundary = spawnerBoundary.transform;
        spawnValues = new Vector2(Boundary.position.x, Boundary.position.y);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Boss = true;
            Vector3 spawnPosition = new Vector3(spawnValues.x +5,spawnValues.y );
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);   

            Destroy(gameObject);
        }
    }
}
