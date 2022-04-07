using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FlashEffect))]
public class FlashWhenHit : MonoBehaviour
{
    private FlashEffect flashEffect;

    private void Start()
    {
        flashEffect = GetComponent<FlashEffect>();

        // Flash everytime knife lands into the log
        HitEvent.KnifeLanded += Flash;
    }

    private void Flash()
    {
        flashEffect.Flash();
    }

    private void OnDestroy()
    {
        HitEvent.KnifeLanded -= Flash;
    }
}
