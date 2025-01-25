using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private int maxBubbleSize = 5;

    private int bubbleSize = 1;

    [SerializeField]
    private PlayerAnimationManager playerAnimationManager;

    [SerializeField]
    UnityEvent onDie;

    private void Start()
    {
        Respawn();
    }

    private void Respawn()
    {
        transform.position = PlayerSpawnPoint.GetSpawnPosition();

        SetBubbleSize(1);
    }

    private void Die()
    {
        onDie?.Invoke();

        Respawn();
    }

    public void IncreseseBubbleSize()
    {
        SetBubbleSize(bubbleSize + 1);
    }

    public void DecreseseBubbleSize()
    {
        SetBubbleSize(bubbleSize - 1);
    }

    private void SetBubbleSize(int size)
    {
        bubbleSize = size;

        if (bubbleSize <= 0)
        {
            Die();
            return;
        }
        else if(bubbleSize > maxBubbleSize)
        {
            bubbleSize = maxBubbleSize;
        }

        playerAnimationManager.SetSizeIndex(bubbleSize - 1);
    }
}
