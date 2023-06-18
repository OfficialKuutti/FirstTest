using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HomingEnemyScript : MonoBehaviour
{

    public Transform target;
    public float enemySpeed = 2f;
    public GameObject deathEffect;
    private AudioSource playerDeadSound;


    // Start is called before the first frame update
    void Start()
    {
        playerDeadSound = GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject effectGO = Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject;
            playerDeadSound.Play();
            Destroy(effectGO, 1f);
            Destroy(other.gameObject, 0.01f);
        }




    }
}
