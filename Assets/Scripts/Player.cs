using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform missilePointLeft;
    public Transform missilePointRight;
    public Transform turretPointLeft;
    public Transform turretPointRight;
    public GameObject missilePrefab;
    public GameObject turretProjectilePrefab;
    public Rigidbody2D myRigidBody;
    public AudioClip missileLaunchSound;
    public AudioClip[] turretShootingSounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LogicManager.isPaused) {
            return;
        }

        var direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        myRigidBody.velocity = direction * 10;
        Vector3 originalCameraPosition = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(originalCameraPosition.x + 0.005f * Input.GetAxis("Horizontal"), originalCameraPosition.y + 0.005f * Input.GetAxis("Vertical"), originalCameraPosition.z);
        
        if (Input.GetButtonDown("Fire1")) {            
            Instantiate(turretProjectilePrefab, turretPointLeft.position, transform.rotation);
            Instantiate(turretProjectilePrefab, turretPointRight.position, transform.rotation);
            
            AudioClip randomSound = turretShootingSounds[Random.Range(0, turretShootingSounds.Length)];
            SoundManager.instance.PlaySound(randomSound, .3f);
        }

        if (Input.GetButtonDown("Fire2")) {            
            Instantiate(missilePrefab, missilePointLeft.position, transform.rotation);
            Instantiate(missilePrefab, missilePointRight.position, transform.rotation);

            SoundManager.instance.PlaySound(missileLaunchSound, .3f);                  
        }
    }
}
