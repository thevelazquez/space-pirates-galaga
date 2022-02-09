using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public float movementSpeed;
    public float resetPoint;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -movementSpeed * Time.deltaTime, 0);
        if (transform.position.y < resetPoint) {
            transform.position = new Vector2(0,-5);
        }
    }
}
