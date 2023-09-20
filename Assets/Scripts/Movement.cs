using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;
    private Rigidbody rigidBody;

    void Start()
    {
        //Assign RigidBody to rigidbody
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {

        Vector3 shift = new Vector3(0, 0, 0);

        //W key input
        if (Input.GetKey(KeyCode.W)){
            shift.z = +1;
        }

        //S key input
        if (Input.GetKey(KeyCode.S)){
            shift.z = -1;
        }


        //A key input
        if (Input.GetKey(KeyCode.A)){
            shift.x = -1;
        }

        //D key input
        if (Input.GetKey(KeyCode.D)){
            shift.x = +1;
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            shift.y = +1;

            rigidBody.AddForce(shift * jumpForce, ForceMode.Impulse);
        }

        //Movimento del personaggio
        transform.position += shift * speed * Time.deltaTime;

        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
