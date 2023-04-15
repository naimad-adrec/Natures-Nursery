using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SeedBagUIManager : MonoBehaviour
{
    [SerializeField] private Canvas seedBagUI;

    private void Awake()
    {
        seedBagUI.enabled = false;
    }

    public void OpenSeedBag()
    {
        StartCoroutine(WaitForSeedBagAnimation());
    }

    public void CloseSeedBag()
    {
        seedBagUI.enabled = false;
    }

    private IEnumerator WaitForSeedBagAnimation()
    {
        yield return new WaitForSeconds(1);
        seedBagUI.enabled = true;
    }
}
