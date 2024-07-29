using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallDialogue : MonoBehaviour
{
    DialogueSystem dialogueREF;

    void Start()
    {
        dialogueREF = DialogueSystem.dialogueREF;
    }

    public void StartDialogue()
    {
        dialogueREF.StartDialogue();
    }

    public void WarlockReveal()
    {
        Debug.Log("Showing canvas");
        dialogueREF.fullCanvas.SetActive(true);
        dialogueREF.ProgressDialogue();
    }
}
