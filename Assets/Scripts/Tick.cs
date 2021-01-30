using UnityEngine;

public class Tick
{
    private const float TICK_TIME = 1 / 15f;
    public int tickCount;
    private float tickTimer;

    public void StartTicking()
    {
        tickTimer += Time.deltaTime;
        if (tickTimer >= TICK_TIME)
        {
            //tick!
            tickTimer -= TICK_TIME;
            tickCount++;
        }
    }
}