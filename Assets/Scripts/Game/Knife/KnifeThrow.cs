using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class KnifeThrow : MonoBehaviour
{
    [SerializeField]
    private Vector2 throwForce;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void LaunchKnife()
    {
        // Launches knife and disables this dcript to prevent multiple
        rb.AddForce(throwForce, ForceMode2D.Impulse);
        this.enabled = false;        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Shoots active knife whenever player taps at the screen
            LaunchKnife();
        }
    }
}
