using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Parallax2D : MonoBehaviour
{
    enum SpriteMovementDirection
    {
        leftToRight,
        rightToLeft,
        topToBottom,
        bottomToTop
    }

    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private SpriteMovementDirection movementDirection = SpriteMovementDirection.leftToRight;

    [SerializeField]
    private float spriteSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        parallaxMovement(movementDirection, spriteSpeed);
    }

    private void parallaxMovement(SpriteMovementDirection direction, float speed)
    {
        //_spriteRenderer.
        Camera camera  = Camera.main;

        //camera.
    }
}
