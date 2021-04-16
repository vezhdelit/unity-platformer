using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] float levelSlowMo = 0.5f;     
    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void OnTriggerEnter2D(Collider2D exit)
    {
        StartCoroutine(LoadNextLevel());
    }
    IEnumerator LoadNextLevel()
    {
        Time.timeScale = levelSlowMo;
        yield return new WaitForSecondsRealtime(levelLoadDelay);

        Time.timeScale = 1f;
        
        //Destroys all the Collectables on current level
        Destroy(FindObjectOfType<ScenePersist>().gameObject);

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
