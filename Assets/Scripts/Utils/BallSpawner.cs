using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;

    Timer spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(ConfigurationUtils.MinSpawnTime, ConfigurationUtils.MaxSpawnTime);
        spawnTimer.Run();
        spawnTimer.AddTimerFinishedListener(SpawnTimerFinished);

        EventManager.AddBallDiedListener(SpawnBall);
        EventManager.AddBallLostListener(SpawnBall);

        SpawnBall();
    }

    void Update()
    {

    }

    void SpawnTimerFinished()
    {
        SpawnBall();
        spawnTimer.Duration = Random.Range(ConfigurationUtils.MinSpawnTime, ConfigurationUtils.MaxSpawnTime);
        spawnTimer.Run();
    }

    void SpawnBall()
    {
        Instantiate(ballPrefab);
    }
}
