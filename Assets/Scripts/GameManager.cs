using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Voronoi voi;
    public CountColor countColor;
    public List<Vector2> flagPosition = new List<Vector2>();
    public List<int> flagcolor = new List<int>();

    private int i = 0;

    public float timeLimit = 60f;
    public TextMeshProUGUI timerText;

    private float currentTime;

    private bool isGameEnd = false;
    public GameObject endingCanvas; 


    void Start()
    {
        timerText.text = timeLimit.ToString();
        endingCanvas.SetActive(false);
    }

    private void Update()
    {
        if (flagPosition.Count > i)
        {
            i++;
        }

        if (currentTime < timeLimit && !isGameEnd)
        {
            currentTime += Time.deltaTime;
            float remainingTime = timeLimit - currentTime;
            int roundedTime = Mathf.RoundToInt(remainingTime);

            timerText.text = "Remaining Time : "+roundedTime.ToString();
        }
        else if(!isGameEnd)
        {
            timerText.text = "Time's up!";
            Time.timeScale = 0;
            voi.ending();

            StartCoroutine(WaitAndShowEndingCanvas(2f));

            isGameEnd = true;
            countColor.Counting();
        }

    }

    IEnumerator WaitAndShowEndingCanvas(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        endingCanvas.SetActive(true);
    }
}
