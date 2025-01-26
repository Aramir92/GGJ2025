using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioDelayed : MonoBehaviour
{
    [SerializeField]
    private float delayTime;
    [SerializeField]
    private AudioSource audioSource;

    void Start()
    {
        audioSource.PlayDelayed(delayTime);
    }
}
