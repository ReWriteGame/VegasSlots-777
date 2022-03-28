using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameRules : MonoBehaviour
{
   [SerializeField] private ScoreCounter score;
   [SerializeField] private ScoreCounter cefficient;
   [SerializeField] private Text bid;
   [SerializeField] private Vector2 border;

   public UnityEvent loseBidEvent;
   public UnityEvent winBidEvent;
   
   private Coroutine coroutine;

   private float GetBid()
   {
      float value = string.IsNullOrEmpty(bid.text) ? 0 : float.Parse(bid.text);

      if (value < 0) value = 0;
      if (value > score.Score) value = score.Score;

      return value;
   }


   public void WinBid()
   {
      score.Add(GetBid() * cefficient.Score);
      winBidEvent?.Invoke();
   }
   public void LoseBid()
   {
      score.TakeAway(GetBid());
      loseBidEvent?.Invoke();
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
      LoseBid();
      yield break;
   }
}
