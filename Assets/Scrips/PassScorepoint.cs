using UnityEngine;

public class PassScorepoint : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        GameManager.singleton.AddScore(2);
    }


}
