using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WayFinder : MonoBehaviour
{
    private Transform destination;
    private WaveData currentWave;
    private void Start()
    {
        currentWave = WaveSpawner.Instance.GetCurrentWave();
    }
    public void SetDestionation(Transform des)
    {
        destination = des;
    }
    private void Update()
    {
        float delta = currentWave.GetMoveSpeed() * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, destination.position, delta);
    }
}
