using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinToCollectMovingEffect : MonoBehaviour
{
    float yPos;

    Vector3 startPos;
    // Update is called once per frame

    private void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        transform.position = startPos + new Vector3( 0f, Mathf.Sin(Time.time)+1, 0f);
        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }
}
