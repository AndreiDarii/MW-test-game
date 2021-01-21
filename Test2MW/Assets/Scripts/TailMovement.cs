using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TailMovement : MonoBehaviour
{
    public Transform PlayerHead;
    public float CoinDiameter;

    private List<Transform> bodyCoins = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    private int score;

    public Text scoreText;

    private void Awake()
    {
        score = 0;
        positions.Add(PlayerHead.position);
    }
    private void Update()
    {
        float distance = ((Vector3)PlayerHead.position - positions[0]).magnitude;

        if(distance > CoinDiameter)
        {
            //The direction from old head position to the new one
            Vector3 direction = ((Vector3)PlayerHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CoinDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CoinDiameter;
        }


        for (int i = 0; i < bodyCoins.Count; i++)
        {
            bodyCoins[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CoinDiameter);
        }
    }

    public void AddCoinToBody()
    {
        Transform coin = Instantiate(PlayerHead, positions[positions.Count - 1], Quaternion.identity, transform);
        bodyCoins.Add(coin);
        positions.Add(coin.position);
        score++;
        scoreText.text = score.ToString();
    }
}
