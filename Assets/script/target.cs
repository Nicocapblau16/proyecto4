using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public ParticleSystem explosionParticle;


    private GameManager gameManagerScript;

    private bool clickOnGoodTarget;

    [SerializeField] private int points; // Puntos que da el target

    void Start()
    {

        gameManagerScript = FindObjectOfType<GameManager>();

        // Destruye el objeto tras 2 segundos
        Destroy(gameObject, gameManagerScript.timeDestroy);


    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Good"))
        {
            if (!gameManagerScript.gameOver)
            {
                clickOnGoodTarget = true;

                gameManagerScript.UpdateScore(points);
            }

            Destroy(gameObject);

            // Dar puntos, sistema de particulas, musiquita
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

        }
        else if (gameObject.CompareTag("Bad"))
        {
            Destroy(gameObject);
            gameManagerScript.missCounter += 1;

            IsGameOver();

            // Gameover, restar puntos, quitar vida, sistema de particulas, destruir calavera
        }

    }

    private void IsGameOver()
    {
        if (!gameManagerScript.gameOver)
        {
            gameManagerScript.missCounter += 1;
            gameManagerScript.UpdateLives();

            // Se da Game Over si le damos 3 veces a un objeto Bad
            if (gameManagerScript.missCounter >= gameManagerScript.totalMisses)
            {
                gameManagerScript.GameOver();
            }
        }

        // Musiquita de Game Over o mal hecho
    }

    private void OnDestroy()
    {
        gameManagerScript.targetPositions.Remove(transform.position);

        if (gameObject.CompareTag("Good") && !clickOnGoodTarget)
        {
            IsGameOver();
        }
    }
}
