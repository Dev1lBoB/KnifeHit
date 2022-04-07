using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleEffect : MonoBehaviour
{
    [SerializeField]
    private float appearDuration;
    [SerializeField]
    private float disappearDuration;
    
    [SerializeField]
    private float appearDelay = 0;
    [SerializeField]
    private float disappearDelay = 0;

    private Vector3 finalScale;

    public void Appear()
    {
        finalScale = transform.localScale;
        transform.localScale = Vector3.zero;
        StartCoroutine(Bubble(transform.localScale, finalScale, appearDuration, appearDelay));
    }

    public void Disappear()
    {
        finalScale = Vector3.zero;
        StartCoroutine(Bubble(transform.localScale, finalScale, disappearDuration, disappearDelay));
    }

    IEnumerator Bubble(Vector3 startValue, Vector3 endValue, float effectDuration, float delay)
    {
        yield return new WaitForSeconds(delay);
        float timeElapsed = 0;
        
        while (timeElapsed < effectDuration)
        {
            transform.localScale = Vector3.Lerp(startValue, endValue, timeElapsed / effectDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        
        transform.localScale = endValue;
    }
}
