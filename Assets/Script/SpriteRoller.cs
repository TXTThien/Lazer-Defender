using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRoller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;
    Vector2 offset;
    Material material;
    void Awake()
    {
        material=GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        offset = Time.deltaTime * moveSpeed;
        material.mainTextureOffset += offset;
    }
}
