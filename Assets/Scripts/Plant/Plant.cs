using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Plant : ScriptableObject
{
    [SerializeField] private string plantName;
    [SerializeField] private Sprite plantSprite;
}
