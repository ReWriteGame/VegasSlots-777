using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerVisual : MonoBehaviour
{
    [SerializeField] private Text output;
    [SerializeField] private Timer timer;
    [SerializeField] private int numberOfCharacters = 2;
    [SerializeField] private bool showPoint = true;
    
    void Update()
    {
        UpdateTime();
    }
    
    public void UpdateTime()
    {
        string number = $"{Math.Round(timer.CurrentTime, numberOfCharacters)}";
        if(!showPoint) number = number.Replace(",", "");
        output.text = number;
    }
}
