using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public int vendingMachinePrice;

    private float timer;
    private bool isDisplayed;
    public float moneyTextTimer;

    public GameObject moneyTextObject;

    private AudioSource moneyAudioSource;

    void Start()
    {
        moneyAudioSource = GetComponent<AudioSource>();
        timer = -1.0f;
        isDisplayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0 && isDisplayed)
        {
            timer = timer - 1.0f * Time.deltaTime;

            if (timer < 0)
            {
                isDisplayed = false;
                moneyTextObject.SetActive(false);
            }
        }
    }

    public void ShowMoneySpent()
    {
        moneyTextObject.SetActive(true);
        timer = moneyTextTimer;
        isDisplayed = true;
        moneyAudioSource.Play();
    }
}
