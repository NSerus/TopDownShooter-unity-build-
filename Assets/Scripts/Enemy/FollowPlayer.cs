using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public float startTimeBtwShots;
    private float timeBtwShots;

    private Transform target;
    public GameObject projectile;
    public GameObject Saida;
    
    public HealthHandler healthbar;
    public int Damage;
    HealthSystem healthSystem = new HealthSystem(100);

    
    void Start()
    {
        healthbar.Setup(healthSystem);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        timeBtwShots = startTimeBtwShots;

        
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }

        if(timeBtwShots <= 0)
        {
            Instantiate(projectile,transform.position,Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    public void Awake()
    {   
        healthbar.Setup(healthSystem);   
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FirePlayer"))
        {
            healthbar.Setup(healthSystem);
            Debug.Log("vida boss" + healthSystem.GetHealth());
            healthSystem.Damage(Damage);
            Destroy(other.gameObject);
            
            if (healthSystem.GetHealth() <= 0)
            {
                
                Destroy(gameObject);
                
            }
            if(GameObject.FindWithTag("Boss") && healthSystem.GetHealth() <= 0)
            {
                
                Instantiate(Saida, transform.position, Quaternion.identity);
            }
        }  
    }
}
