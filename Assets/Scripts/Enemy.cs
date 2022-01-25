using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : GameItem
{
    void  OnEnable()
    {
        ChoseColor();
        Move();
    }
    private void ChoseColor()
    {
        GetComponent<Renderer>().material.color =
                new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }
    public void FinalTouch()
    {
        OnPlayerTouch?.Invoke();
    }
}
