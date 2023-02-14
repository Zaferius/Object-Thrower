using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongObjectTip : MonoBehaviour
{
    public ObstacleSpecial obstacleSpecial;
    public bool isConnected;
    void Start()
    {
        obstacleSpecial.tipTransforms.Add(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
