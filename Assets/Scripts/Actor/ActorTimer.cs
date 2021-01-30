using UnityEngine;

public class ActorTimer : MonoBehaviour
{
    [Range(0, 65535)] public ushort vTime, vUnits, cTime, cUnits, turnTimer;

    /* don't know enough to use these in the inspector yet
    public struct VariableTimer {
        public ushort vTime;
        public uint vUnits;
    }
    */

    // public int TurnTimer
    // {

    // }

    //vtimer inc 
    //actor.IncreaseVTimer(2 * SpeedValue);
}