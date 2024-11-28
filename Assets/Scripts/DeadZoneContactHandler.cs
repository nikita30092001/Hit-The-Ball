using System;
using UnityEngine;

public class DeadZoneContactHandler : MonoBehaviour
{
    public event Action OnDeadZoneContact;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnDeadZoneContact?.Invoke();
    }
}
