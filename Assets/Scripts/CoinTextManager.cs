using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinTextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private PlayerResources playerResources;

    private void Update()
    {
        coinText.text = "Coin Count: " + playerResources.GetCoinCount();
    }
}
