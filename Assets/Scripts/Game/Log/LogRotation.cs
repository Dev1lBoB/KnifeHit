using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WheelJoint2D))]
public class LogRotation : MonoBehaviour
{
    public RotationElement[] rotationPattern;

    private WheelJoint2D wheelJoint;
    private JointMotor2D motor = new JointMotor2D();

    void Start()
    {
        wheelJoint = GetComponent<WheelJoint2D>();
    }

    public void SetMotorTorque(float amount)
    {
        motor.maxMotorTorque = amount;
    }

    public void LaunchMotor()
    {
        StartCoroutine(PlayRotationPattern());
    }

    private IEnumerator PlayRotationPattern()
    {
        // Iterates through rotation pattern of the log and makes wheel motor to work with given speed, direction and time
        int i = 0;

        while ( true )
        {
            yield return new WaitForFixedUpdate();

            motor.motorSpeed = rotationPattern[i].Speed;
            wheelJoint.motor = motor;

            yield return new WaitForSeconds(rotationPattern[i].Duration);

            if (i == rotationPattern.Length - 1)
            {
                // Move to the next element of pattern array
                i = 0;
            }
            else
            {
                // Starts to play rotation pattern from the beggining again
                ++i;
            }
        }
    }
}
