using UnityEngine;

public class CamControll : MonoBehaviour
{

    public BallControll ball;

    private float offset;

    void Start()
    {
        offset = transform.position.y - ball.transform.position.y;
    }

    void Update()
    {
        Vector3 actualPos = transform.position;
        actualPos.y = ball.transform.position.y + offset;
        transform.position = actualPos;
    }
}
