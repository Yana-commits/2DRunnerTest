using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameItem : MonoBehaviour
{
    private float finishPoint;
    private float moveTime;

    public Action OnPlayerTouch;

    public void Init(float _finishPoint, float _moveTime)
    {
        finishPoint = _finishPoint;
        moveTime = _moveTime;
    }
    
    public void Move()
    {
        transform.DOLocalMoveX(finishPoint, moveTime).OnComplete(() => gameObject.SetActive(false));
    }
   
}
