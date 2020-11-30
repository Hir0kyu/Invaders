using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    bool GameHasEnded = false;
    public float restartDelay = 3f;
    public GameObject CompleteLevelUI;
    public GameObject GameOverUI;

    //Function
    public void CompleteLevel()
    {
        Debug.Log("LEVEL COMPLETE");
        CompleteLevelUI.SetActive(true);
    }
    public void EndGame()
    {
        if(GameHasEnded == false)
        {
            GameOverUI.SetActive(true);
            Debug.Log("GAME OVER!");
            GameHasEnded = true;
        }
        Invoke("Restart", restartDelay);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
