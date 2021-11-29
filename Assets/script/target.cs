using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    private float timeDestroy = 2f;
    private GameManager gameManagerScript;

    void Start()
    {
        Destroy(gameObject, timeDestroy);

        gameManagerScript = FindObjectOfType<GameManager>();
    }


    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Good"))
        {
            Destroy(gameObject);
            

        }

        else if (gameObject.CompareTag("Bad"))
        {
            Destroy(gameObject);
            
        }
        
    }

    private void OnDestroy()
    {
        gameManagerScript.targetPosition.Remove(transform.position);
    }
}
