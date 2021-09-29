
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

namespace BallPrototype
{
    public class ShootingBallView : MonoBehaviour
    {
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private SphereCollider sphereCollider;
        private GameController _gameController;

        private void Start()
        {
            _gameController = FindObjectOfType<GameController>();
            var randColor = GetComponent<Renderer>().material.color = Random.ColorHSV();
        }

        public void IncreaseSize(float sizeChangeSpeed)
        {
            rigidbody.transform.localScale += new Vector3(sizeChangeSpeed, sizeChangeSpeed, sizeChangeSpeed);
        }

        public void IncreaseColliderRadiusSize(float radiusChangeSpeed)
        {
            sphereCollider.radius += radiusChangeSpeed;
        }

        public void Move(float speed)
        {
            rigidbody.AddForce(Vector3.forward * speed,ForceMode.Force);
        }
        
        //should fix this later and bring bottom actions to BallController, create timer instead invoke
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                Invoke(nameof(MakeNewBallReadyToSummon), 5f);
                Destroy(gameObject, 5f);
            }

        }
        private void MakeNewBallReadyToSummon()
        {
            _gameController.NewBallReadyToShoot();
        }
    }  
}

