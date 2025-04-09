using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text currentScoretext;
    public Text bestScoreText;


    void Update()
    {
        currentScoretext.text = "Score: " + GameManager.singleton.currentScore;
        bestScoreText.text = "Best: " + GameManager.singleton.bestScore;
    }
}
