using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class ScoreManager : MonoBehaviour
    {
        public int score = 0;
        public GameObject enemyObject1;
        public GameObject enemyObject2;

    

    public void IncreaseScore(int amount)
        {
            score += amount;
            if (score % 1000 == 0)
            {
                int increaseCount = score / 1000;
                EnemyHP enemyHPScript = enemyObject1.GetComponent<EnemyHP>();
                
            for (int i = 0; i < increaseCount; i++)
                {
                    enemyHPScript.IncreaseHP(1.25f);
                }
            }
            
        }
    public void BulletHitEnemy()
    {
        IncreaseScore(50);
        
    }

}

