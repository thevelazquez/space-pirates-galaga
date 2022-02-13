using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip laserShot;
    AudioSource soundEmitter;
    // Start is called before the first frame update
    void Start()
    {
        soundEmitter = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void laserSound() {
        soundEmitter.PlayOneShot(laserShot);
    }
}
