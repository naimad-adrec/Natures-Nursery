using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Plant : ScriptableObject
{
    // Plant Data
    [SerializeField] private string _plantName;
    [SerializeField] private Sprite _plantStageOneSprite;
    [SerializeField] private Sprite _plantStageTwoSprite;
    [SerializeField] private Sprite _plantStageThreeSprite;
    [SerializeField] private Sprite _plantStageFourSprite;
    [SerializeField] private Sprite _plantStageFiveSprite;
    [SerializeField] private Sprite _plantMatureSprite;

    // Getters and Setters
    public string PlantName { get { return _plantName; } private set { } }
    public Sprite PlantStageOneSprite { get { return _plantStageOneSprite; } private set { } }
    public Sprite PlantStageTwoSprite { get { return _plantStageTwoSprite; } private set { } }
    public Sprite PlantStageThreeSprite { get { return _plantStageThreeSprite; } private set { } }
    public Sprite PlantStageFourSprite { get { return _plantStageFourSprite; } private set { } }
    public Sprite PlantStageFiveSprite { get { return _plantStageFiveSprite; } private set { } }
    public Sprite PlantMatureStage { get { return _plantMatureSprite; } private set { } }
}