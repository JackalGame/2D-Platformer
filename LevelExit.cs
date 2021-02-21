using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    Animator myAnimator;

    private void Start()
    {
        myAnimator = FindObjectOfType<Player>().GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        FindObjectOfType<Player>().LevelComplete();
        myAnimator.SetTrigger("Exiting");
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
