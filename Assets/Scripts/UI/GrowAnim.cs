using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowAnim : MonoBehaviour
{
    [SerializeField]
    float duration;

    [SerializeField]
    LeanTweenType easeType;

    [SerializeField]
    Vector3 finalScale;

    [SerializeField]
    Vector3 startScale;

    public void AppearAnim()
    {
        LeanTween.scale(gameObject, finalScale, duration).setEase(easeType);
    }

    public void DisAppearAnim()
    {
        LeanTween.scale(gameObject, startScale, duration).setEase(easeType);
    }
}
