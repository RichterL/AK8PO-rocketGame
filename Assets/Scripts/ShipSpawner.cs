using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public GameObject[] ships;
    public GameObject ship;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 5;
    public int scoreTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LogicManager.instance.score < scoreTrigger) {
            return;
        }
        if (timer < spawnRate) {
            timer += Time.deltaTime;
        } else {
            timer = 0;
            SpawnShip();
        }
    }

    private void SpawnShip()
    {
        
        float positionMin = transform.position.y - heightOffset;
        float positionMax = transform.position.y + heightOffset;
        if (ships.Length > 0) {
            GameObject enemy = Instantiate(ships[Random.Range(0, ships.Length)], new Vector3(transform.position.x, Random.Range(positionMin, positionMax), transform.position.z), transform.rotation);
        } else {
            GameObject enemy = Instantiate(ship, new Vector3(transform.position.x, Random.Range(positionMin, positionMax), transform.position.z), transform.rotation);
        }
        
    }
}
