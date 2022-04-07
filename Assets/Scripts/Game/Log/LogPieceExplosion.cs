using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogPieceExplosion : MonoBehaviour
{
    [SerializeField]
    private float BlowPower = 500;

    private Rigidbody rb;

    private void GainRandomRotation()
    {
        // Gains random 3D rotation
        Vector3 randomTorque = new Vector3(
            Random.Range(-5000, 5000),
            Random.Range(-5000, 5000),
            Random.Range(-5000, 5000)
        );
        rb.AddTorque(randomTorque);   
    }

    private void GainBlowForce()
    {
        // Gains force to move in opposite direction of Parent centre
        rb.AddForce(transform.localPosition.normalized * BlowPower);
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        GainRandomRotation();
        GainBlowForce();
    }
}
