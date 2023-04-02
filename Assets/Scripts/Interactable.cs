using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    private bool isInRange;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private UnityEvent isInteractedWith;
    [SerializeField] private UnityEvent waterTile;

    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                isInteractedWith.Invoke();
                
                if (PlayerStateManager.Instance.CurrentItem == "Watering Can")
                {
                    waterTile.Invoke();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isInRange = false;
            }
        }
    }
}
