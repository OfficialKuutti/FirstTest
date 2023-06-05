using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObject : MonoBehaviour
{
    public GameObject originalObject;
    public float respawnDelay = 5f;

   

     void Start()
    {
        
    }

     void OnDestroy()
    {
        Invoke("Respawn", respawnDelay);
    }

     void Respawn()
    {
        
        Instantiate(originalObject, transform.position, transform.rotation);
    }
}