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

    // Seed Variables
    private struct seedInfo { public string name; private int number; }
    private List<Dictionary<string, seedInfo>> _seedInventory = new List<Dictionary<string, seedInfo>>();

    private Dictionary<string, seedInfo> globeMallow = new Dictionary<string, seedInfo>();

    private void Awake()
    {

    }
}
