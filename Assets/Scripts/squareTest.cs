using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squareTest : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.right * 2 * Time.deltaTime ;
    }
}
