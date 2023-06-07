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

    public void IncreaseHP(float multiplier)
    {
        MaxHitpoints *= multiplier;
    }

    // Start is called before the first frame update
    void Start()
    {
        

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
            turretRespawner.TurretDestroyed(gameObject);
        }
    }

    public void Initialize(TurretRespawner respawner)
    {
        turretRespawner = respawner;
    }
}

