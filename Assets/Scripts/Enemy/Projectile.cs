using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    void Start()
    {
            player = GameObject.FindGameObjectWithTag("Player").transform;

            target = new Vector2(player.position.x+Random.Range(-1,1), player.position.y + Random.Range(-1,1));        
    }

    // Update is called once per frame
    void Update()
    {  
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                DestroyProjectile();
            }    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("walls"))
        {
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
