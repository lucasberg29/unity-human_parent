using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BoxDestruction : MonoBehaviour
{
    public Sprite[] boxPieces;

    public BoxManager boxManager;

    public int moneyReward;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Cat")
        {
            collision.gameObject.GetComponent<Cat>().GainMoney(moneyReward);
            boxManager.ActivateRubble();
            this.gameObject.SetActive(false);   
        }
    }
}
