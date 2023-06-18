using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyScript : MonoBehaviour


{
    public float enemySpeed = 5f;
    public GameObject deathEffect;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject effectGO = Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject;
            Destroy(effectGO, 1f);
            Destroy(other.gameObject, 0.01f);
            
        }
    }

}
