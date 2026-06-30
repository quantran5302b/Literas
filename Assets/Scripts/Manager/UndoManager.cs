using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

public class UndoManager : MonoBehaviour
{
    public static UndoManager Instance;
    private Stack<MoveData> history = new Stack<MoveData>();
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
    public void SaveMove(MoveData data)
    {
        history.Push(data);
    }
    public void Undo()
    {
        if (history.Count == 0)return;
        MoveData data = history.Pop();
        data.player.UndoMove(data.previousPos);
    }
}
