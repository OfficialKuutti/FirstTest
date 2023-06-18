using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHP : MonoBehaviour
{

    public float Hitpoints;
    public float MaxHitpoints = 2f;
    public HealthBarBehavior HealthBar;
    public TurretRespawner turretRespawner;

    public GameObject deathEffect;
    private AudioSource enemyDeath;
    

    public void IncreaseHP(float multiplier)
    {
        MaxHitpoints *= multiplier;
    }

    // Start is called before the first frame update
    void Start()
    {

        enemyDeath = GetComponent<AudioSource>();
        Hitpoints = MaxHitpoints;        
    }

    void Update()
    {
        HealthBar.SetHealth(Hitpoints, MaxHitpoints);
    }
    public void takehit(float damage)
    
    {
        Hitpoints -= damage;
        if (Hitpoints <= 0)
        {

            Destroy(gameObject);
            GameObject effectGO = Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject;
            Destroy(effectGO, 1.5f);
            turretRespawner.TurretDestroyed(gameObject);


        }
        else if (Hitpoints <= 0)
        {
            enemyDeath.Play();
        }
    }

    public void Initialize(TurretRespawner respawner)
    {
        turretRespawner = respawner;
    }
}

