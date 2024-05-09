using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int score, winScore = 100;
    public int lives, maxLifes = 5;

    public GameObject[] lifeImages;

    public void Update()
    {
        LoadLoseScene();
        LoadWinScene();
    }
    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("Points:" + score);
    }
    
    public void SubtractPoints(int points)
    {
        score -= points;
        Debug.Log("Points:" + score);
    }

    public void LoseLife()
    {
        lives--;
        UpdateLifeImages();
        Debug.Log("Lives:" + lives);
    }

    public void ResetScoreAndLives()
    {
        score = 0;
        lives = maxLifes;
        UpdateLifeImages();
    }

    private void UpdateLifeImages()
    {
        for (int i = 0; i < lifeImages.Length; i++)
        {
            if (i < lives)
            {
                lifeImages[i].SetActive(true); 
            }
            else
            {
                lifeImages[i].SetActive(false); 
            }
        }
    }

    private void LoadWinScene()
    {
        if (score >= winScore)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    private void LoadLoseScene()
    {
        if (lives <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
