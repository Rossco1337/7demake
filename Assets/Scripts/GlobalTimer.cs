using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class GlobalTimer
{
    // Might make this class non-static in future
    // to keep multiple concurrent battles a possibility.
    private static int battleSpeed, speedValue;
    private static float normalSpeed;
    public static int BattleSpeed
    {
        get
        {
            return battleSpeed;
        }
        set
        {
            if (value >= 0 && value <= 255)
                battleSpeed = value;
            else
            {
                Debug.LogWarning("Battle Speed outside range, reset to 128");
                battleSpeed = 128;
            }
        }
    }
    // public int BattleSpeed(int battleSpeed)
    // {
    //     if (battleSpeed >= 0 && battleSpeed <= 255)
    //         return battleSpeed;
    //     else
    //         return 0;
    // }
    public static int SpeedValue
    {
        get
        {
            return speedValue;
        }
        set
        {
            speedValue = value;
        }
    }

    public static float NormalSpeed { get { return normalSpeed; } set { normalSpeed = value; } }

    public static void CalcGlobalSpeed()
    {
        speedValue = (32768 / (120 + (battleSpeed * 15 / 8)));
    }

    public static void CalcNormalSpeed(float partyDexAvg)
    {
        normalSpeed = (int)(Mathf.Ceil(partyDexAvg / 2)) + 50;
    }
}