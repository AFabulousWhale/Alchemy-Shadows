using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIllTracker : MonoBehaviour
{
    public int stage1EnemyKills = 10;
    public int stage2EnemyKills = 25;
    public int stage3EnemyKills = 50;

    public int currentKills;

    public bool stageComplete;

    public static KIllTracker killTrackerREF;

    KIllTracker()
    {
        killTrackerREF = this;
    }

    private void Update()
    {
        if(currentKills == stage1EnemyKills)
        {
            Debug.Log("door opens");
            stageComplete = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentKills++;
        }
    }
}
