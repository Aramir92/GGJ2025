using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private int maxBubbleSize = 5;

    private int bubbleSize = 1;

    [SerializeField]
    private PlayerAnimationManager playerAnimationManager;
    [SerializeField]
    private playermovement playermovement;
    [SerializeField]
    private GameObject spritesRoot;

    [Space]

    [SerializeField]
    private AudioSource dieAudioSource;
    [SerializeField]
    private AudioSource winAudioSource;
    [SerializeField]
    private AudioSource bubblePopAudioSource;

    [Space]

    [SerializeField]
    private GameObject diedText;
    [SerializeField]
    private GameObject winText;
    [SerializeField]
    private TextMeshProUGUI bubbleSizeText;

    [SerializeField]
    UnityEvent onDie;

    bool win = false;

    private void Start()
    {
        Respawn();
    }

    private void Update()
    {
        if (win)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    private void Respawn()
    {
        transform.position = PlayerSpawnPoint.GetSpawnPosition();

        SetBubbleSize(1);
    }

    public void Die()
    {
        //dieAudioSource.PlayOneShot(bubblePopAudioSource.clip);

        onDie?.Invoke();

        StartCoroutine(WaitAndRespawn());
    }

    public void Win()
    {
        winAudioSource.PlayOneShot(winAudioSource.clip);
        playermovement.enabled = false;

        winText.SetActive(true);

        win = true;
    }

    IEnumerator WaitAndRespawn()
    {
        playermovement.enabled = false;

        diedText.SetActive(true);

        spritesRoot.SetActive(false);

        yield return new WaitForSeconds(1);

        Respawn();
        
        diedText.SetActive(false);
        spritesRoot.SetActive(true);

        yield return new WaitForSeconds(1);

        playermovement.enabled = true;
    }

    public bool IncreseseBubbleSize()
    {
        bubblePopAudioSource.PlayOneShot(bubblePopAudioSource.clip);

        if (bubbleSize >= maxBubbleSize)
        {
            return false;
        }

        SetBubbleSize(bubbleSize + 1);

        return true;
    }

    public void DecreseseBubbleSize()
    {
        bubblePopAudioSource.PlayOneShot(bubblePopAudioSource.clip);

        SetBubbleSize(bubbleSize - 1);
    }

    private void SetBubbleSize(int size)
    {
        bubbleSize = size;

        bubbleSize = Mathf.Clamp(bubbleSize, 0, maxBubbleSize);

        bubbleSizeText.text = $"{bubbleSize.ToString()}/{maxBubbleSize}";

        if (bubbleSize <= 0)
        {
            Die();
            return;
        }
        
        playerAnimationManager.SetSizeIndex(bubbleSize - 1);
    }
}
