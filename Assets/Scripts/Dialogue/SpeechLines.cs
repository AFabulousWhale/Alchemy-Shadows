using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Speech", menuName = "ScriptableObjects/Speech", order = 1)]
[Serializable]
public class SpeechLines : ScriptableObject
{
    public DialogueCharactersSO speaker;
    public string speech;
    public bool isBranch;
    public List<BranchLines> branches;
}
