using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSystem", menuName = "ScriptableObjects/DialogueSystem", order = 1)]
public class DialogueSO : ScriptableObject
{
    public List<SpeechLines> text;
}
