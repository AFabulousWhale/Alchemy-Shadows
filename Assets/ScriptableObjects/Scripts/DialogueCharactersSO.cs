using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character", order = 1)]
public class DialogueCharactersSO : ScriptableObject
{
    public string characterName;
    public Sprite characterPicture;

    //another scriptable objects for their voice
}
