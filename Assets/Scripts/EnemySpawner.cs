using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyList enemyList;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemyList.enemies.Count);

        EnemySO enemyToSpawn = enemyList.enemies[randomEnemy];

        GameObject enemyObject = Instantiate(enemyToSpawn.enemyPrefab);

        Enemy enemyScript = enemyObject.GetComponent<Enemy>();

        if(!enemyScript) //if the enemy doesn't have the script then add it
        {
            enemyScript = enemyObject.AddComponent<Enemy>();
        }

        enemyScript.maxHealth = enemyToSpawn.maxHealth;
    }
}
