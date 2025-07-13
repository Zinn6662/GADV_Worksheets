using UnityEngine;

public class Wk6_RuntimeScripting_ObjectSpawner : MonoBehaviour
{
    public GameObject noFlyingCubeExistsSadFace; 
    public int numberOfAsteroids = 1; // Number of asteroids to spawn
    public Vector2 spawnRangeX = new Vector2(-5f, 5f); // X pos range
    public Vector2 spawnRangeY = new Vector2(-3f, 3f); // Y pos range

    void Start()
    {
        SpawnAsteroids();
    }

    void SpawnAsteroids()
    {
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            Vector3 randomPosition = new Vector3(
                    Random.Range(spawnRangeX.x, spawnRangeX.y),
                    Random.Range(spawnRangeY.x, spawnRangeY.y),
                    0f);

            GameObject asteroid = Instantiate (
noFlyingCubeExistsSadFace,
randomPosition,
Quaternion.identity);
        }
    }
}


