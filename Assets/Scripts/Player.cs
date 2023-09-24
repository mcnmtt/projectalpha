using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 2.0f;
    [SerializeField] private float runSpeed = 5.0f;
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

        float playerHeight = 1.0f;
        float playerRadius = 0.5f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, .1f);

        //Permette al personaggio di ruotare
        float rotationSpeed = 8.0f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotationSpeed * Time.deltaTime);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);

            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, .1f);

            if (canMove)
            {
                moveDir = moveDirX;
            }
            if (!canMove)
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);

                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, .1f);

                if (canMove)
                {
                    moveDir = moveDirZ;
                }
                if (!canMove) { }
            }
        }
        
        isWalking = moveDir != Vector3.zero;
        isRunning = run != Vector2.zero;

        if (canMove) 
        {
            if (isRunning) 
            {
                //Movimento del personaggio
                transform.position += moveDir * runSpeed * Time.deltaTime;
            }
            if (isWalking && !isRunning)
            {
                transform.position += moveDir * walkSpeed * Time.deltaTime;
            }
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
