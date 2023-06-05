using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretScript : MonoBehaviour
{
    public Transform target;
    public GameObject enemyGunBullet;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Shoot", 3f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }

    public void Shoot()
    {
        Instantiate(enemyGunBullet, transform.position, transform.rotation);

    }



}
