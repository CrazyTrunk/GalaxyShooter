using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    [SerializeField] private Vector2 moveSpeed;
    Vector2 offset;
    Material material;
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    void Update()
    {
        offset = moveSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
