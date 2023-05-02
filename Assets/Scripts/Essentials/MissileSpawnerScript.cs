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
        //Instantiate(missile, transform.position, transform.rotation);
        //Instantiate is to spawn or create something from unity example frefabs


        // Use this to make object spawning repeating also line29 is inactive now
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

