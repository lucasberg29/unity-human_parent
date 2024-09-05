using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoxManager : MonoBehaviour
{
    public GameObject[] boxPieces;
    public AudioSource brokenBox;

    public void ActivateRubble()
    {
        brokenBox.Play();   
        foreach (var boxPiece in boxPieces)
        {
            boxPiece.SetActive(true);
        }

        StartCoroutine(DegradeRubbleOverTime());
    }

    private void Update()
    {
        
    }

    public IEnumerator DegradeRubbleOverTime()
    {
        //foreach (var boxPiece in boxPieces)
        //{
        //    Image image = boxPiece.GetComponent<Image>();

        //    Color imageColor = image.color;

        //    for (float alpha = 0.0f; alpha <= 1.0f; alpha += 0.45f * Time.deltaTime)
        //    {
        //        imageColor.a = alpha * 2;
        //        image.color = imageColor;
                yield return null;
        //    }
        //}

        //foreach (var boxPiece in boxPieces)
        //{
        //    Destroy(boxPiece);
        //}
    }
}
