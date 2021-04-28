using System;
using UnityEngine;

namespace Project.breakout_new.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        private Rigidbody _Rigidbody;
        [SerializeField] private float speed;

        private void Awake()
        {/*
        * Use Awake to assign a reference to the Rigidbody component to the _rigidBody variable
          */
            _Rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            /*
             * Finally, implement the OnCollisionEnter method

            This method is called by Unity when a rigid body collides with a collider 
            (in this case, when the ball collides with a brick, the water or the paddle)

            We are not interested in the latter (physics engine takes care of the collision response)

            However, this method should call the corresponding game manager method when one of the first two cases takes place
             */
            if (other.GetType() == typeof(Water))
            {
                GameManager.CollideWater;
            }
            else if (other.GetType() == typeof(Brick))
            {
                GameManager.CollideBrick;
            }
            
        }

        private void Reset()
        {
            // Use Reset to set the default value of the speed variable (12 m/s in the example)
            speed = 12; // m/s
        }

        private void Start()
        {
            // ForceMode allows you to choose from four different ways to affect the GameObject using this Force:
            // Acceleration, Force, Impulse, and VelocityChange.
            Vector3 force = new Vector3(0.2, -speed, 0)
            _Rigidbody.AddForce(force, ForceMode.VelocityChange);
        }
    }
}

