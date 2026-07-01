using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    bool GameEnded = false;
    public float RestartDelay = 1f;
    public GameObject LevelCompleteUI; 
    public void CompleteLevel()
    {
        LevelCompleteUI.SetActive(true);

    }

    public void EndGame()
    {
        if (GameEnded == false)
        {
            GameEnded = true;
            Debug.Log("Game Overrrr!");
            // Invoke looks for a method name in this class
            Invoke(nameof(restart), RestartDelay);
        }
    }

    // Move the method here, outside of EndGame
    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}