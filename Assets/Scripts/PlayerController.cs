using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(-move(), 0, 0);
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(move(), 0, 0);
        }
    }

    float move() {
        return playerSpeed * Time.deltaTime;
    }
}
