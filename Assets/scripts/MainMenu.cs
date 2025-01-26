using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private IEnumerator Start()
    {
        while (true)
        {
            animator.SetFloat("Speed", 2);

            yield return new WaitForSeconds(Random.Range(2f, 4f));

            animator.SetFloat("Speed", -2);

            yield return new WaitForSeconds(Random.Range(2f, 4f));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }
}
