
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "WaveData/WaveData")]
[Serializable]
public class WaveData : ScriptableObject
{
    public GameObject pathPrefab;
    // for bots
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] private bool isScene;

    public bool IsScene { get => isScene; set => isScene = value; }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }
    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }
    public Transform GetStartingWaypoint()
    {
        return pathPrefab.transform;
    }
    public virtual List<Transform> GetWayPoints(Transform path)
    {
        List<Transform> waypoints = new List<Transform>();
        foreach ( Transform child in path)
        {
            waypoints.Add(child.transform);
        }
        return waypoints;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
