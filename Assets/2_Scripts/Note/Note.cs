using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite appleSprite;
    [SerializeField] private Sprite blueberrySprite;
    public void Destroy()
    {
        GameObject.Destroy(gameObject);
    }

    internal void SetSprite(bool isApple)
    {
        spriteRenderer.sprite = isApple ? appleSprite : blueberrySprite;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
