using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transitions : MonoBehaviour
{
    public float duration;

    [SerializeField]
    LeanTweenType easeType;

    [SerializeField]
    int finalAlpha = 0;

    [SerializeField]
    int startAlpha = 1;

    public static Transitions instance;

    Transitions()
    {
        instance = this;
    }

    private void Start()
    {
        FadeOut();
    }

    public void FadeIn()
    {
        Image r = gameObject.GetComponent<Image>();
        LeanTween.value(gameObject, finalAlpha, startAlpha, duration).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        });
    }

    public void FadeOut()
    {
        Image r = gameObject.GetComponent<Image>();
        LeanTween.value(gameObject, startAlpha, finalAlpha, duration).setOnUpdate((float val) =>
        {
            Color c = r.color;
            c.a = val;
            r.color = c;
        });
    }
}
