using System.Collections;
using UnityEngine;
using Yarn.Unity;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AnimationCurve ease;

    private const float FadeInTarget = 1.0f;
    private const float FadeOutTarget = 0.0f;
    private Coroutine coroutine;

    [YarnCommand("PlayMusic")]
    public void PlayMusic(string songName)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/Music/" + songName);
        musicSource.clip = clip;

        musicSource.loop = true;
        musicSource.Play();
    }

    [YarnCommand("PauseMusic")]
    public void PauseMusic()
    {
        musicSource.Pause();
    }

    [YarnCommand("ResumeMusic")]
    public void ResumeMusic()
    {
        musicSource.UnPause();
    }

    [YarnCommand("StopMusic")]
    public void StopMusic()
    {
        musicSource.Stop();
    }

    [YarnCommand("SetVolume")]
    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
    }

    [YarnCommand("FadeInMusic")]
    public void FadeIn(float duration)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = StartCoroutine(Fade(duration, FadeInTarget));
    }

    [YarnCommand("FadeOutMusic")]
    public void FadeOut(float duration)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = StartCoroutine(Fade(duration, FadeOutTarget));
    }

    [YarnCommand("PlaySFX")]
    public void PlaySFX(string songName)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/SFX/" + songName);
        sfxSource.PlayOneShot(clip);
    }

    private IEnumerator Fade(float duration, float target)
    {
        float startVolume = musicSource.volume;
        float timeCounter = 0;

        while (duration > timeCounter)
        {
            float normalizedTime = timeCounter / duration;
            float volume = Mathf.Lerp(startVolume, target, ease.Evaluate(normalizedTime));

            musicSource.volume = volume;

            yield return null;
            timeCounter += Time.deltaTime;
        }

        musicSource.volume = target;
    }
}
