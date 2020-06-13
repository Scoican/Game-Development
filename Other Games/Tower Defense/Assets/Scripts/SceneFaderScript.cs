﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFaderScript : MonoBehaviour {

    public Image image;
    public AnimationCurve fade;

    void Start()
    {
        StartCoroutine(FadeIn());   
    }

    public void FadeTo(string sceneName)
    {
            StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeIn()
    {
        float time = 1f;
        while (time > 0f)
        {
            time -= Time.deltaTime;
            float alpha = fade.Evaluate(time);
            image.color = new Color(0f, 0f, 0f,alpha);
            yield return 0;
        } 
    }

    IEnumerator FadeOut(string sceneName)
    {
        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime;
            float alpha = fade.Evaluate(time);
            image.color = new Color(0f, 0f, 0f, alpha);
            yield return 0;
        }
        SceneManager.LoadScene(sceneName);
    }
}
