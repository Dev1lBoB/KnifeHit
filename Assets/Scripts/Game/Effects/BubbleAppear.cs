using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BubbleEffect))]
public class BubbleAppear : MonoBehaviour
{
    private BubbleEffect bubbleEffect;

    // Start is called before the first frame update
    void Start()
    {
        bubbleEffect = GetComponent<BubbleEffect>();
        bubbleEffect.Appear();
    }
}
