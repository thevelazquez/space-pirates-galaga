using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    float delay = 1f;
    bool isEnemyLaser;
    public float speed; 
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndLife());
        isEnemyLaser = false;
        if (transform.name == "Enemy laser(Clone)") {
            isEnemyLaser = true;
            player = GameObject.Find("Player");
            //bless jimbobulus2 for this code https://answers.unity.com/questions/1023987/lookat-only-on-z-axis.html
            Vector3 difference = player.transform.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,speed*Time.deltaTime,0);
        Debug.Log(transform.position);
    }

    IEnumerator EndLife() {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

}
