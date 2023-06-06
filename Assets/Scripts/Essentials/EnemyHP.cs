using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{

    public float Hitpoints;
    public float MaxHitpoints = 2f;
    public HealthBarBehavior HealthBar;

    
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
        }
    }
}
