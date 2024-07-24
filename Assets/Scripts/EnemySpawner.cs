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


        GameObject enemyWeapon = Instantiate(enemyToSpawn.weapon.weaponPrefab);
        enemyWeapon.transform.parent = enemyObject.transform;
        Weapon weaponScript = enemyWeapon.GetComponent<Weapon>();

        if (enemyToSpawn.weapon.weaponType == WeaponType.ranged) //add ranged script if ranged weapon
        {
            if (!weaponScript)
            {
                weaponScript = enemyWeapon.AddComponent<Ranged>();
            }

            Ranged rangedScript = weaponScript as Ranged;
            rangedScript.bulletPrefab = enemyToSpawn.weapon.bullet;
        }
        else if(enemyToSpawn.weapon.weaponType == WeaponType.melee)
        {
            if (!weaponScript)
            {
                weaponScript = enemyWeapon.AddComponent<Melee>();
            }
        }

        weaponScript.damageMin = enemyToSpawn.weapon.damageMin;
        weaponScript.damageMax = enemyToSpawn.weapon.damageMax;


        Enemy enemyScript = enemyObject.GetComponent<Enemy>();

        if(!enemyScript) //if the enemy doesn't have the script then add it
        {
            enemyScript = enemyObject.AddComponent<Enemy>();
        }

        enemyScript.maxHealth = enemyToSpawn.maxHealth;
    }
}
