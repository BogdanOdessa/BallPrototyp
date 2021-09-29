using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRoadView : MonoBehaviour
{
    private Rigidbody _roadRB;
        
    private void Start()
    {
        _roadRB = GetComponent<Rigidbody>();
        var currentColor = GetComponent<Renderer>().material.color = Color.gray;
    }

    public void ReduceSize(float sizeChangeSpeed)
    {
        _roadRB.transform.localScale -= new Vector3(sizeChangeSpeed, 0f,0f );
    }
}
