using System;
using UnityEngine;

namespace Project.breakout_new.Scripts
{
[RequireComponent(typeof(Rigidbody))]
public class Paddle : MonoBehaviour
{
    private Rigidbody _Rigidbody;

    [SerializeField] private float left, right, speed;

    private void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody>();
        _Rigidbody.isKinematic = true;
        _Rigidbody.useGravity = false;
    }

    private void Reset()
    {
        left = -3;
        right = 3;
        speed = 12; // m/s
    }

    // Update is called once per frame
    private void Update()
    {
       //  not sure about the code here (seems kind of double)
       // wondering if moving left means making it negative
        float horizontalInput;
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            // move left at set speed
            horizontalInput = Input.GetAxis("Horizontal");
            
        } else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //move right at set speed
            horizontalInput = Input.GetAxis("Horizontal");
        } else
        {
            // nothing
        }
        
        // update position
        transform.position = transform.position + 
                             new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);
        //output to log the position change
        Debug.Log(transform.position);
    }
}
}
