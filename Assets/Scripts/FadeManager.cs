using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class FadeManager : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private AnimationCurve ease;

    private Color fadeInTarget;
    private Color fadeOutTarget;

    private Coroutine coroutine;

    void Awake()
    {
        fadeImage.color = Color.black;

        fadeInTarget = fadeImage.color;
        fadeInTarget.a = 0.0f;

        fadeOutTarget = fadeImage.color;
        fadeOutTarget.a = 1.0f;
    }

    [YarnCommand("FadeOut")]
    public void FadeOut(float duration)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = StartCoroutine(Fade(duration, fadeInTarget));
    }

    [YarnCommand("FadeIn")]
    public void FadeIn(float duration)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = StartCoroutine(Fade(duration, fadeOutTarget));
    }

    private IEnumerator Fade(float duration, Color target)
    {
        fadeImage.raycastTarget = true;

        float startAlpha = fadeImage.color.a;
        float timeCounter = 0;

        Color fadeImageColor = fadeImage.color;

        while (duration > timeCounter)
        {
            float normalizedTime = timeCounter / duration;
            float alpha = Mathf.Lerp(startAlpha, target.a, ease.Evaluate(normalizedTime));

            fadeImageColor.a =  alpha;
            fadeImage.color = fadeImageColor;

            yield return null;
            timeCounter += Time.deltaTime;
        }

        fadeImageColor.a =  target.a;
        fadeImage.color = fadeImageColor;

        fadeImage.raycastTarget = false;
    }
}
