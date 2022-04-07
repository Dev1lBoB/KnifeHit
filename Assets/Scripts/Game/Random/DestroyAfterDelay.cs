using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    public float delayTime;

    private void Start()
    {
        Destroy(gameObject, delayTime);
    }
}
