using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource sound;
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!sound.isPlaying) {
            Destroy(gameObject);
        }
    }
    void OnExplosionFinish() {
        //Destroy(gameObject);
    }
}
