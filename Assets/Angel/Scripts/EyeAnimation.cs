using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeAnimation : MonoBehaviour
{
    [SerializeField] private int SelectedEye = 1;
    [SerializeField] private float SwapTime = 1.0f;
    Animator animationController;

    void Awake()
    {
        animationController = GetComponent<Animator>();
        // SetEyeAnimation();
    }

    public void SetEyeAnimation()
    {   
        if (Random.value > 0.5f)    
        {
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }
        SelectedEye = Random.Range(1, 6);
        animationController.SetInteger("Eye", SelectedEye);
        animationController.Play("Eye", -1, 0f);
        Change();
    }

    public void SetSadAnimation()
    {
        SelectedEye = 11;
        animationController.SetInteger("Eye", SelectedEye);
        animationController.Play("Eye", -1, 0f);
        Change();
    }

    public void SetShockAnimation()
    {
        SelectedEye = 10;
        animationController.SetInteger("Eye", SelectedEye);
        animationController.Play("Eye", -1, 0f);
        Change();
    }

    public void Change()
    {
        animationController.SetTrigger("Change");
        animationController.SetTrigger("Change");
    }
}
