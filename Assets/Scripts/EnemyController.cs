using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D x) {
        if (x.name == "laser(Clone)") {
            Destroy (gameObject);
        }
        Debug.Log("Hit by " + x.name);
    }
}
