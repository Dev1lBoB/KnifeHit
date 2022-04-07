using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    [SerializeField]
    private Material    flashMaterial;
    [SerializeField]
    private float       duration;

    private Renderer rend;
    private Material originalMaterial;

    private Coroutine flashRoutine;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        originalMaterial = rend.material;
    }

    public void Flash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }

        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        // Changes object material to a complete white one for a given duration to achive some Flash effect
        rend.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        rend.material = originalMaterial;
        flashRoutine = null;
    }
}
