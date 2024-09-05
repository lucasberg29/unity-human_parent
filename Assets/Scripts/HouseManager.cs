using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    private bool isGameOver = false;

    public Human[] humans;
    public Canvas gameOverCanvas;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTheyAreDead();
    }

    private void CheckIfTheyAreDead()
    {
        if (!isGameOver)
        {
            foreach (Human human in humans)
            {
                if (human.GetHealth() < 0.01f)
                {
                    GameOver();
                }
            }
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        //var gameOverPrefab = Resources.Load<GameObject>("Modals/GameOverCanvas");
        //var gameManagerObject = Instantiate<GameObject>(gameOverPrefab);
        StartCoroutine(gameOverCanvas.GetComponent<GameOverCanvas>().GameOverText("Game Over"));
    }
}
