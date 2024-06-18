using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static State;

public class Character : MonoBehaviour
{
    public int hp = 100;
    public int stamina = 100;
    public int mentality = 100;
    public int orientation = 100;

    public MoveState moveState = MoveState.stop;
    public LifeState lifeState = LifeState.alive;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
