using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEvent : MonoBehaviour
{
    public delegate void HitResult();
    public static event HitResult KnifeLanded;
    public static event HitResult KnifeMissed;
    public static event HitResult AppleHitted;
    public static event HitResult LevelPassed;

    public static void CallKnifeLanded()
    {
        KnifeLanded();
    }
    
    public static void CallKnifeMissed()
    {
        KnifeMissed();
    }

    public static void CallAppleHitted()
    {
        AppleHitted();
    }

    public static void CallLevelPassed()
    {
        LevelPassed();
    }
}
