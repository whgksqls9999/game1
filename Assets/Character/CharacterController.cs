using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterState;

public class CharacterController : MonoBehaviour
{
    // 상수
    public const float WALK_SPEED = 4f; // 걷기 속도
    public const float RUN_SPEED = 8f;  // 달리기 속도
    public const float STAMINA_DECREASE_RATE = 20f; // 스테미너 감소 속도
    public const float DIZZINESS_RUNNABLE_TIME = 3f; // 현기증 상태에서 달릴 수 있는 시간

    // 기본 속성
    public float hp = 100f; // 체력
    public float stamina = 100f; // 달리기시 소모하는 스테미너
    public float mentality = 100f; // 정신력
    public int orientation = 0; // 시야 방향

    public bool dizzy = false; // 현기증 발생 여부
    public float dizzinessTimer = 0f; // 현기증 발생 후 연속으로 달린 시간

    public bool isControllable = true; // 조작 가능한 상태 여부

    public bool isOpenInventory = false; // 인벤토리 오픈 여부 - 이건 추후에 시스템쪽으로 빼는게 날 듯

    // 동작 관련 상태 관리
    public MoveState moveState = MoveState.stop; // 이동 상태 [stop, walk, run]
    public LifeState lifeState = LifeState.alive; // 생존 상태 [alive, dead]

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
            Debug.Log("::인벤토리 오픈::");
            return;
        }
        isOpenInventory = false;
        Debug.Log("::인벤토리 클로즈::");
        
    }

    public void Interact()
    {
        Debug.Log("::상호작용::");
    }
    public void ChangeEquipment()
    {
        Debug.Log("::장비 변경::");
    }

    public void ChangeCharacter()
    {
        Debug.Log("::캐릭터 변경::");
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
                Debug.Log("캐릭터가 심장마비로 사망했습니다.");
            }
        } else
        {
            dizzinessTimer = 0f;
        }
    }
}
