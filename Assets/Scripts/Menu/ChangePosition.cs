using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    [SerializeField]
    private float   duration;
    [SerializeField]
    private Vector3 finalPosition;

    public void StartMoving()
    {
        StartCoroutine(Lerp(transform.position, finalPosition, duration));
    }

    private IEnumerator Lerp(Vector3 startValue, Vector3 endValue, float lerpDuration)
    {
        float timeElapsed = 0;
        
        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endValue;
    }
}
