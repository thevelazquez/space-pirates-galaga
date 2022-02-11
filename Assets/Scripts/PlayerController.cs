using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey("left")) {
            transform.Translate(-move(), 0, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey("right")) {
            transform.Translate(move(), 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(laser, transform.localPosition + new Vector3(0,1.7f,0), Quaternion.identity);
        }
    }

    float move() {
        return playerSpeed * Time.deltaTime;
    }
}
