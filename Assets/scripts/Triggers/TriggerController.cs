using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerController : MonoBehaviour
{
    [SerializeField]
    private string detectTag = "Player";

    [SerializeField]
    UnityEvent onTriggerEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(detectTag))
        {
            onTriggerEnter?.Invoke();
        }
    }
}
