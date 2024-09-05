using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x -= speed * Time.deltaTime;

        if (position.x < -22.4f)
        {
            position.x += 44.8f;

        }
        transform.position = position;
    }
}
