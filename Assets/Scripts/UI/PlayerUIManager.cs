using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentItemText;
    [SerializeField] private Slider waterPercentage;

    private void Update()
    {
        currentItemText.text = PlayerStateManager.Instance.CurrentItem;
        waterPercentage.value = PlayerStateManager.Instance.WaterPercentage;
    }
}