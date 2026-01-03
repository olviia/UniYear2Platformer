using System;
using Unity.VisualScripting;
using UnityEngine;

//hardcoded goals
public enum objectiveNames
{Coin, Enemy, Key }

public class LevelObjective : MonoBehaviour
{
    
    public static LevelObjective Instance { get; private set; }
    
    public objectiveNames objectiveName;
    [HideInInspector]
    public int objectiveProgress = 0;
    public int objectiveGoal;
    
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    public void UpdateObjectiveState()
    {
        switch (objectiveName)
        {
            case objectiveNames.Coin:
                objectiveProgress = PlayerInventory.Instance.coins; 
                break;
            case objectiveNames.Key:
                objectiveProgress = PlayerInventory.Instance.keys;
                break;
            case objectiveNames.Enemy:
                //I put enemies into inventory because i didn't want to create a separate script for it
                objectiveProgress = PlayerInventory.Instance.enemiesDefeated;
                break;
            default:
                objectiveProgress = 0;
                break;
        }
    }

    public bool IsComplete()
    {
        return objectiveGoal <= objectiveProgress;

    }

}
