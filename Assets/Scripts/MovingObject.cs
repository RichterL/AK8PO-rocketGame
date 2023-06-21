using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float movementSpeed;
    public float minSpeed;
    public float maxSpeed;
    public bool scalable;
    
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = Random.Range(minSpeed, maxSpeed);
        if (scalable) {
            transform.localScale = new Vector3(Random.Range(0.5f,1f),Random.Range(0.5f,1f),1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-1f, (-1f) * Input.GetAxis("Vertical")) * Time.deltaTime * movementSpeed);
        
    }
}
