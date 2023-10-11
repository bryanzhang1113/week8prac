using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    private int points = 0;
    [SerializeField] Coin coin;

    private void OnTriggerEnter(Collider collider)
    {
        Coin coin = collider.GetComponent<Coin>();
        if(coin != null)
        {
            points += coin.points;
        }
    }
}
