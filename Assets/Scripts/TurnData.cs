using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnData : MonoBehaviour
{
    public List<UndoData> datas = new List<UndoData>();

    public void AddData(UndoData data)
    {
        datas.Add(data);
    }
}
