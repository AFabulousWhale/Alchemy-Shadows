using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KIllTracker : MonoBehaviour
{
    public enum Progression
    {
        stage0,
        stage1,
        stage2,
        stage3
    }

    public Progression progression;
    public int stage1EnemyKills = 10;
    public int stage2EnemyKills = 25;
    public int stage3EnemyKills = 50;

    public int currentKills;

    public int currntNeededKills;

    public bool stageComplete;

    CutSceneDialogue instance;

    public static KIllTracker killTrackerREF;

    KIllTracker()
    {
        killTrackerREF = this;
    }


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if(progression == Progression.stage1)
        {
            currntNeededKills = stage1EnemyKills;
            EnemySpawner.enemySpawnerREF.multiplier = 1;
        }
        if (progression == Progression.stage2)
        {
            currntNeededKills = stage2EnemyKills;
            EnemySpawner.enemySpawnerREF.multiplier = 2;
        }
        if (progression == Progression.stage3)
        {
            currntNeededKills = stage3EnemyKills;
            EnemySpawner.enemySpawnerREF.multiplier = 3;
        }

        if(stageComplete)
        {
            instance = CutSceneDialogue.insatance;
            if (progression == Progression.stage1)
            {
                instance.anim.SetInteger("Dialogue", 2);
                instance.anim.SetInteger("progression", 1);
            }
            if (progression == Progression.stage2)
            {
                instance.anim.SetBool("Rune 1 on", true);
                instance.anim.SetInteger("Dialogue", 3);
                instance.anim.SetInteger("progression", 2);
            }
            if (progression == Progression.stage3)
            {
                instance.anim.SetBool("Rune 1 on", true);
                instance.anim.SetBool("Rune 2 on", true);
                instance.anim.SetInteger("Dialogue", 4);
                instance.anim.SetInteger("progression", 3);
            }
            stageComplete = false;
        }
    }
}
