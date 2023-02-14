using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpecial : MonoBehaviour
{
    public int moveLeft;
    public int moves;
    public bool lastShot;
    
    void Start()
    {
        GameManager.Instance.ls = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCheck()
    {
        if (moves == 1)
        {
            print("PERFECT!!");
        }
        
        if (moves is > 1 and <= 3)
        {
            print("Nice!");
        }
        
        if (moves is > 3 and <= 5)
        {
            print("Cleared");
        }

        moves = 0;
    }
}
