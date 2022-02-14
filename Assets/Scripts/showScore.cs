using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showScore : MonoBehaviour
{
    public TMP_Text scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = FormationController.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
