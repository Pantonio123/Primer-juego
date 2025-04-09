using UnityEngine;

public class GoalControll : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {GameManager.singleton.NextLevel();
        
    }
}
