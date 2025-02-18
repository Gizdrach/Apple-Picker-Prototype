using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float LeftAndRightEdge = 10f;
    public float chanceToCangeDirections = 0.1f;
    public float secondsBetweenAppleDrops = 1f;

    void Start()
    {
        Invoke("DropApple", 2f);   
    }

    void DropApple() 
    { 
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -LeftAndRightEdge) { speed = Mathf.Abs(speed); }

        else if ( pos.x > LeftAndRightEdge) { speed = -Mathf.Abs(speed); }  
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToCangeDirections) { speed *= -1; }  
    }
}
