using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterTime : MonoBehaviour
{
    private float lifeTime = 2f;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
