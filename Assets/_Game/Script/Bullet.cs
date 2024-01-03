using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2;
    private Vector2 velocity;
    [SerializeField] float projectileLifetime = 10f;

    void Start()
    {
        Destroy(gameObject, projectileLifetime);
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        velocity = transform.up * speed;
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;
    }
}
