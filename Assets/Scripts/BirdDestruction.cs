using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BirdDestruction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Cat")
        {
            //boxManager.ActivateRubble();
            this.gameObject.SetActive(false);
        }
    }


}
