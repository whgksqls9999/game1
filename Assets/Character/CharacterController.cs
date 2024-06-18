using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;

public class CharacterController : MonoBehaviour
{
    // ���
    public const float WALK_SPEED = 4f; // �ȱ� �ӵ�
    public const float RUN_SPEED = 8f;  // �޸��� �ӵ�
    public const float STAMINA_DECREASE_RATE = 20f; // ���׹̳� ���� �ӵ�
    public const float DIZZINESS_RUNNABLE_TIME = 3f; // ������ ���¿��� �޸� �� �ִ� �ð�

    // �⺻ �Ӽ�
    public int hp = 100; // ü��
    public int stamina = 100; // �޸���� �Ҹ��ϴ� ���׹̳�
    public int mentality = 100; // ���ŷ�
    public int orientation = 0; // �þ� ����

    public bool dizzy = false; // ������ �߻� ����
    public bool isOpenInventory = false; // �κ��丮 ���� ���� - �̰� ���Ŀ� �ý��������� ���°� �� ��

    // ���� ���� ���� ����
    public MoveState moveState = MoveState.stop; // �̵� ���� [stop, walk, run]
    public LifeState lifeState = LifeState.alive; // ���� ���� [alive, dead]

    public bool controllable = true;

    void Start()
    {
    }

    void Update()
    {
        controllable = checkControllable();
        dizzy = CheckDizzy();
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

    public void ChangeCharacter()
    {
        Debug.Log("::ĳ���� ����::");
    }

    public bool CheckDizzy()
    {
        if (this.stamina == 0)
        {
            return true;
        }
        return false;
    }

    public void CheckDIzzyRunning()
    {

    }
}
