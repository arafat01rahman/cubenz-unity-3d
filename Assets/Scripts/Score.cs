using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform player;
    public TMP_Text score;
    public float scoreOffset = 1000f;  

    void Update()
    {
        // offset to make it start at 0
        float displayScore = player.position.z + scoreOffset;
        score.text = displayScore.ToString("0");
    }
}