using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalEase : MonoBehaviour
{
    [SerializeField] private float maxHeight = 4f;
    [SerializeField] private float speed = 1f;
    float current = 0f;

    void Update()
    {
        current += Time.deltaTime;
        float newY = Mathf.Sin(current * speed) * maxHeight;
        transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
    }
}
