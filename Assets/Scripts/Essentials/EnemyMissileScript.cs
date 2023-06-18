using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissileScript : MonoBehaviour
{
    public float speed = 5;
    public GameObject deathEffect;
    private AudioSource playerDeath;

    // Start is called before the first frame update
    void Start()
    {
        playerDeath = GetComponent<AudioSource>();
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject effectGO = Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject;
            playerDeath.Play();
            Destroy(effectGO, 1f);
            Destroy(other.gameObject, 0.01f);
            
            
        }
    }


}

