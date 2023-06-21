using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile_script : MonoBehaviour
{
    public float speed;
    public GameObject explosionEffect;    
    public float baseDamage = 20;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyShip enemy = collision.gameObject.GetComponentInParent<EnemyShip>();
        if (enemy != null) {
            enemy.TakeDamage(baseDamage);
            // print("collided with enemy 3");
        } else {
            // print("collided with something else 3");
        }
        GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(explosion, 0.5f);
        Destroy(gameObject);
    }    
}
