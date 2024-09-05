using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveParallax : MonoBehaviour
{
    public float speed;

    Vector2 startPosition = new Vector2();
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x -= speed * Time.deltaTime;

        if (position.x < -23.7f)
        {
            position.x = Random.Range(23.7f,29.0f);

        }
        transform.position = position;
    }

    public void RefreshPosition()
    {
        transform.position = startPosition;
    }
}
