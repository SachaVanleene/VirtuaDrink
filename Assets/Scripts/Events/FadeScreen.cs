﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScreen : MonoBehaviour
{

    public Texture2D fadeTexture;

    [Range(0.1f, 1f)]
    public float fadespeed;
    public int drawDepth = -1000;

    private float alpha = 1f;
    private float fadeDir = -1f;

    public bool fadedin;
    public bool fadedout;

    public void FadeIn()
    {
        alpha = 1f;
        fadeDir = -1f;
        fadedin = true;
    }

    public void FadeOut()
    {
        alpha = 0f;
        fadeDir = 1f;
        fadedout = true;
    }

    void OnGUI()
    {
        alpha += fadeDir * fadespeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        Color newColor = GUI.color;
        newColor.a = alpha;

        GUI.color = newColor;

        GUI.depth = drawDepth;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);

        if(fadedout && alpha == 1)
        {
            fadedout = false;
            StartCoroutine(SwitchToScene(1));
        }
        if (fadedin && alpha == 0)
        {
            fadedin = false;
            StartCoroutine(SwitchToScene(0));
        }
    }

    IEnumerator SwitchSceneToBilan()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
    
    IEnumerator SwitchToScene(int i)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(i);
    }

}