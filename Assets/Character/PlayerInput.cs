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
        HandleChangeEquipmentInput();
        HandleInteractionInput();
        HandleChangeCharacterInput();
    }

    void HandleMovementInput()
    {
        float horizontalValue = Input.GetAxisRaw("Horizontal");
        float verticalValue = Input.GetAxisRaw("Vertical");

        // 아무 움직임이 없다면 메서드 벗어나기
        if (horizontalValue == 0 && verticalValue == 0) return;

        Vector2 dir = new Vector2(horizontalValue, verticalValue);
        dir.Normalize();

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

    void HandleChangeEquipmentInput()
    {
        bool isKeyDown = Input.GetKeyDown(KeyCode.A);

        if (!isKeyDown) return;

        characterController.ChangeEquipment();
    }

    void HandleChangeCharacterInput()
    {
        bool isKeyDown = Input.GetKeyDown(KeyCode.Q);

        if (!isKeyDown) return;

        characterController.ChangeCharacter();
    }
}
