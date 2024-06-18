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
        HandleInventoryInput();
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

    void HandleInventoryInput()
    {
        bool isKeyDown = Input.GetKeyDown(KeyCode.X);

        if (!isKeyDown) return;

        characterController.OpenInventory();
    }

    void HandleInteractionInput()
    {
        bool isKeyDown = Input.GetKeyDown(KeyCode.Z);

        if (!isKeyDown) return;

        characterController.Interact();
    }
}
