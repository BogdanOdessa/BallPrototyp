using System;
using UnityEngine;

namespace BallPrototype
{
    public class MainBallView : MonoBehaviour
    {
        private Rigidbody _mainBallRb;
        
        private void Start()
        {
            _mainBallRb = GetComponent<Rigidbody>();
            var currentColor = GetComponent<Renderer>().material.color = Color.magenta;
        }

        public void ReduceSize(float sizeChangeSpeed)
        {
            _mainBallRb.transform.localScale -= new Vector3(sizeChangeSpeed, sizeChangeSpeed, sizeChangeSpeed);
        }
        
        public void Move(float speed)
        {
            _mainBallRb.AddForce(Vector3.forward * speed,ForceMode.Force);
        }
    }
}