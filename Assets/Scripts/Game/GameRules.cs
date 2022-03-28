using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameRules : MonoBehaviour
{
   [SerializeField] private ScoreCounter score;
   [SerializeField] private Timer timer;
   
   [SerializeField] private Text bid;
   [SerializeField] private Vector2 border;

   
   public UnityEvent loseBidEvent;
   public UnityEvent winBidEvent;
   
   private Coroutine coroutine;
   float percent = 0;


   private float GetBid()
   {
      float value = string.IsNullOrEmpty(bid.text) ? 0 : float.Parse(bid.text);

      if (value < 0) value = 0;

      return value;
   }


   public void WinBid()
   {
      print(percent);
      score.Add(score.Score * percent);
      winBidEvent?.Invoke();
   }
   public void LoseBid()
   {
      score.TakeAway(1);
      loseBidEvent?.Invoke();
   }

   private void GetResult()
   {
      int value = (int)(timer.CurrentTime * 100);

      if (value - value / 2 < GetBid() && value + value / 2 > GetBid())
      {
         percent = ( (value - Mathf.Abs(value - GetBid())) / value);
         WinBid();
      }
      else
      {
         LoseBid();
      }
   }

   public void StartGame()
   {
      if(coroutine != null)
         StopCoroutine(coroutine);
      coroutine = StartCoroutine(StartGameCor());
   }
   public void StopGame()
   {
      StopCoroutine(coroutine);
   }

   private IEnumerator StartGameCor()
   {
      yield return new WaitForSeconds(Random.Range(border.x, border.y));
      GetResult();
      yield break;
   }
}
