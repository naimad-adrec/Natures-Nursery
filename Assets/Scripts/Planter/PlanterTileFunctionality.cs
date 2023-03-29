using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanterTileFunctionality : MonoBehaviour
{
    // Sprite Variables
    private SpriteRenderer sp;
    [SerializeField] private Sprite dryTile;
    [SerializeField] private Sprite wateredTile;

    private void Update()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        sp.sprite = wateredTile;
    }
}
