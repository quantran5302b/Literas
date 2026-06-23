using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

public class UndoManager : MonoBehaviour
{
    public static UndoManager Instance;
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


    private Stack<MoveData> history = new Stack<MoveData>();

    public void SaveMove(MoveData data)
    {

        history.Push(data);
    }

    public MoveData Undo()
    {
        if (history.Count == 0)return null;
        return history.Pop();
    }
}
