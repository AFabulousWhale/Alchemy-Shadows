using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public EnemyList enemyList;

    [SerializeField]
    List<GameObject> enemySpawns;

    public int currentEnemyCount;
    public int maxEnemyCount;

    public static EnemySpawner enemySpawnerREF;

    bool startedSpawning;

    EnemySpawner()
    {
        enemySpawnerREF = this;
    }

    void Start()
    {
        startedSpawning = true;
        StartCoroutine(CheckEnemySpawns());
    }

    private void Update()
    {
        maxEnemyCount = KIllTracker.killTrackerREF.currntNeededKills;
        if (KIllTracker.killTrackerREF.currentKills == KIllTracker.killTrackerREF.currntNeededKills)
        {
            KIllTracker.killTrackerREF.stageComplete = true;
            SceneManager.LoadScene(3);
        }


        if (currentEnemyCount < maxEnemyCount && !startedSpawning && !KIllTracker.killTrackerREF.stageComplete)
        {
            startedSpawning = true;
            StartCoroutine(CheckEnemySpawns());
        }
    }

    IEnumerator CheckEnemySpawns()
    {
        foreach (GameObject p in enemySpawns)
        {
            var colliders = Physics2D.OverlapCircleAll(p.transform.position, 10f);
            foreach (var collider in colliders)
            {
                if (collider.tag == "Player" || collider.tag == "Enemy")
                {
                    break;
                }
                else
                {
                    if (currentEnemyCount < maxEnemyCount)
                    {
                        SpawnEnemy(p.transform.position);
                        currentEnemyCount++;
                        break;
                    }
                }
            }
            yield return new WaitForSeconds(2f);
        }
        startedSpawning = false;
        //get a list of all possible enemy spawns
        //make sure player isn't too close in a radius
        //if not spawn enemy, otherwise check again

        //make sure only certain number of enemies spawn per progression

        //if an enemy dies add to enemy progression
        //once certain progression go back to abode
    }

    public void SpawnEnemy(Vector3 location)
    {
        int randomEnemy = Random.Range(0, enemyList.enemies.Count);
        EnemySO enemyToSpawn = enemyList.enemies[randomEnemy];
        GameObject enemyObject = Instantiate(enemyToSpawn.enemyPrefab, location, Quaternion.identity);


        //GameObject enemyWeapon = Instantiate(enemyToSpawn.weapon.weaponPrefab);
        //enemyWeapon.transform.parent = enemyObject.transform;
        //Weapon weaponScript = enemyWeapon.GetComponent<Weapon>();

        //if (enemyToSpawn.weapon.weaponType == WeaponType.ranged) //add ranged script if ranged weapon
        //{
        //    if (!weaponScript)
        //    {
        //        weaponScript = enemyWeapon.AddComponent<Ranged>();
        //    }

        //    Ranged rangedScript = weaponScript as Ranged;
        //    rangedScript.bulletPrefab = enemyToSpawn.weapon.bullet;
        //}
        //else if(enemyToSpawn.weapon.weaponType == WeaponType.melee)
        //{
        //    if (!weaponScript)
        //    {
        //        weaponScript = enemyWeapon.AddComponent<Melee>();
        //    }
        //}

        //weaponScript.damageMin = enemyToSpawn.weapon.damageMin;
        //weaponScript.damageMax = enemyToSpawn.weapon.damageMax;


        Enemy enemyScript = enemyObject.GetComponent<Enemy>();

        if(!enemyScript) //if the enemy doesn't have the script then add it
        {
            enemyScript = enemyObject.AddComponent<Enemy>();
        }

        enemyScript.maxHealth = enemyToSpawn.maxHealth;
    }
}
