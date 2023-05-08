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
    public bool isGameStart = false;
    public GameObject endingCanvas;

    public GameObject readyButton;
    public GameObject readymenu;
    public TextMeshProUGUI countdownText;

    void Start()
    {
        timerText.text = "Remaining Time : " + timeLimit.ToString();
        endingCanvas.SetActive(false);
        readymenu.SetActive(true);
        readyButton.SetActive(true);
        countdownText.text = "";
        isGameStart = false;
        isGameEnd = false;
    }

    private void Update()
    {
        if (flagPosition.Count > i)
        {
            i++;
        }

        if (currentTime < timeLimit && !isGameEnd && isGameStart)
        {
            currentTime += Time.deltaTime;
            float remainingTime = timeLimit - currentTime;
            int roundedTime = Mathf.RoundToInt(remainingTime);

            timerText.text = "Remaining Time : "+roundedTime.ToString();
        }
        else if(!isGameEnd && isGameStart)
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

    public void ready()
    {
        StartCoroutine(WaitForGameToStart(3));
    }
   
    IEnumerator WaitForGameToStart(int countdown)
    {
        readyButton.SetActive(false);

        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1);
            countdown--;
        }

        countdownText.text = "";
        Time.timeScale = 1;
        readymenu.SetActive(false);
        isGameStart = true;
    }
    
}
