using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneDialogue : MonoBehaviour
{
    DialogueSystem dialogueREF;

    [SerializeField]
    Animator anim;

    void Start()
    {
        dialogueREF = DialogueSystem.dialogueREF;
    }


    void Update()
    {
        if(!dialogueREF.endOfText && Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogueREF.currentStageOfDialogue == 1 && anim.GetInteger("Dialogue") == 0)
            {
                dialogueREF.StopAllCoroutines();
                dialogueREF.audioSource.Stop();
                dialogueREF.fullCanvas.SetActive(false);
                anim.SetInteger("Dialogue", 1);
            }

            if (dialogueREF.currentStageOfDialogue == 1 && anim.GetInteger("Dialogue") == 4)
            {
                Debug.Log("aaaaaaaaaa");
                dialogueREF.StopAllCoroutines();
                dialogueREF.audioSource.Stop();
                dialogueREF.fullCanvas.SetActive(false);
                anim.SetInteger("Dialogue", 5);
            }
        }

        FirstCutsceneCheck();
        SecondCutSceneCheck();
        ThirdCutSceneCheck();
        FourthCutSceneCheck();
    }

    void FourthCutSceneCheck()
    {
        if (anim.GetInteger("progression") == 3) //if third cutscene
        {
            if (dialogueREF.endOfText && Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetInteger("Dialogue", 6);
                dialogueREF.fullCanvas.SetActive(false);
            }
        }
    }

    void ThirdCutSceneCheck()
    {
        if (anim.GetInteger("progression") == 2) //if third cutscene
        {
            if (dialogueREF.endOfText && Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetInteger("Dialogue", 4);
                dialogueREF.fullCanvas.SetActive(false);
            }
        }
    }

    void SecondCutSceneCheck()
    {
        if (anim.GetInteger("progression") == 1) //if second cutscene
        {
            if (dialogueREF.endOfText && Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetInteger("Dialogue", 3);
                dialogueREF.fullCanvas.SetActive(false);
            }
        }
    }

    void FirstCutsceneCheck()
    {
        if (anim.GetInteger("progression") == 0) //if first cutscene
        {
            if (dialogueREF.endOfText && Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetInteger("Dialogue", 2);
                dialogueREF.fullCanvas.SetActive(false);
            }
        }
    }
}
