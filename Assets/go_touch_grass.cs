using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class play : MonoBehaviour
{
    public Component boxcollider;
    public Animator Animator;
    public void OnTriggerEnter2D(Collider2D boxcollider)
    {
        //Animator.SetInteger("progression",+1); <- I dunno if I keep this in, or put it when you get tp-ed back :p
        SceneManager.LoadScene("Gloomy woods");
    }
}
