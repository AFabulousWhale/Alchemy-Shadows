using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallDialogue : MonoBehaviour
{
    DialogueSystem dialogueREF;

    [SerializeField]
    DialogueSO cutScene2Dialogue;

    [SerializeField]
    DialogueSO cutScene3Dialogue;

    [SerializeField]
    DialogueSO cutScene4Dialogue;

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
        dialogueREF.fullCanvas.SetActive(true);
        dialogueREF.ProgressDialogue();
    }

    public void Rune1On()
    {
        dialogueREF.currentDialogue = cutScene2Dialogue;
        dialogueREF.StartDialogue();
    }

    public void Rune2On()
    {
        dialogueREF.currentDialogue = cutScene3Dialogue;
        dialogueREF.StartDialogue();
    }

    public void Rune3On()
    {
        Debug.Log("Rune3ON");
        dialogueREF.currentDialogue = cutScene4Dialogue;
        dialogueREF.StartDialogue();
    }

    public void SandwichSequence()
    {
        dialogueREF.fullCanvas.SetActive(true);
        dialogueREF.ProgressDialogue();
    }
}
