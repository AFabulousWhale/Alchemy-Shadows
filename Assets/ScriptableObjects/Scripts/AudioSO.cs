using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Audio", menuName = "ScriptableObjects/Audio", order = 1)]
public class AudioSO : ScriptableObject
{
    public AudioClip[] clips;

    [Range(1, 5)]
    public int frequency = 2;

    [Range(-3, 3)]
    public float minPitch = 0.5f;

    [Range(-3,3)]
    public float maxPitch = 3f;
}
