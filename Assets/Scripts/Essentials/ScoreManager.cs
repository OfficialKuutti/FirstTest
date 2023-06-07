using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



    public class ScoreManager : MonoBehaviour
    {
        public int score = 0;
        public GameObject enemyObject1;
        public GameObject enemyObject2;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        enemyObject1.GetComponent<EnemyHP>().MaxHitpoints = 2f;
    }


    public void IncreaseScore(int amount)
        {
            score += amount;
            if (score % 1000 == 0)
            {
                int increaseCount = score / 1000;
                EnemyHP enemyHPScript = enemyObject1.GetComponent<EnemyHP>();
                
            for (int i = 0; i < increaseCount; i++)
                {
                    enemyHPScript.IncreaseHP(1.15f);
                }
            }
            
        }
    public void BulletHitEnemy()
    {
        IncreaseScore(50);
        
    }

}

