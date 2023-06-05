using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidSpawnerScript : MonoBehaviour
{
    public GameObject droid;
    public float spawnTimer = 1;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 3);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Instantiate(droid, transform.position, transform.rotation);
        spawnTimer = Random.Range(3, 10);
        Invoke("Spawn", spawnTimer);
    
    }




}
