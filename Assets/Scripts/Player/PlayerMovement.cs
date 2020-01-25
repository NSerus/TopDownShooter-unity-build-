using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public int Damage;
    public int GetHealth;

    public Rigidbody2D rb;
    Vector2 movement;
    HealthSystem healthSystem = new HealthSystem(100);
    public HealthHandler healthbar;

    AudioSource Hurt;  
    private void Start()
    {
        Hurt = GetComponent<AudioSource>();
    }
    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");   
    }
    private void FixedUpdate()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        rb.angularVelocity = 0;

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);   
    }
    public void OnTriggerEnter2D(Collider2D other)
    {  
        if (other.CompareTag("FireEnemy")) {
            healthbar.Setup(healthSystem);
            healthSystem.Damage(Damage);
            if(healthSystem.GetHealth() == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                Hurt.Play();
            }
        }
    }
}
