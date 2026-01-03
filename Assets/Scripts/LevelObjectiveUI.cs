using System;
using TMPro;
using UnityEngine;

public class LevelObjectiveUI : MonoBehaviour
{
    public TextMeshProUGUI guiObjective;

    private void Update()
    {
        guiObjective.text = LevelObjective.Instance.objectiveName.ToString() + " "+ 
                            LevelObjective.Instance.objectiveProgress +"/"+
                            LevelObjective.Instance.objectiveGoal;
    }
}
