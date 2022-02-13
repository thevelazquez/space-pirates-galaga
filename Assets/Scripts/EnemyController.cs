using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject deathAnimation;
    public float deathOriginX;
    public float deathOriginY; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D x) {
        if (x.name == "laser(Clone)") {
            
            Instantiate(deathAnimation, transform.localPosition + new Vector3(deathOriginX, deathOriginY, 0), Quaternion.identity);
            Destroy(x.gameObject);
            Destroy(gameObject);
        }
        Debug.Log("Hit by " + x.name);
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + new Vector3(deathOriginX, deathOriginY, 0), .05f);
    }
}
