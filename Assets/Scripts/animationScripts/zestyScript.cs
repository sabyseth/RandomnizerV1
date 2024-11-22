using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zestyScript : MonoBehaviour
{
    Animator animator;
    float blend = 0.0f;
    public float acceleration = 0.1f;
    public float deceleration = 0.1f;
    int BlendHash;
    
    void Start()
    {
        animator = GetComponent<Animator>();

        BlendHash = Animator.StringToHash("Blend");
    }

    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        if (forwardPressed && blend < 1.0f)
        {
            blend  += Time.deltaTime * acceleration;
        }

        if (!forwardPressed && blend > 0.0f)
        {
            blend -= Time.deltaTime * acceleration;
        }
        if (!forwardPressed && blend < 0.0f)
        {
            blend = 0;
        }


        animator.SetFloat(BlendHash, blend);
    }
}
