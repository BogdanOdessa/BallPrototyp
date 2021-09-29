using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace BallPrototype
{
    //Shoot the Ray to the door and checks if the Main ball can move to the finish.
    //If Ray hits the door, not the obstacle, then Main ball moves to finish
    public class RayShoot : MonoBehaviour
    {
        [SerializeField] private GameController gameController;
        
        private Transform _transform;
        private Vector3 _ray;
        private RaycastHit _hit;
        private readonly float _maxDistance = 100f;
        private readonly string _door = "Door";
        
        private void Start()
        {
            _transform = GetComponent<Transform>();
        }
        public void Execute()
        {
            _ray = _transform.position;
            if (Physics.Raycast(_ray, Vector3.forward, out _hit ,_maxDistance))
            {
                if (_hit.collider.gameObject.CompareTag(_door))
                {
                    gameController.MoveMainBallToFinish();
                }
            }
        }
        // private void OnDrawGizmos()
        // {
        //     Gizmos.color = Color.red;
        //     Gizmos.DrawLine(_ray, _hit.point);
        // }
    }
}

