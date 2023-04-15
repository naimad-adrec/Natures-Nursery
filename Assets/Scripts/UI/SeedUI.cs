using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SeedUI : MonoBehaviour
{
    [SerializeField] private Plant seed;

    // UI Variables
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI seedCountText;
    [SerializeField] private Image seedSprite;

    private void Awake()
    {
        nameText.text = seed.PlantName;
        seedCountText.text = "0";
        seedSprite.sprite = seed.PlantMatureStage;
    }
}
