using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public GameObject laser;
    public GameObject hitAnim;
    public TMP_Text livesCounter;
    public static int hp = 3;
    [SerializeField] float iframesInSec;
    GameObject child;
    Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        child = transform.GetChild(0).gameObject;
        livesCounter.text = hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey("left")) {
            transform.Translate(-move(), 0, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey("right")) {
            transform.Translate(move(), 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(laser, transform.localPosition + new Vector3(0,1.7f,0), Quaternion.identity);
        }
    }

    float move() {
        return playerSpeed * Time.deltaTime;
    }

    public void Hit() {
        Debug.Log("Hit!");
        Instantiate(hitAnim, transform.localPosition + new Vector3(0,0.8f,-1), Quaternion.identity);
        child.SetActive(false);
        hp--;
        livesCounter.text = hp.ToString();
        if (hp > 0) {
            StartCoroutine(HitSequence());
        } else {
            gameObject.SetActive(false);
            SceneManager.LoadScene("Lose Screen");
        }
    }

    IEnumerator HitSequence() {
        Color tmp = renderer.material.color;
        tmp.a = 0.5f;
        renderer.material.color = tmp;
        Debug.Log("Color: " + tmp);
        yield return new WaitForSeconds(iframesInSec);
        Debug.Log("Color: " + tmp);
        tmp.a = 1f;
        renderer.material.color = tmp;
        child.SetActive(true);
    }
}
