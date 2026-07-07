using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

public class UndoManager : MonoBehaviour
{
    public static UndoManager Instance;

    private Stack<TurnData> history = new Stack<TurnData>();

    private TurnData currentTurn;
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
    public void AddData(UndoData data)
    {
        currentTurn.AddData(data);
    }

    public void BeginTurn()
    {
        currentTurn = new TurnData();
    }
    public void EndTurn()
    {
        if (currentTurn.datas.Count == 0)
            return;

        history.Push(currentTurn);

        currentTurn = null;
    }



    public void Undo()
    {
        if (history.Count == 0) return;
        TurnData turn = history.Pop();
        for (int i = turn.datas.Count - 1; i >= 0; i--)
        {
            turn.datas[i].Undo();
        }
    }
}
