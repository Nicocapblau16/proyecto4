using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficultyButton : MonoBehaviour
{

    private Button button;
    private GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = FindObjectOfType<GameManager>();

        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

   private void SetDifficulty()
    {
        //gameManagerScript.StartGame(difficulty);
    }
}
