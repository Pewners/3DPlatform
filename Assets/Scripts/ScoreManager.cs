using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public GameObject finish;
    public GameObject finishText;

    // Start is called before the first frame update
    void Start()
    {
        finish.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (score > 0)
        {
            finish.SetActive(true);
            finishText.SetActive(true);
        }
    }
}