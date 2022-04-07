using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBlowUp : MonoBehaviour
{
    [SerializeField]
    private GameObject applePiecesPrefab;

    public void BlowUp()
    {
        // Creates apple slices and then destroys the apple itself
        GameObject logPieces = Instantiate(applePiecesPrefab);
        logPieces.transform.position = this.transform.position;
        Destroy(gameObject);
    }
}
