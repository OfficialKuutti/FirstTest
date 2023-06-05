using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawnerScript : MonoBehaviour

{ 
    public GameObject missile;
    public float spawnTimer = 1;

    // Start is called before the first frame update
    void Start()
    {
        
        // Using this to make object spawning repeatedly 
        Invoke("Spawn",3);

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        Instantiate(missile, transform.position, transform.rotation);
        spawnTimer = Random.Range(3, 10);
        Invoke("Spawn", spawnTimer);
    }



}

