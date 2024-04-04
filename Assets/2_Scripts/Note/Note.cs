using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite appleSprite;
    [SerializeField] private Sprite blueberrySprite;

    private bool isApple;
    public void Destroy()
    {
        GameObject.Destroy(gameObject);
    }

    internal void SetSprite(bool isApple)
    {
        this.isApple = isApple;
        spriteRenderer.sprite = isApple ? appleSprite : blueberrySprite;
    }

    public void DeleteNote()
    {
        GameManager.Instance.CalculateScore(isApple);
        Destroy();
    }

}
