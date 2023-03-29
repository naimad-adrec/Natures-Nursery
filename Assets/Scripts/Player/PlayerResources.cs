using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour
{
    public static PlayerResources Instance { get; private set; }

    public int coinCount = 0;

    private void Awake()
    {
        Instance = this;
    }
}
