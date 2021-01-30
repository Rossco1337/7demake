using UnityEngine;

public static class GlobalTimer
{
    // Might make this class non-static in future
    // to keep multiple concurrent battles a possibility.
    private static int battleSpeed;

    public static int BattleSpeed
    {
        get => battleSpeed;
        set
        {
            if (value >= 0 && value <= 255)
            {
                battleSpeed = value;
            }
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
    public static int SpeedValue { get; set; }

    public static float NormalSpeed { get; set; }

    public static void CalcGlobalSpeed()
    {
        SpeedValue = 32768 / (120 + battleSpeed * 15 / 8);
    }

    public static void CalcNormalSpeed(float partyDexAvg)
    {
        NormalSpeed = (int) Mathf.Ceil(partyDexAvg / 2) + 50;
    }
}