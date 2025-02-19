using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameBgLooper : MonoBehaviour
{
    public int numBgCount = 5;
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;

    void Start()
    {
        
    }

    public void SettingObstacleInStart()
    {
        MinigameObstacle[] obstacles = GameObject.FindObjectsOfType<MinigameObstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered: " + collision.name);

        if (collision.CompareTag("Background")&&collision is BoxCollider2D)
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;
            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        MinigameObstacle obstacle = collision.GetComponent<MinigameObstacle>();
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }

        
    }
}
