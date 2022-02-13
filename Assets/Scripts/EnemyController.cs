using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    //GameObject formation = transform.parent;

    public GameObject deathAnimation;
    public GameObject enemyLaser;
    public float deathOriginX;
    public float deathOriginY; 

    FormationController parentScript;
    void Start()
    {
        parentScript = transform.parent.GetComponent<FormationController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) {
            Instantiate(enemyLaser, transform.position + new Vector3(deathOriginX,deathOriginY,0), Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D x) {
        if (x.name == "laser(Clone)") {
            
            Instantiate(deathAnimation, transform.position + new Vector3(deathOriginX, deathOriginY, 0), Quaternion.identity);
            Destroy(x.gameObject);
            Destroy(gameObject);
        }

        if (x.name == "Bumper" || x.name == "Bumper (1)") {
            parentScript.ChangeDirection();
        }
        //Debug.Log("Hit by " + x.name);
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + new Vector3(deathOriginX, deathOriginY, 0), .05f);
    }
}
