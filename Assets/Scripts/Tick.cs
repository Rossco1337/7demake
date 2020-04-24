using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tick {
    private const float TICK_TIME = 1 / 15f;
    private float tickTimer;
    public int tickCount;

    public void StartTicking () {
        tickTimer += Time.deltaTime;
        if (tickTimer >= TICK_TIME) { //tick!
            tickTimer -= TICK_TIME;
            tickCount++;
        }
    }

}