using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FigureData", menuName = "FigureData", order = 1)]
public class FigureScriptable : ScriptableObject
{
    public string ObjectType;
    public int MinClicksCount;
    public int MaxClicksCount;
    public Color color;

    
}
