using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearAtStart : MonoBehaviour
{
    [SerializeField]
    private ChangePosition changePosition;

    private void Start()
    {
        // Moves the object to the position that is set in the ChangePosition script
        changePosition.StartMoving();
    }
}
