using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public DialogueSO currentDialogue;
    public DialogueCharactersSO currentCharacter;
    public TextMeshProUGUI dialogue;
    string dialogueDisplay;
    public Image characterIcon;
    public TextMeshProUGUI characterName;

    public AudioSource audioSource;

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
        if (currentStageOfDialogue < currentDialogue.text.Count - 1) //if not reached the end of the dialogue
        {
            if (Input.GetKeyDown(KeyCode.Space)) //skips to the next line of dialogue
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

            if(Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (!currentDialogue.text[currentStageOfDialogue].isBranch) //if not a branch then go to the next piece of dialogue
                {
                    EndOfLine();
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
        StopAllCoroutines();

        currentStageOfDialogue++;
        dialogueDisplay = currentDialogue.text[currentStageOfDialogue].speech;

        currentCharacter = currentDialogue.text[currentStageOfDialogue].speaker;

        characterIcon.sprite = currentCharacter.characterPicture;
        characterName.text = currentCharacter.characterName;
        dialogue.text = "";

        StartCoroutine(TypeWriter());
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

    IEnumerator TypeWriter()
    {
        float speed = currentDialogue.text[currentStageOfDialogue].speaker.talkSpeed;

        foreach (char c in dialogueDisplay)
        {
            PlayDialogueSound(dialogue.text.Length, c);
            dialogue.text += c;
            yield return new WaitForSeconds(speed + Time.deltaTime); 
        }
    }

    void EndOfLine()
    {
        StopAllCoroutines();

        dialogue.text = dialogueDisplay;
    }

    void PlayDialogueSound(int currentDisplayedChars, char currentDisplayedCharacter)
    {
        if(currentDisplayedChars % currentCharacter.talkingSFX.frequency == 0)
        {
            AudioClip soundClip;

            int hashCode = currentDisplayedCharacter.GetHashCode();
            int predictableIndex = hashCode % currentCharacter.talkingSFX.clips.Length;
            soundClip = currentCharacter.talkingSFX.clips[predictableIndex];

            int maxPitch = (int)(currentCharacter.talkingSFX.maxPitch * 100);
            int minPitch = (int)(currentCharacter.talkingSFX.minPitch * 100);
            int pitchRange = maxPitch - minPitch;

            int predictablePitchInt = (hashCode % pitchRange) + minPitch;
            float predictablePitch = predictablePitchInt / 100f;

            audioSource.pitch = predictablePitch;
            audioSource.PlayOneShot(soundClip);
        }
    }
}
