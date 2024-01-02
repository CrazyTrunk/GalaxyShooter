using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelManagerScriptableObject", order = 1)]
public class LevelManagerScriptableObject : ScriptableObject
{
    public int level;
    public int numberOfBots;

    public List<WaveData> waves;
}