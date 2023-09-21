using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private GameInput gameInput;
    private bool isWalking;

    void Start()
    {
    }

    void Update()
    {
        Vector3 moveDir = gameInput.GetMovementVectorNormalized();

        //Movimento del personaggio
        transform.position += moveDir * speed * Time.deltaTime;

        if (moveDir != Vector3.zero)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        
        //permette al personaggio di ruotarsi
        float rotationSpeed = 8.0f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotationSpeed * Time.deltaTime);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
