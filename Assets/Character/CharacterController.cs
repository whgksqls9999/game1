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
    public float hp = 100f; // ü��
    public float stamina = 100f; // �޸���� �Ҹ��ϴ� ���׹̳�
    public float mentality = 100f; // ���ŷ�
    public int orientation = 0; // �þ� ����

    public bool dizzy = false; // ������ �߻� ����
    public float dizzinessTimer = 0f; // ������ �߻� �� �������� �޸� �ð�

    public bool isControllable = true; // ���� ������ ���� ����

    public bool isOpenInventory = false; // �κ��丮 ���� ���� - �̰� ���Ŀ� �ý��������� ���°� �� ��

    // ���� ���� ���� ����
    public MoveState moveState = MoveState.stop; // �̵� ���� [stop, walk, run]
    public LifeState lifeState = LifeState.alive; // ���� ���� [alive, dead]

    void Start()
    {
    }

    void Update()
    {
        isControllable = checkControllable();
        dizzy = CheckDizzy();
        lifeState = CheckAlive();
        CheckDIzzyRunning();
    }

    bool checkControllable()
    {
        if (lifeState.Equals(LifeState.dead))
        {
            return false;
        }

        return true;
    }

    LifeState CheckAlive()
    {
        if (this.hp > 0)
        {
            return LifeState.alive;
        }

        return LifeState.dead;
    }
    public void Stop()
    {
        this.moveState = MoveState.stop;
    }

    public void Walk(Vector2 dir)
    {
        if (!isControllable)
        {
            this.Stop();
            return;
        };

        this.moveState = MoveState.walk;
        transform.Translate(WALK_SPEED * dir * Time.deltaTime);
    }

    public void Run(Vector2 dir)
    {
        if (!isControllable)
        {
            this.Stop();
            return;
        }

        this.moveState = MoveState.run;
        stamina = Math.Max(stamina - Time.deltaTime * STAMINA_DECREASE_RATE, 0);
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
        if (this.dizzy && this.moveState == MoveState.run)
        {
            dizzinessTimer += Time.deltaTime;

            if (dizzinessTimer >= DIZZINESS_RUNNABLE_TIME)
            {
                this.hp = 0;
                Debug.Log("ĳ���Ͱ� ���帶��� ����߽��ϴ�.");
            }
        } else
        {
            dizzinessTimer = 0f;
        }
    }
}
