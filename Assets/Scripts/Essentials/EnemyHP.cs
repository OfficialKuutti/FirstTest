using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{

    public float Hitpoints;
    public float MaxHitpoints = 5;
    public HealthBarBehavior HealthBar;

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
