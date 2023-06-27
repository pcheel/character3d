using UnityEngine;
using System;

[RequireComponent(typeof(BoxCollider))]
public class GroundedChecker : MonoBehaviour
{
    public Action<bool> OnChangeGroundedStateAction;

    private void OnTriggerEnter(Collider other)
    {
        OnChangeGroundedStateAction?.Invoke(true);
    }
    private void OnTriggerExit(Collider other)
    {
        OnChangeGroundedStateAction?.Invoke(false);
    }
}
