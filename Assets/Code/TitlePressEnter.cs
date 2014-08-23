using UnityEngine;
using System.Collections;

public class titlePressEnter : MonoBehaviour
{
    bool fadeIn = false;
    bool fadeOut = false;
    float fadeSpeed = 0.01f;
    float minAlpha = 0.0f;
    float maxAlpha = 1.0f;
    Color color;

    void Awake()
    {
        color = renderer.material.color;
    }

    void Update()
    {
        renderer.material.color = color;

        if (fadeIn && !fadeOut)
            FadeIn();

        if (fadeOut && !fadeIn)
            FadeOut();

        if (color.a <= minAlpha)
        {

            fadeOut = false;
                fadeIn = true;
        }

        if (color.a >= maxAlpha)
        {
            fadeIn = false;
            fadeOut = true;    

        }
    }

    void FadeIn()
    {
        color.a += fadeSpeed;
    }

    void FadeOut()
    {
        color.a -= fadeSpeed;
    }
}