using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnData : MonoBehaviour
{
    public List<MoveData> moves = new List<MoveData>();

    public void AddMove(MoveData move)
    {
        moves.Add(move);
    }
}
