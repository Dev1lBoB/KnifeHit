using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D knifeCollider;

    [SerializeField]
    private bool isActive = false;

    /*
    ** Uncomment this section if you want to register and save new spawn positions of objects at log.
    ** Also don't forget to drag correct ScriptableObject to the prefab.
    */

    // public SpawnManagerScriptableObject smso;
    //
    // private static int smsoIndex = 0;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        knifeCollider = GetComponent<BoxCollider2D>();
    }

    // private void SaveKnifePosition()
    // {
    //   // Saves position of the knife at the array in ScriptableObject and iterates to the next index
        
    //     smso.spawnPoints[smsoIndex] = transform.localPosition;
    //     smso.spawnRotations[smsoIndex] = transform.localRotation;
    //     ++smsoIndex;
    // }

    private void ResizeCollider(Vector2 newOffset, Vector2 newSize)
    {
        knifeCollider.offset = newOffset;
        knifeCollider.size = newSize;
    }

    private void CollisionWithLog(Collision2D logCollision)
    {
        // Stops knife and attaches him as a child to a log
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        this.transform.SetParent(logCollision.collider.transform);

        // Changes knife collider size to a more viable one
        ResizeCollider(new Vector2(knifeCollider.offset.x, -2.5f), new Vector2(knifeCollider.size.x, 1f));
        rb.constraints = RigidbodyConstraints2D.FreezeAll;


        HitEvent.CallKnifeLanded();

        //
        // SaveKnifePosition();
        //
    }

    private void CollisionWithKnife()
    {
        // Makes this knife to ricochet and then fall after colliding with another knife
        rb.gravityScale = 1;
        rb.velocity = new Vector2(rb.velocity.x, -20);
        rb.AddTorque(2000);
        knifeCollider.enabled = false;

        // Destroys this knife after little delay
        Destroy(gameObject, 1f);
        HitEvent.CallKnifeMissed();
    }

    private void CollisionWithApple(Collider2D appleCollider)
    {
        // Blows up the apple
        HitEvent.CallAppleHitted();
        appleCollider.gameObject.GetComponent<AppleBlowUp>().BlowUp();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Exclude double occurence
        if (isActive == true)
            return ;
        isActive = true;

        if (collision.collider.tag == "Log")
        {
            // Knife hitted log
            CollisionWithLog(collision);
        }
        else if (collision.collider.tag == "Knife")
        {
            // Knife hitted another knife
            CollisionWithKnife();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Apple")
        {
            // Knife goes through an apple
            CollisionWithApple(collider);
        }
    }
}
