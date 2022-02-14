using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FormationController : MonoBehaviour
{
    public static int score = 0;
    public float horizontalSpeed;
    //public float maxSpeed;
    bool isChangingDirection;
    // Start is called before the first frame update
    Coroutine formationLoop;
    GameObject chosenChild;
    EnemyController enemyScript;
    [SerializeField] float actionTime;
    public TMP_Text scoreDisplay;
    int childCount;
    void Start()
    {
        isChangingDirection = false;
        childCount = transform.childCount;
        formationLoop = StartCoroutine(EnemyPicker());
        ChangeScore();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(horizontalSpeed * Time.deltaTime, 0, 0);
        isChangingDirection = false;
    }

    IEnumerator EnemyPicker() {
        while (childCount>0) {
            //Debug.Log(childCount);
            yield return new WaitForSeconds(actionTime);
            //pick random child
            int childIndex = Random.Range(0,childCount);
            if (childCount>0 && transform.childCount > childIndex) {
                
                chosenChild = transform.GetChild(childIndex).gameObject;
                enemyScript = chosenChild.GetComponent<EnemyController>();
                enemyScript.DoAction(Random.Range(0,2));

            }
        }
        SceneManager.LoadScene("Level2");

        Debug.Log("All enemies killed");
        //When all enemies are killed
    }

    public void ChangeDirection() {
        if (!isChangingDirection) {
            horizontalSpeed *= -1;
            //Debug.Log("Changing direction");
        }
        isChangingDirection = true;
    }
    public void AddScore(string enemyType, bool bonus) {
        int multiplier;
        if (bonus) {
            multiplier = 2;
        } else {
            multiplier = 1;
        }
        //Debug.Log(enemyType);
        switch (enemyType) {
            case "tier1":
                score+=100*multiplier;
                break;
            case "tier2":
                score+=150*multiplier;
                break;
            case "tier3":
                score+=500*multiplier;
                break;
        }
        childCount--;
        ChangeScore();
    }
    void ChangeScore() {
        scoreDisplay.text = "Score " + score.ToString();
    }
}
