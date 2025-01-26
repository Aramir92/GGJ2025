using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinningPointTriggerController : MonoBehaviour
{
    [SerializeField]
    private string detectTag = "Player";

    [SerializeField]
    private float disableColliderTimeAfterHit = 5;
    [SerializeField]
    UnityEvent onPlayerHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(detectTag))
        {
            PlayerStats playerStats = collision.GetComponentInParent<PlayerStats>();

            if (playerStats != null)
            {
                playerStats.Win();

                gameObject.SetActive(false);
            }
        }
    }
}
