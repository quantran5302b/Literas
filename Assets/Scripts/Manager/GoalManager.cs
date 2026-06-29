using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    
    public static GoalManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private List<GoalCtrl> goals = new();

    public bool CheckWin()
    {
        foreach (GoalCtrl goal in goals)
        {
            if (!goal.IsCompleted())
            {
                return false;
            }
        }

        return true;
    }
}
