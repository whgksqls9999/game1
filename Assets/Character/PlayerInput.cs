using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();   
    }

    void HandleMovementInput()
    {
        float horizontalValue = Input.GetAxisRaw("Horizontal");
        float verticalValue = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(horizontalValue, verticalValue);
        dir.Normalize();

        Debug.Log(dir);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Run(dir);
            return;
        }

        characterController.Walk(dir);
    }
}
