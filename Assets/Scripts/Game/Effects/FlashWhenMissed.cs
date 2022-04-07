using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashWhenMissed : MonoBehaviour
{
    private FlashEffect flashEffect;

    private void Start()
    {
        flashEffect = GetComponent<FlashEffect>();

        // Flashes every time knife hits another knife
        HitEvent.KnifeMissed += Flash;
    }

    private void Flash()
    {
        flashEffect.Flash();
    }

    private void OnDestroy()
    {
        HitEvent.KnifeMissed -= Flash;
    }
}
