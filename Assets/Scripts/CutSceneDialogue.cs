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
        if(!dialogueREF.endOfText && dialogueREF.currentStageOfDialogue == 1 && Input.GetKeyDown(KeyCode.Space) && anim.GetInteger("Dialogue") == 0)
        {
            dialogueREF.StopAllCoroutines();
            dialogueREF.fullCanvas.SetActive(false);
            anim.SetInteger("Dialogue", 1);
        }


        FirstCutsceneCheck();
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
