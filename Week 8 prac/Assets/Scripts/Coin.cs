using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float point = 5;

    public float GetPoint()
    {
        return point;
    }
    
}
