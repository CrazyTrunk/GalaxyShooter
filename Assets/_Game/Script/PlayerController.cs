using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] float offScreenThreshold = 5f;
    Vector2 startBounds;
    Vector2 endBounds;

    Vector2 inputRaw;
    private void Start()
    {
        InitBounds();
    }
    void Update()
    {
        if (GameManager.Instance.IsState(GameState.PLAYING))
        {
            Move();
        }
    }
    void InitBounds()
    {
        startBounds = cam.ViewportToWorldPoint(new Vector2(0, 0));
        endBounds = cam.ViewportToWorldPoint(new Vector2(1, 1));

    }
    private void Move()
    {
        Vector3 delta = inputRaw * moveSpeed * Time.deltaTime;
        Vector2 newFixedPos = new Vector2(Mathf.Clamp(transform.position.x + delta.x, startBounds.x + offScreenThreshold, endBounds.x - offScreenThreshold), Mathf.Clamp(transform.position.y + delta.y, startBounds.y + offScreenThreshold, endBounds.y - offScreenThreshold));
        transform.position = newFixedPos;
    }

    private void OnMove(InputValue value)
    {
        inputRaw = value.Get<Vector2>();
    }
}
