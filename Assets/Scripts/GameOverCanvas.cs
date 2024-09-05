using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour
{
    public Image background;
    public TextMeshProUGUI gameOvertextMeshProUGUI;

    //Start is called before the first frame update

    //private void Awake()
    //{
    //    StartCoroutine(GameOverText("Game Over"));
    //}

    public IEnumerator GameOverText(string text)
    {
        Image image = background;
        TextMeshProUGUI gameOverText = gameOvertextMeshProUGUI;
        gameOverText.text = text;

        Color imageColor = image.color;
        Color textColor = gameOverText.color;

        for (float alpha = 0.0f; alpha <= 1.0f; alpha += 0.45f * Time.deltaTime)
        {
            imageColor.a = alpha * 2;
            textColor.a = alpha / 2;

            image.color = imageColor;
            gameOverText.color = textColor;

            yield return null;
        }
    }
}
