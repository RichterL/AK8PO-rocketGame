using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject explosionEffect;
    public AudioClip explosionSound;
    public float minSpeed;
    public float maxSpeed;
    public float health;
    public int scoreValue;
    public GameObject scoreText;
    public bool isDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
         rb.velocity = transform.up * Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if (isDestroyed) {
            return;
        }
        Debug.Log("Damage taken " + damage);
        health -= damage;
        if (health < 0) {
            Debug.Log("Ship destroyed" + health);
            Destroy(gameObject);
            LogicManager.instance.addScore(scoreValue);
            SoundManager.instance.PlaySound(explosionSound);
            isDestroyed = true;
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(explosion, 1.5f);
            
            
            Vector3 textPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);
            GameObject floatingScore = Instantiate(scoreText, textPosition, Quaternion.identity, GameObject.FindFirstObjectByType<Canvas>().transform);
            floatingScore.GetComponent<TMPro.TextMeshProUGUI>().text = scoreValue.ToString();
            Destroy(floatingScore, 1.0f);

            // Vector3 originalCameraPosition = Camera.main.transform.position;
            // Camera.main.transform.position = new Vector3(originalCameraPosition.x -1, originalCameraPosition.y -1, originalCameraPosition.z);    
            
            
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.layer == LayerMask.NameToLayer("Projectiles")) {
    //         print("collided with projectile");
    //     } else if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
    //         print("collided with player");
    //     } else {
    //         print("collided with something else");
    //     }
    //     //Destroy(gameObject);
    // } 
}
