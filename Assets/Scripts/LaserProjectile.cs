using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    float delay = 1f;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndLife());
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
