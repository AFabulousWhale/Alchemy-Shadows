using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public DialogueSO currentDialogue;
    public TextMeshProUGUI dialogue;
    public Image characterIcon;
    public TextMeshProUGUI characterName;

    public List<GameObject> buttons;

    [SerializeField]
    public GameObject characterStats;

    [SerializeField]
    int currentStageOfDialogue;

    int buttonChoice;

    private void Start()
    {
        dialogue.gameObject.SetActive(true);

        foreach (var button in buttons) 
        { 
            button.SetActive(false);
        }

        //display the first bit of dialogue
        currentStageOfDialogue = -1;
        ProgressDialogue();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (currentStageOfDialogue < currentDialogue.text.Count - 1) //if not reached the end of the dialogue
            {
                //Normal Speech
                int nextDialogue = currentStageOfDialogue + 1;
                if (!currentDialogue.text[nextDialogue].isBranch) //if not a branch then go to the next piece of dialogue
                {
                    ProgressDialogue();
                }
                else
                {
                    Choices();
                }
            }
        }
    }

    /// <summary>
    /// Shows the availabe choices
    /// </summary>
    void Choices()
    {
        currentStageOfDialogue++;

        dialogue.gameObject.SetActive(false);

        for (int i = 0; i < currentDialogue.text[currentStageOfDialogue].branches.Count; i++)
        {
            buttons[i].SetActive(true);
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentDialogue.text[currentStageOfDialogue].branches[i].speech;
        }

        characterStats.SetActive(false);
    }

    void ProgressDialogue()
    {
        currentStageOfDialogue++;
        dialogue.text = currentDialogue.text[currentStageOfDialogue].speech;
        characterIcon.sprite = currentDialogue.text[currentStageOfDialogue].speaker.characterPicture;
        characterName.text = currentDialogue.text[currentStageOfDialogue].speaker.characterName;
    }

    /// <summary>
    /// called by each button to set the right dialogue branch
    /// </summary>
    /// <param name="buttonVal"></param>
    public void ChoiceValue(int buttonVal)
    {
        buttonChoice = buttonVal;

        ChangeDialogue();
    }

    void ChangeDialogue()
    {
        currentDialogue = currentDialogue.text[currentStageOfDialogue].branches[buttonChoice].direction;
        currentStageOfDialogue = -1;
        ProgressDialogue();

        dialogue.gameObject.SetActive(true);

        foreach (var button in buttons)
        {
            button.SetActive(false);
        }

        characterStats.SetActive(true);
    }
}
