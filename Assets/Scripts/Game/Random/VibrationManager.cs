using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    [SerializeField]
    private int hitVibrateDuration = 200;
    [SerializeField]
    private int missVibrateDuration = 600;
    [SerializeField]
    private int winVibrateDuration = 400;

    private bool isActive;

    private void Awake()
    {
        Vibration.Init();
    }

    public void Switch(bool state)
    {
        if (state == true)
        {
            HitEvent.KnifeLanded += VibrateAtHit;
            HitEvent.KnifeMissed += VibrateAtMiss;
            HitEvent.LevelPassed += VibrateAtWin;
        }
        else
        {
            HitEvent.KnifeLanded -= VibrateAtHit;
            HitEvent.KnifeMissed -= VibrateAtMiss;
            HitEvent.LevelPassed -= VibrateAtWin;
        }

        isActive = state;
    }

    private void VibrateAtHit()
    {
        Vibration.Vibrate(hitVibrateDuration);
    }
    
    private void VibrateAtMiss()
    {
        Vibration.Vibrate(missVibrateDuration);
    }
    
    private void VibrateAtWin()
    {
        Vibration.Vibrate(winVibrateDuration);
    }
    
    private void OnDestroy()
    {
        if (isActive == true)
        {
            HitEvent.KnifeLanded -= VibrateAtHit;
            HitEvent.KnifeMissed -= VibrateAtMiss;
            HitEvent.LevelPassed -= VibrateAtWin;
        }
    }
}
