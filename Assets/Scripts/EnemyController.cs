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
    [SerializeField] float speed;
    bool isKamikazeMode;
    FormationController parentScript;
    Vector3 tempPosition;
    GameObject parent;
    void Start()
    {
        parent = transform.parent.gameObject;
        parentScript = transform.parent.GetComponent<FormationController>();
        isKamikazeMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) {
            ShootPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D x) {
        if (x.name == "laser(Clone)") {
            Kill();
            Destroy(x.gameObject);
        }

        if (!isKamikazeMode) {
            if (x.name == "Bumper" || x.name == "Bumper (1)") {
                parentScript.ChangeDirection();
            }
        }
        //Debug.Log("Hit by " + x.name);
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + new Vector3(deathOriginX, deathOriginY, 0), .05f);
    }

    void ShootPlayer() {
        Instantiate(enemyLaser, transform.position + new Vector3(deathOriginX,deathOriginY,0), Quaternion.identity);
    }
    void Kamikaze() {
        isKamikazeMode = true;
        tempPosition = transform.localPosition;
        transform.parent = null;
        LookAtPlayer();
        StartCoroutine(GoForward());
    }

    public void DoAction(int i) {
        switch (i) {
            case 0:
                ShootPlayer();
                break;
            case 1:
                Kamikaze();
                //Debug.Log("Kamakaze");
                break;
        }
    }

    IEnumerator GoForward() {
        while (transform.position.y > -7) {
            transform.Translate(0,-speed * Time.deltaTime,0);
            yield return null;
        }
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        transform.parent = parent.transform;
        transform.localPosition = tempPosition;
        isKamikazeMode = false;
    }
    void LookAtPlayer() {
        GameObject player = GameObject.Find("Player");
        //bless jimbobulus2 for this code https://answers.unity.com/questions/1023987/lookat-only-on-z-axis.html
        Vector3 difference = player.transform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 90f);
    }

    public void Kill() {
        parentScript.AddScore(gameObject.tag, isKamikazeMode);
        Instantiate(deathAnimation, transform.position + new Vector3(deathOriginX, deathOriginY, 0), Quaternion.identity);
        Destroy(gameObject);
    }
}
