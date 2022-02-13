using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollider : MonoBehaviour
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
        //Debug.Log(x.name);
        if (x.name == "Enemy laser(Clone)") {
            transform.parent.GetComponent<PlayerController>().Hit();
            Destroy(x.gameObject);
        }
    }
}
