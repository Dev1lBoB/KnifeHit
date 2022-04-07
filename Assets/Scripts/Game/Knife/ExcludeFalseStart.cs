using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(KnifeThrow))]
public class ExcludeFalseStart : MonoBehaviour
{
    [SerializeField]
    private float duration;

    private KnifeThrow knifeThrow;
    private BoxCollider2D col;

    private void Start()
    {
        knifeThrow = GetComponent<KnifeThrow>();
        col = GetComponent<BoxCollider2D>();
    }

    public void GetReady()
    {
        StartCoroutine(EnableThrowing());
    }

    private IEnumerator EnableThrowing()
    {
        // Adds a delay before making a knife "Throwable" to prevent early throw when knife isn't at the correct position yet
        yield return new WaitForSeconds(duration);
        knifeThrow.enabled = true;
        col.enabled = true;
    }
}
