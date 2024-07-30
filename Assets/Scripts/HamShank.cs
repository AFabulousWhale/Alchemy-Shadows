using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HamShank : Entity
{
    private void Update()
    {
        if(isDead)
        {
            KIllTracker.killTrackerREF.stageComplete = true;
            SceneManager.LoadScene(3); //go to abode
        }
    }
}
