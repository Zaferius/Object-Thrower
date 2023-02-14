using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayObjectTip : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tip"))
        {
            if (!other.GetComponent<WrongObjectTip>().isConnected)
            {
                other.GetComponent<WrongObjectTip>().obstacleSpecial.TipConnected();
                other.GetComponent<WrongObjectTip>().isConnected = true;
            }
          
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tip"))
        {
            if (other.GetComponent<WrongObjectTip>().isConnected)
            {
                other.GetComponent<WrongObjectTip>().obstacleSpecial.TipRemoved();
                other.GetComponent<WrongObjectTip>().isConnected = false;
            }
        }
    }
}
