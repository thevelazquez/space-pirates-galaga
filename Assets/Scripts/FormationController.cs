using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour
{
    public float horizontalSpeed;
    //public float maxSpeed;
    bool isChangingDirection;
    // Start is called before the first frame update
    void Start()
    {
        isChangingDirection = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(horizontalSpeed * Time.deltaTime, 0, 0);
        isChangingDirection = false;
    }

    public void ChangeDirection() {
        if (!isChangingDirection) {
            horizontalSpeed *= -1;
            Debug.Log("Changing direction");
        }
        isChangingDirection = true;
    }
}
