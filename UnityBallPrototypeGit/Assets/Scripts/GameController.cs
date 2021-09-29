using System;
using System.Collections;
using System.Collections.Generic;
using BallPrototype.BallRoad;
using UnityEngine;
using UnityEngine.Serialization;

namespace BallPrototype
{
  public class GameController : MonoBehaviour
  {
      [SerializeField] private GameObject shootBallPrefab;
      [SerializeField] private MainBallView mainBallView;
      [SerializeField] private BallRoadView ballRoadView;
      [SerializeField] private Door door;
      [SerializeField] private RayShoot rayShoot;
      
      private ShootingBallView _shootBallView;
      private MainBallController _mainBallController;
      private ShootingBallController _shootingBallController;
      private BallRoadController _ballRoadController;
      
      private bool _wasSummoned;
      private bool _wasShoot;

      private void Awake()
      {
          _mainBallController = new MainBallController(mainBallView,new MainBallModel());
          _ballRoadController = new BallRoadController(ballRoadView, new BallRoadModel());
      }

      private void Update()
      {
          if (Input.GetMouseButton(UserInputController.Tap))
          {
              var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
              
              if (Physics.Raycast(ray, out var hit))
              {
                  if (hit.transform.name == mainBallView.gameObject.name)
                  {
                      SummonTheBall();
                      ChargeTheBallWithPower();
                  }
              }
          }
          if (Input.GetMouseButtonUp(UserInputController.Tap))
          {
              MoveTheBall();
          }

          door.Execute();
          rayShoot.Execute();
      }

      private void SummonTheBall()
      {
          if (!_wasSummoned)
          {
              _shootBallView = Instantiate(shootBallPrefab).GetComponent<ShootingBallView>();
              _shootingBallController = new ShootingBallController(_shootBallView,  new ShootingBallModel());
              _wasSummoned = true;
          }
      }

      private void ChargeTheBallWithPower()
      {
          if (_shootBallView != null && _wasShoot == false)
          {
              _mainBallController.ReduceSize();
              _ballRoadController.ReduceSize();
              _shootingBallController.IncreaseSize();
              _shootingBallController.IncreaseColliderRadiusSize();
          }
      }

      private void MoveTheBall()
      { 
          if(_shootBallView != null && _wasShoot == false) _shootingBallController.Move();
          _wasShoot = true;
      }

      public void NewBallReadyToShoot()
      {
          _wasSummoned = false;
          _wasShoot = false;
      }

      public void MoveMainBallToFinish()
      {
          _mainBallController.Move();
      }
  }  
}


