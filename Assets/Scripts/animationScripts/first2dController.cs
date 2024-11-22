using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class first2dController : MonoBehaviour
{
    Animator animator;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;
    float currentMaxVelocity = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        //search the gameObject this script is attacked to and get the animator component
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool backPressed = Input.GetKey("s");

        //float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity;
        if (runPressed)
        {
            currentMaxVelocity = maximumRunVelocity;
            
        }
            else
            {
                currentMaxVelocity = maximumWalkVelocity;
        }
        
        if (currentMaxVelocity == 0)
        {
            currentMaxVelocity = 0.5f;
        }

        // if player presses forward, increase velocity in z direction
        if (forwardPressed && velocityZ < currentMaxVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
        }

        // increase veloctiy in left direction
        if (leftPressed && velocityX > -0.5f && !runPressed)
        {
            velocityX -= Time.deltaTime * acceleration;
        }

        // increase veloctiy in right direction
        if (rightPressed && velocityX < 0.5f && !runPressed)
        {
            velocityX += Time.deltaTime * acceleration;
        }

        // decrease velocityZ
        if (!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }

        // reset velocityZ
        if (!forwardPressed && velocityZ < 0.0f)
        {
            velocityZ = 0.0f;
        }

        if (!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deceleration;
        }

        if (!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * deceleration;
        }

        if (!leftPressed && !rightPressed && velocityX!= 0.0f && (velocityX > -0.05f && velocityX < 0.05f))
        {
            velocityX = 0.0f;
        }

        // lock forward
        if (forwardPressed &&  runPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ = currentMaxVelocity;
        }
        // decelerate to the maximum walk velocity
        else if (forwardPressed && velocityZ > currentMaxVelocity)
        {
            velocityZ -= Time.deltaTime * deceleration;
            // round to the ccurrentMaxVelocity if within offset
            if (velocityZ > currentMaxVelocity && velocityZ < (currentMaxVelocity + 0.05))
            {
                velocityZ = currentMaxVelocity;
            }
        }
        // round to the currentMaxVelocity if within offset
        else if (forwardPressed && velocityZ < currentMaxVelocity && velocityZ > (currentMaxVelocity - 0.05f))
        {
            velocityZ = currentMaxVelocity;
        }
        
        // //locking left
        // if (leftPressed &&  runPressed && velocityX < -currentMaxVelocity)
        // {
        //     velocityX = -currentMaxVelocity;
        // }
        // //decelerate to the maximum walk velocity
        // else if (leftPressed && velocityX < -currentMaxVelocity)
        // {
        //     velocityX+= Time.deltaTime * deceleration;
        //     if (velocityX < -currentMaxVelocity && velocityX > (-currentMaxVelocity - 0.05f))
        //     {
        //         velocityX = -currentMaxVelocity;
        //     }
        // }

        // else if (leftPressed && velocityX > -currentMaxVelocity && velocityX < (-currentMaxVelocity + 0.05f))
        // {
        //     velocityX = -currentMaxVelocity;
        // }

        // if (rightPressed &&  runPressed && velocityX > currentMaxVelocity)
        // {
        //     velocityX = currentMaxVelocity;
        // }
        
        // else if (rightPressed && velocityX > currentMaxVelocity)
        // {
        //     velocityX -= Time.deltaTime * deceleration;
        //     if (velocityX > currentMaxVelocity && velocityX < (currentMaxVelocity + 0.05))
        //     {
        //         velocityX = currentMaxVelocity;
        //     }
        // }
        // else if (rightPressed && velocityX < currentMaxVelocity && velocityX> (currentMaxVelocity - 0.05f))
        // {
        //     velocityX = currentMaxVelocity;
        // }

        animator.SetFloat("velocityZ", velocityZ);
        animator.SetFloat("VelocityX", velocityX);
    }
}
