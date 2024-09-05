using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Human : MonoBehaviour
{
    private bool isFedDialogDisplayed;
    private bool isImGoodDialogDisplayed;
    private float timer;

    private int numberOfTimesFed = 0;

    public float fedDialogTime;

    public float maximunHealth;
    public float health;
    public Slider healthBar;
    public TextMeshProUGUI hungerText;
    public GameObject fedDialog;
    public GameObject imGoodDialog;

    public GameObject[] hearts; 

    public GameObject victoryCanvas;

    public AudioSource meowSound;

    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        numberOfTimesFed = 0;
        timer = -1.0f;
        isFedDialogDisplayed = false;
        meowSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            UpdateHunger();

            if (timer > 0 && isFedDialogDisplayed)
            {
                timer = timer - 1.8f * Time.deltaTime;

                if (timer < 0)
                {
                    isFedDialogDisplayed = false;
                    fedDialog.SetActive(false);
                }
            }
            else if (timer > 0 && isImGoodDialogDisplayed)
            {
                timer = timer - 1.0f * Time.deltaTime;

                if (timer < 0)
                {
                    isImGoodDialogDisplayed = false;
                    imGoodDialog.SetActive(false);
                }
            }
        }
    }

    private void UpdateHunger()
    {
        health = health - 2.0f * Time.deltaTime;

        if (health > 0)
        {
            hungerText.text = $"Hunger: {(int)health} / {(int)maximunHealth}";
        }
        else
        {
            health = 0;
        }

        if (health >= 75)
        {
            hungerText.color = Color.green;
        }
        if (health < 75 && health >= 50)
        {
            hungerText.color = Color.yellow;
        }
        else if (health >= 0 && health < 50)
        {
            hungerText.color = Color.red;
        }
    }
    
    public float GetHealth()
    {
        return health;  
    }

    internal bool FeedHuman()
    {
        if (health + 25 > 100)
        {
            //health = 100;
            ShowImFullDialog();
            return false;
        }
        else
        {
            numberOfTimesFed += 1;
            health += 25;
            ShowFedDialog();

            if (numberOfTimesFed == 4) 
            {
                //var heartsParticles = GameObject.FindGameObjectsWithTag("Hearts");

                foreach (var heart in hearts) 
                {
                    heart.SetActive(true);
                    victoryCanvas.SetActive(true);
                }

                MusicManager.Instance.PlayVictoryFanfare();

                isGameOver = true;
            }
            return true;
        }
    }

    private void ShowFedDialog()
    {
        imGoodDialog.SetActive(false);
        fedDialog.SetActive(true);
        timer = fedDialogTime;
        isFedDialogDisplayed = true;
    }

    private void ShowImFullDialog()
    {
        fedDialog.SetActive(false);
        imGoodDialog.SetActive(true);
        timer = fedDialogTime;
        isImGoodDialogDisplayed = true;
    }

    public void Meow()
    {
        meowSound.Play();
    }
}
