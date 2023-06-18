using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 15f;

    public ScoreManager scoreManager;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        Destroy(gameObject,3f);   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.gameObject.GetComponent<EnemyHP>();

        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy.takehit(1);
            Destroy(gameObject);
            if (scoreManager != null)
            {
                scoreManager.BulletHitEnemy();
            }
        }

       
    }

}
