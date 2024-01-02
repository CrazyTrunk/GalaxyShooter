
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Grid : MonoBehaviour
{
    [SerializeField] GameObject waypointPrefab;
    [SerializeField] private Transform currentTransform;
    [SerializeField] private int line = 8;
    [SerializeField] private int step = 2;
    [SerializeField] private int length = 12;
    float yPosInit;
    float xPosInit;
    private Vector3 pointPosition;
    public void Awake()
    {
        OnInit();
    }
    private void OnInit()
    {
        pointPosition = transform.position;
        yPosInit = pointPosition.y + 1.5f;
        xPosInit = pointPosition.x - 3f;
        DrawMatrix();
    }
    void DrawMatrix()
    {
        Vector3 currentPos = new Vector3(xPosInit, yPosInit, 0);

        for (int i = 0; i < length; i++)
        {
            GameObject currentPoint = Instantiate(waypointPrefab, currentPos, Quaternion.identity, currentTransform);
            currentPoint.name = $"Point {i}";
            if ((i + 1) % line == 0)
            {
                currentPos.y -= step;
                currentPos.x = xPosInit;
            }
            else
            {
                currentPos.x += step;
            }
        }
    }
}