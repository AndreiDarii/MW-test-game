using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinToCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInParent<TailMovement>().AddCoinToBody();
            Destroy(gameObject);
        }
    }
}
