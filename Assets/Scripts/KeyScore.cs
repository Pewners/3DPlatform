using UnityEngine;
using UnityEngine.UI;
public class KeyScore : MonoBehaviour
{
    public Text scoreText;
    Text score;

    private void Start()
    {
        //score = GetComponent<ScoreManager>();
    }

    private void Update()
    {
        scoreText.text = "Keys: " + score;
    }
}
