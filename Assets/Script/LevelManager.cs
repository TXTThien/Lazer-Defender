using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneDelay=2f;
    Score score;

    private void Start() {
        score = FindObjectOfType<Score>();
    }
    public void LoadGame()
    {
        score.resetScore();
        SceneManager.LoadScene(1);
    }
    public void LoadMenu ()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad(2,sceneDelay));
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
    IEnumerator WaitAndLoad (int index, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(index);
    }
}
