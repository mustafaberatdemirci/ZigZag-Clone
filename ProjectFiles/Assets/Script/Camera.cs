using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform ballLocation;
    Vector3 _difference;
    void Start()
    {
        _difference = transform.position - ballLocation.position;
    }


    void Update()
    {
        if (BallController.ballDrop==false)
        {
            transform.position = ballLocation.position + _difference;
        }     
    }
}
