using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

namespace BallPrototype
{
    public class Door : MonoBehaviour
        {
            [SerializeField] private float rotSpeed = 2f;
            [SerializeField] private MainBallView mainBallView;

            private readonly float _doorOpenAngle = 160.0f;
            private float _doorCloseAngle;
            private bool _isActive;
            private void Start()
            {
                var doorColor = GetComponentInChildren<Renderer>().material.color = Color.yellow;
            }
            
            public void Execute()
            {
                if (_isActive)
                    StartRotation();
            }
            private void StartRotation()
            {
                StartCoroutine(Rotation());
            }
            IEnumerator Rotation()
            {
                while(_doorCloseAngle <= _doorOpenAngle)
                {
                    _doorCloseAngle++;
                    transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
                    yield return null;
                }
            }

            private void OnTriggerEnter(Collider other)
            {
                if (other.gameObject.name == mainBallView.gameObject.name)
                {
                    _isActive = true;
                }
            }
        }
    }
