using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;

public class CharacterController : MonoBehaviour
{
    public const float WALK_SPEED = 4f;
    public const float RUN_SPEED = 8f;

    private int hp = 100;
    private int stamina = 100;
    private int mentality = 100;
    private int orientation = 100;

    private bool isOpenInventory = false;

    private MoveState moveState = MoveState.stop;
    private LifeState lifeState = LifeState.alive;

    private bool controllable = true;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        controllable = checkControllable();
    }

    bool checkControllable()
    {
        if (lifeState.Equals(LifeState.dead))
        {
            return false;
        }

        return true;
    }

    public void Walk(Vector2 dir)
    {
        if (!controllable) return;

        transform.Translate(WALK_SPEED * dir * Time.deltaTime);
    }

    public void Run(Vector2 dir)
    {
        if (!controllable) return;

        transform.Translate(RUN_SPEED * dir * Time.deltaTime);
    }

    public void OpenInventory()
    {
        if (!isOpenInventory)
        {
            isOpenInventory = true;
            Debug.Log("::�κ��丮 ����::");
            return;
        }
        isOpenInventory = false;
        Debug.Log("::�κ��丮 Ŭ����::");
        
    }

    public void Interact()
    {
        Debug.Log("::��ȣ�ۿ�::");
    }
    public void ChangeEquipment()
    {
        Debug.Log("::��� ����::");
    }
}
