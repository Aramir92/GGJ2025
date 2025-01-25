using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyTriggerController : MonoBehaviour
{
    [SerializeField]
    private string detectTag = "Player";

    [SerializeField]
    private float disableColliderTimeAfterHit = 5;
    [SerializeField]
    UnityEvent onPlayerHit;

    private bool canDetect = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!canDetect)
        {
            return;
        }

        if(collision.CompareTag(detectTag))
        {
            PlayerStats playerStats = collision.GetComponentInParent<PlayerStats>();

            if(playerStats != null)
            {
                playerStats.DecreseseBubbleSize();

                StartCoroutine(DisableInteraction());

                onPlayerHit?.Invoke();
            }
        }
    }

    private IEnumerator DisableInteraction()
    {
        canDetect = false;

        yield return new WaitForSeconds(disableColliderTimeAfterHit);

        canDetect = true;
    }

}
