using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    public float spawnInterval = 1f;
    public float spawnHeight = 8f;
    public float arenaSize = 9f;

    public float minSpawnInterval = 0.3f;
    public float difficultyIncreaseTime = 10f;
    public float fallSpeed = 1f;

    private float timer;
    private float difficultyTimer;

    private void Update()
    {
        timer += Time.deltaTime;
        difficultyTimer += Time.deltaTime;

        if (difficultyTimer >= difficultyIncreaseTime)
        {
            IncreaseDifficulty();
            difficultyTimer = 0f;
        }

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    private void SpawnObstacle()
    {
        float randomX = Random.Range(-arenaSize, arenaSize);
        float randomZ = Random.Range(-arenaSize, arenaSize);

        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, randomZ);

        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        Rigidbody rb = obstacle.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.down * fallSpeed;
        }
    }

    private void IncreaseDifficulty()
    {
        if (spawnInterval > minSpawnInterval)
        {
            spawnInterval -= 0.1f;
        }

        fallSpeed += 1f;

        Debug.Log("Difficulty increased. Fall speed: " + fallSpeed);
    }
}