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
        if (transform.name == "Enemy laser(clone)") {
            isEnemyLaser = true;
            player = GameObject.Find("Player");
            /*var dir = player.transform - Camera.main.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(dir.y, dir.x) = Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,speed*Time.deltaTime,0);
    }

    IEnumerator EndLife() {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

}
