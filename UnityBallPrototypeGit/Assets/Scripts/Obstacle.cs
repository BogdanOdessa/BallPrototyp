using System;
using System.Collections;
using System.Collections.Generic;
using BallPrototype;
using UnityEngine;

namespace BallPrototype
{
    public class Obstacle : MonoBehaviour
    {
        private Color _currentColor;
        private Renderer _renderer;
        private readonly Color _bombColor = Color.red;
        private GameController _gameController;
        private void Start()
        {
            _gameController = FindObjectOfType<GameController>();
            _renderer = GetComponent<Renderer>();
            _currentColor = GetComponent<Renderer>().material.color = Color.green;
        }

        private void OnTriggerEnter(Collider other)
        {
            DestroyTheObstacle();
        }

        private void DestroyTheBall(Component other)
        {
            Destroy(other.gameObject, 5f);
            Invoke(nameof(MakeNewBallReadyToSummon), 5f);
        }

        private void DestroyTheObstacle()
        {
            _currentColor = _bombColor;
            _renderer.material.color = _currentColor;
            if (_currentColor == _bombColor)
            {
                Destroy(gameObject, 5f);
            }
        }
        private void MakeNewBallReadyToSummon()
        {
            _gameController.NewBallReadyToShoot();
        }
    }
}

