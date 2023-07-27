using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour
{
    // Coin Variables
    [SerializeField] private int coinCount = 0;
    public int GetCoinCount() { return coinCount; }
}
