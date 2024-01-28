using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class AngelicAnimations : MonoBehaviour
{
    public GameObject root;
    public GameObject ring;
    public GameObject mainEye;
    public EyeRotation ringRotation;
    public VerticalEase verticalEase;
    public EasedRotation wing1;
    public EasedRotation wing2;
    public EasedRotation ribbon1;
    public EasedRotation ribbon2;
    public GameObject blush;


    Animator mainEyeAnimator;

    void Start()
    {
        mainEyeAnimator = mainEye.GetComponent<Animator>();
        SetNeutralAnimation();
        TurnBlushOn(false);

        //Trial();
    }

    void Trial()
    {
        IEnumerator _Trial()
        {
            SetNeutralAnimation();
            TurnBlushOn(false);
            yield return new WaitForSeconds(2.0f);
            SetSadAnimation();
            TurnBlushOn(false);
            yield return new WaitForSeconds(2.0f);
            SetShockAnimation();
            TurnBlushOn(false);
            yield return new WaitForSeconds(2.0f);
            SetNeutralAnimation();
            TurnBlushOn(true);
            yield return new WaitForSeconds(2.0f);
            SetSadAnimation();
            TurnBlushOn(true);
            yield return new WaitForSeconds(2.0f);
            SetShockAnimation();
            TurnBlushOn(true);
            yield return new WaitForSeconds(2.0f);
            StartCoroutine(_Trial());
        }

        StartCoroutine(_Trial());
    }

    [YarnCommand("HideAngelette")]
    public void HideAngelette()
    {
        root.transform.localScale = Vector3.zero;
    }

    [YarnCommand("ShowAngelette")]
    public void ShowAngelette()
    {
        root.transform.localScale = Vector3.one;
    }

    [YarnCommand("SetNeutralAnimation")]
    public void SetNeutralAnimation()
    {
        var smallEyes = ring.GetComponentsInChildren<EyeAnimation>();
        foreach (EyeAnimation eye in smallEyes)
        {
            eye.SetEyeAnimation();
        }

        mainEyeAnimator.SetInteger("EyeAnimation", 1);

        ringRotation.enabled = true;
        verticalEase.enabled = true;
        wing1.enabled = true;
        wing2.enabled = true;
        ribbon1.enabled = true;
        ribbon2.enabled = true;

        Change();
    }

    [YarnCommand("SetShockAnimation")]
    public void SetShockAnimation()
    {
        var smallEyes = ring.GetComponentsInChildren<EyeAnimation>();
        foreach (EyeAnimation eye in smallEyes)
        {
            eye.SetShockAnimation();
        }
        mainEyeAnimator.SetInteger("EyeAnimation", 10);
        Change();

        ringRotation.enabled = false;
        verticalEase.enabled = false;
        wing1.enabled = false;
        wing2.enabled = false;
        ribbon1.enabled = false;
        ribbon2.enabled = false;


    }

    [YarnCommand("SetBlushOn")]
    public void TurnBlushOn(bool turnOn)
    {
        blush.SetActive(turnOn);
    }

    [YarnCommand("SetSadAnimation")]
    public void SetSadAnimation()
    {
        var smallEyes = ring.GetComponentsInChildren<EyeAnimation>();
        foreach (EyeAnimation eye in smallEyes)
        {
            eye.SetSadAnimation();
        }

        mainEyeAnimator.SetInteger("EyeAnimation", 11);
        Change();

        ringRotation.enabled = true;
        verticalEase.enabled = true;
        wing1.enabled = true;
        wing2.enabled = true;
        ribbon1.enabled = true;
        ribbon2.enabled = true;
    }

    void Change()
    {
        mainEyeAnimator.SetTrigger("Change");
        mainEyeAnimator.SetTrigger("Change");
    }
}
