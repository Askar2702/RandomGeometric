using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Figure
{
    protected override void Start()
    {
        TextAsset targetFile = Resources.Load<TextAsset>("DataName");
        item = JsonUtility.FromJson<item>(targetFile.text);
        name = item.Cube;
        base.Start();
    }
}
