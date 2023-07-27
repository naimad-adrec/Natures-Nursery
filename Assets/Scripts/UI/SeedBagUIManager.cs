using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBagUIManager : MonoBehaviour
{
    [SerializeField] private Canvas seedBagUI; 

    private void Awake()
    {
        seedBagUI.enabled = false;
    }

    private void Update()
    {
        CheckIfSeedBagInUse();
    }

    private void CheckIfSeedBagInUse()
    {
        if (PlayerStateManager.Instance.IsInteracting == true && PlayerStateManager.Instance.CurrentItem == "Seed Bag")
        {
            seedBagUI.enabled = true;
        }
        else
        {
            seedBagUI.enabled = false;
        }
    }
}
