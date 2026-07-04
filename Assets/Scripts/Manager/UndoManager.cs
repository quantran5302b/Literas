using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

public class UndoManager : MonoBehaviour
{
    public static UndoManager Instance;
    //private Stack<MoveData> history = new Stack<MoveData>();


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
    public void AddMove(MoveData move)
    {
        currentTurn.AddMove(move);
    }

    public void BeginTurn()
    {
        currentTurn = new TurnData();
    }
    public void EndTurn()
    {
        if (currentTurn.moves.Count == 0)
            return;

        history.Push(currentTurn);

        currentTurn = null;
    }

    //public void SaveMove(MoveData data)
    //{
    //    history.Push(data);
    //}
    //public void Undo()
    //{
    //    if (history.Count == 0) return;
    //    MoveData data = history.Pop();
    //    data.player.UndoMove(data.previousPos);
    //}

    public void Undo()
    {
        if (history.Count == 0) return;
        TurnData turn = history.Pop();
        //data.player.UndoMove(data.previousPos);

        for (int i = turn.moves.Count - 1; i >= 0; i--)
        {
            MoveData move = turn.moves[i];

            move.player.UndoMove(move.previousPos);
        }
    }
}
