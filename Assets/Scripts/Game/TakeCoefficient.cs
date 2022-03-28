using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCoefficient : MonoBehaviour
{
   [SerializeField] private Timer timer;
   private ScoreCounter score;

   private void Start()
   {
      score = GetComponent<ScoreCounter>();
   }

   private void Update()
   {
    if((int)timer.CurrentTime / 2 > score.Score)
        score.Add(1);
   }
}
