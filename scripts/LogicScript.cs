using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
   public int playerScore;
   public Text scoreText;
   public GameObject gameOverScreen;
   public AudioSource point;
   public GameObject startPlay;

   [ContextMenu("increase score")]
   

   
   public void addScore(int scoreToAdd)
   {
      playerScore = playerScore + scoreToAdd;
      scoreText.text = playerScore.ToString();
      point.Play();
   }
   public void restartGame()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
   }
   public void gameOver()
   {
      gameOverScreen.SetActive(true);
   }
   
}
