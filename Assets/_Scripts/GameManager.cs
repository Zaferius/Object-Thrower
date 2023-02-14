using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public LevelSpecial ls;
    
    public List<Color> bgColors = new List<Color>();

    public GameObject connectParticle;
    
    private void Awake()
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

    public void GameWin()
    {
        print("U WIN!");
        
        TimeManager.Instance.transform.DOMoveX(0, 2f).OnComplete(() =>
        {
            LevelManager.Instance.NextLevel();
        });
    }

    public void GameLose()
    {
        print("U Lose");
        
        TimeManager.Instance.transform.DOMoveX(0, 2f).OnComplete(() =>
        {
            LevelManager.Instance.ReloadLevel();
        });
    }
}
