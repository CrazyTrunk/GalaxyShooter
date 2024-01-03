using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WayFinder : MonoBehaviour
{
    private Transform destination;
    private WaveData currentWave;
    private Vector3 originalPosition;
    public float moveRange = 0.5f;
    public float moveSpeed = 1f;
    private bool movingUp = true;
    private void Start()
    {
        currentWave = WaveSpawner.Instance.GetCurrentWave();
    }
    public void SetDestionation(Transform des)
    {
        destination = des;
        originalPosition = destination.position;
    }
    private void Update()
    {
        if (!WaveSpawner.Instance.isSpawning)
        {
            GameManager.Instance.ChangeState(GameState.PLAYING);
        }
        if (GameManager.Instance.IsState(GameState.PREPARING))
        {
            MoveToDestinate();
        }
        if (GameManager.Instance.IsState(GameState.PLAYING))
        {
            if (movingUp)
            {
                if (transform.position.y < originalPosition.y + moveRange)
                {
                    transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
                }
                else
                {
                    movingUp = false;
                }
            }
            else
            {
                if (transform.position.y > originalPosition.y - moveRange)
                {
                    transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
                }
                else
                {
                    movingUp = true;
                }
            }
        }
      
    }

    private void MoveToDestinate()
    {
        float delta = currentWave.GetMoveSpeed() * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, destination.position, delta);
    }
}
