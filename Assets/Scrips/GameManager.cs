using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int bestScore;
    public int currentScore;
    public int currentLevel = 0;
    public static GameManager singleton;



    void Awake()
    {
        if(singleton == null){
            singleton = this;
        }else if(singleton!=this){
            Destroy(gameObject);
        }
        bestScore = PlayerPrefs.GetInt("HighScore");
    }

    public void NextLevel(){

        currentLevel ++;
        FindAnyObjectByType<BallControll>().ResetBall();
        FindAnyObjectByType<HelixControll>().LoadStage(currentLevel);

        Debug.Log("pasas");

    }

    public void Restartlevel(){


        Debug.Log("RESET");
        singleton.currentScore = 0;
        FindAnyObjectByType<BallControll>().ResetBall();
        FindAnyObjectByType<HelixControll>().LoadStage(currentLevel);


    }


    public void AddScore(int scoreToAdd){

        currentScore += scoreToAdd;

        if(currentScore > bestScore){

            bestScore = currentScore;
            PlayerPrefs.SetInt("HighScore", currentScore);
        }

    }



}
