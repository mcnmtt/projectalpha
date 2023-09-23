using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 2.0f;
    [SerializeField] private float runSpeed = 5.0f;
    [SerializeField] private float jumpForce = 2.0f;
    [SerializeField] private GameInput gameInput;
    private bool isWalking;
    private bool isRunning;

    void Start()
    {
    }

    void Update()
    {
        Vector3 moveDir = gameInput.GetMovementVectorNormalized();
        Vector2 run = gameInput.CheckRun();

        //Permette al personaggio di ruotare
        float rotationSpeed = 8.0f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotationSpeed * Time.deltaTime);

        isWalking = moveDir != Vector3.zero;
        isRunning = run != Vector2.zero;

        if (isRunning)
        {
            //Il personaggio corre
            transform.position += moveDir * runSpeed * Time.deltaTime;
        }
        if (isWalking && !isRunning)
        {
            //Il personaggio cammina
            transform.position += moveDir * walkSpeed * Time.deltaTime;
        }
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    public bool IsRunning()
    {
        return isRunning;
    }
}
