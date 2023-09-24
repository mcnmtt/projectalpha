using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputs playerInputs;
    // Start is called before the first frame update
    private void Awake()
    {
        playerInputs = new PlayerInputs();
        playerInputs.Enable();
    }

    public Vector3 GetMovementVectorNormalized()
    {
        Vector3 moveDir = playerInputs.Player.Move.ReadValue<Vector3>();

        moveDir = moveDir.normalized;

        return moveDir;
    }

    public Vector2 CheckRun()
    {
        Vector2 run = playerInputs.Player.Run.ReadValue<Vector2>();

        return run;
    }
}
