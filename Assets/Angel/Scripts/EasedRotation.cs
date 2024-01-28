
using UnityEngine;

public class EasedRotation : MonoBehaviour
{
    [SerializeField] private float maxAngle = 30f;
    [SerializeField] private float speed = 1f;
    float current = 0f;

    void Update()
    {
        current += Time.deltaTime;
        float rotationZ = Mathf.Sin(current * speed) * maxAngle;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
