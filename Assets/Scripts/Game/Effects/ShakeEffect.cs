using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeEffect : MonoBehaviour
{
    [SerializeField]
    private Vector3 range;
    [SerializeField]
    private float       duration;

    private Vector3 newPosition;
    private Vector3 oldPosition;

    private Coroutine shakeRoutine;

    private void Start()
    {
        oldPosition = transform.position;
        newPosition = oldPosition + range;
    }

    public void Shake()
    {
        if (shakeRoutine != null)
        {
            StopCoroutine(shakeRoutine);
        }

        shakeRoutine = StartCoroutine(Lerp(oldPosition, newPosition, duration / 2)); // Move towards extreme shake position
        shakeRoutine = StartCoroutine(Lerp(newPosition, oldPosition, duration / 2)); // Return to the original position
    }

    private IEnumerator Lerp(Vector3 startValue, Vector3 endValue, float lerpDuration)
    {
        // Lerps towards chosen position during given time
        float timeElapsed = 0;
        
        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endValue;
        shakeRoutine = null;
    }
}
