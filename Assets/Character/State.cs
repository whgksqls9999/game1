using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public enum MoveState
    {
        stop,
        walk,
        run
    }

    public enum LifeState
    {
        alive,
        dead
    }
}
