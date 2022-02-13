using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour
{
    public float horizontalSpeed;
    //public float maxSpeed;
    bool isChangingDirection;
    // Start is called before the first frame update
    Coroutine formationLoop;
    GameObject chosenChild;
    EnemyController enemyScript;
    void Start()
    {
        isChangingDirection = false;
        formationLoop = StartCoroutine(EnemyPicker());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(horizontalSpeed * Time.deltaTime, 0, 0);
        isChangingDirection = false;
    }

    IEnumerator EnemyPicker() {
        while (transform.childCount>0) {
            yield return new WaitForSeconds(2f);
            //pick random child
            chosenChild = transform.GetChild(Random.Range(0,transform.childCount-1)).gameObject;
            enemyScript = chosenChild.GetComponent<EnemyController>();
            enemyScript.ShootPlayer();
        }
        //When all enemies are killed
    }

    public void ChangeDirection() {
        if (!isChangingDirection) {
            horizontalSpeed *= -1;
            Debug.Log("Changing direction");
        }
        isChangingDirection = true;
    }
}
