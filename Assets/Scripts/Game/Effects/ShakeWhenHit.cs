using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShakeEffect))]
public class ShakeWhenHit : MonoBehaviour
{
    private ShakeEffect shakeEffect;

    private void Start()
    {
        shakeEffect = GetComponent<ShakeEffect>();

        // Shakes every time knife hits log
        HitEvent.KnifeLanded += Shake;
    }

    private void Shake()
    {
        shakeEffect.Shake();
    }

    private void OnDestroy()
    {
        HitEvent.KnifeLanded -= Shake;
    }
}
