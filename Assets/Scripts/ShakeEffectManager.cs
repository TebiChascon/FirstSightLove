using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ShakeEffectManager : MonoBehaviour
{
    [SerializeField] private StressReceiver receiver;
    [SerializeField] private float maximumStress = 0.6f;
    [SerializeField] private float range = 45;

    [YarnCommand("Shake")]
    public void ShakeCamera()
    {
        float distance = Vector3.Distance(transform.position, receiver.transform.position);
        float distance01 = Mathf.Clamp01(distance / range);
        float stress = (1 - Mathf.Pow(distance01, 2)) * maximumStress;
        receiver.InduceStress(stress);
    }
}
