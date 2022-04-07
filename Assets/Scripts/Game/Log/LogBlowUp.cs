using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LogBlowUp : MonoBehaviour
{
    [SerializeField]
    private GameObject logPiecesPrefab;

    private void LaunchKnife(Rigidbody2D knifeRb, Transform knife)
    {
        // Enables knife physics and launches it in the direction it is facing
        knifeRb.constraints = RigidbodyConstraints2D.None;
        knifeRb.bodyType = RigidbodyType2D.Dynamic;
        knifeRb.gravityScale = 1;
        knifeRb.AddForce(knife.up * Random.Range(10, 15), ForceMode2D.Impulse);
        knifeRb.AddTorque(Random.Range(-5000, 5000));
    }

    private void ReleaseKnives()
    {
        // Unparents all children knives and apples and makes them all scatter in diffrent directions
        foreach (Transform knife in GetComponentsInChildren<Transform>().Where(x => x.gameObject.tag == "Knife" || x.gameObject.tag == "Apple"))
        {
            Rigidbody2D knifeRb = knife.GetComponent<Rigidbody2D>();

            // Destroys knife collider to prevent random collisions
            BoxCollider2D knifeCollider = knife.GetComponent<BoxCollider2D>();
            Destroy(knifeCollider);

            LaunchKnife(knifeRb, knife);

            // Unparents knife and destroys it after delay
            knife.SetParent(null, true);
            Destroy(knife.gameObject, 1f);
        }
    }

    public void BlowUp()
    {
        // Spawns destroyed log pieces, releases all children objects and destroys log
        GameObject logPieces = Instantiate(logPiecesPrefab);
        logPieces.transform.position = this.transform.position;
        ReleaseKnives();
        Destroy(gameObject);
    }
}
