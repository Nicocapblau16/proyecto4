using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public GameObject[] targetPrefabs;
    public Vector3 randomSpawnPos;

    private float minX = -3.75f;
    private float minY = -3.75f;
    private float spaceBetweenSquares = 2.5f;
    private int numberRows = 4;
    private float spawnRate = 2f;

    private void Start()
    {
        StartCoroutine("SpawnRandomTarget");
    }

    public Vector3 RandomSpawnPosition()
    {
        // genera pos aleatoria en uno de los centros de los 16 cuadrados
        int randomInt = Random.Range(0, numberRows);
        float randomPosX = minX + randomInt * spaceBetweenSquares;
        float randomPosY = minY + randomInt * spaceBetweenSquares;

        return new Vector3(randomPosX, randomPosY, 0);
    }

    private IEnumerator SpawnRandomTarget()
    {
        yield return new WaitForSeconds(spawnRate);

        int randomInedx = Random.Range(0, targetPrefabs.Length);
        randomSpawnPos = RandomSpawnPosition();

        Instantiate(targetPrefabs[randomInedx], randomSpawnPos, targetPrefabs[randomInedx].transform.rotation);
    }

}
