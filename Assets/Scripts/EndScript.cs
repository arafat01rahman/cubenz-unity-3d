using UnityEngine;

public class EndScript : MonoBehaviour
{
    public GameManager gameManager;
    void OnTriggerEnter()
    {
        Debug.Log("level cOmplete");
        gameManager.CompleteLevel();
    }
}
