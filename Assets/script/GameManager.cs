using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public GameObject[] targetPrefabs;
    public Vector3 randomSpawnPos;
    public List<Vector3> targetPositions; // Lista que guarda las posiciones ocupadas en la rejilla
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public GameObject menuPanel;


    private float minX = -3.75f;
    private float minY = -3.75f;
    private float spaceBetweenSquares = 2.5f;
    private int numberRows = 4;
    private float spawnRate = 1f;
    private int score; // Puntuación del jugador
    public int missCounter; // Contador de las veces que le damos a un objeto Bad
    public int totalMisses = 3; // Número máximo de veces que podemos darle a un objeto Bad

    private void Start()
    {
       
    }

    public Vector3 RandomSpawnPosition()
    {
        // Genera una posición aleatoria en uno de los centros de los 16 cuadrados de la rejilla
        int randomIntX = Random.Range(0, numberRows);
        int randomIntY = Random.Range(0, numberRows);
        float randomPosX = minX + randomIntX * spaceBetweenSquares;
        float randomPosY = minY + randomIntY * spaceBetweenSquares;

        return new Vector3(randomPosX, randomPosY, 0);
    }

    private IEnumerator SpawnRandomTarget()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);

            int randomIndex = Random.Range(0, targetPrefabs.Length);
            randomSpawnPos = RandomSpawnPosition();

            while (targetPositions.Contains(randomSpawnPos))
            {
                randomSpawnPos = RandomSpawnPosition();
            }

            Instantiate(targetPrefabs[randomIndex],
                randomSpawnPos,
                targetPrefabs[randomIndex].transform.rotation);
            targetPositions.Add(randomSpawnPos);
        }

    }

    public void UpdateScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = $"Score: {score}";
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.gameObject.SetActive(true);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        
        score = 0;
        UpdateScore(0);
        missCounter = 0;
        gameOver = false;
        gameOverPanel.SetActive(false);
        menuPanel.SetActive(false);
        spawnRate = 1;
        spawnRate /= difficulty;
        StartCoroutine("SpawnRandomTarget");
    }

}
