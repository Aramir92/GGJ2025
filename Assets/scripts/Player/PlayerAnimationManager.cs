using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rigidbody2D;

    [Space]
    [SerializeField]
    private Sprite[] headSprites; 

    [Space]

    [SerializeField]
    private Transform head;
    [SerializeField]
    private SpriteRenderer headSpriteRenderer;

    [SerializeField]
    private Transform[] pieces;

    [SerializeField]
    private Transform positions;

    private Transform[,] pivots;

    private void Awake()
    {
        pivots = new Transform[positions.childCount, pieces.Length];

        for(int i = 0; i < positions.childCount; i++)
        {
            Transform pivot = positions.GetChild(i);
            for (int j = 0; j < pivot.childCount; j++)
            {
                pivots[i, j] = pivot.GetChild(j);
            }
        }
    }

    private void Update()
    {
        animator.SetFloat("Speed", rigidbody2D.velocity.x);
    }

    public void SetSizeIndex(int index)
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i].localPosition = pivots[index, i].localPosition;
        }

        float size = 0.2f * index;
        head.localScale = Vector3.one + Vector3.one * size;
        
        headSpriteRenderer.sprite = headSprites[index];
    }
}
