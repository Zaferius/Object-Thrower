using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("PlayObj"))
        {
            Destroy(col.gameObject);
            GameManager.Instance.GameLose();
        }
    }
}
