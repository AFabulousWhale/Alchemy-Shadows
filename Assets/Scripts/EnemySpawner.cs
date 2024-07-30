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

    public int multiplier;

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
        if (KIllTracker.killTrackerREF.currentKills == maxEnemyCount)
        {
            StartCoroutine(Transition());
        }


        if (currentEnemyCount < maxEnemyCount && !startedSpawning && !KIllTracker.killTrackerREF.stageComplete) //only spawn enemies if stage not done
        {
            startedSpawning = true;
            StartCoroutine(CheckEnemySpawns());
        }
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(2f);
        Transitions.instance.FadeIn();
        yield return new WaitForSeconds(Transitions.instance.duration);
        if (KIllTracker.killTrackerREF.progression == KIllTracker.Progression.stage3)
        {
            SceneManager.LoadScene(2); //hamshank
        }
        else
        {
            KIllTracker.killTrackerREF.stageComplete = true;
            SceneManager.LoadScene(3); //go to abode
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
                        Vector2 Pos = new Vector2(p.transform.position.x, p.transform.position.y + 1);
                        SpawnEnemy(Pos);
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

    public void SpawnEnemy(Vector2 location)
    {
        int randomEnemy = Random.Range(0, enemyList.enemies.Count);
        EnemySO enemyToSpawn = enemyList.enemies[randomEnemy];
        GameObject enemyObject = Instantiate(enemyToSpawn.enemyPrefab, location, Quaternion.identity);

        Enemy enemyScript = enemyObject.GetComponent<Enemy>();

        if (!enemyScript) //if the enemy doesn't have the script then add it
        {
            enemyScript = enemyObject.AddComponent<Enemy>();
        }

        enemyScript.maxHealth = enemyToSpawn.maxHealth;

        if (enemyList.enemies[randomEnemy].weapon.weaponType == WeaponType.ranged)
        {
            Ranged script = enemyScript.weapon.GetComponent<Ranged>();
            script.bulletSpeed = script.bulletSpeed * multiplier;
            script.shootTime = script.shootTime / multiplier;
        }
    }
}
