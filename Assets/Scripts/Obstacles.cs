using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] public float scrollSpeed = 5.0f;
    public GameObject obstacles;


    private void Awake()
    {

    }


    private void Update()
    {
        transform.Translate( -(scrollSpeed * Time.deltaTime), 0f, 0f);
    }

    
}
