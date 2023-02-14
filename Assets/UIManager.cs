using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Instance Method

    public static UIManager Instance;


    public TextMeshProUGUI movesLeftText;

    private void InstanceMethod()
    {
        if (Instance)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Awake()
    {
        InstanceMethod();
    }

    #endregion
    void Start()
    {
        TimeManager.Instance.transform.DOMoveX(0, 0.025f).OnComplete(() =>
        {
            CheckMoveLeft();
        });
        
    }

   
    void Update()
    {
        
    }

    public void CheckMoveLeft()
    {
        movesLeftText.text = GameManager.Instance.ls.moveLeft.ToString();
    }
}
