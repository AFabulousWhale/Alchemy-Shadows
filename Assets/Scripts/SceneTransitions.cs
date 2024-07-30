using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI exitDisplay;

    bool insideTrigger;

    private void Update()
    {
        if(insideTrigger && Input.GetKeyDown(KeyCode.E))
        {
            KIllTracker.killTrackerREF.progression++;
            KIllTracker.killTrackerREF.currentKills = 0;
            SceneManager.LoadScene(1);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            insideTrigger = true;
            exitDisplay.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            insideTrigger = false;
            exitDisplay.gameObject.SetActive(false);
        }
    }
}
