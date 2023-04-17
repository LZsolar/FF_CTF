using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Vector2> flagPosition = new List<Vector2>();
    public List<int> flagcolor = new List<int>();

    private int i = 0;
    private void Update()
    {
        if (flagPosition.Count > i)
        {
            i++;
         //   print("Now position:" + i +"AT"+flagPosition[i-1].x+"     "+flagPosition[i-1].y);
        }
    }
}
