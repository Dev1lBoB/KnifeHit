using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeActiveState : MonoBehaviour
{
    public void ChangeState()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
