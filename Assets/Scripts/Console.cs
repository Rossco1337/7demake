using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using IngameDebugConsole;
using UnityEngine;
public static class Console {
    public static void AddCommands () {
        DebugLogConsole.AddCommand<int> ("bs", "Sets battle speed, lower is faster (0-255)", BattleSpeedCommand);
        DebugLogConsole.AddCommand ("pbs", "Print current Battle Speed", PrintBattleSpeedCommand);
        DebugLogConsole.AddCommand ("gs", "Print current Global Speed", GlobalSpeedCommand);
        DebugLogConsole.AddCommand ("ns", "Print current Normal Speed", NormalSpeedCommand);
    }

    private static void BattleSpeedCommand (int newBattleSpeed) {
        Debug.Log ($"Battle Speed is { GlobalTimer.BattleSpeed }, setting to { newBattleSpeed }");
        GlobalTimer.BattleSpeed = newBattleSpeed;
        GlobalTimer.CalcGlobalSpeed ();

    }

    private static void PrintBattleSpeedCommand () {
        Debug.Log ($"Battle Speed: { GlobalTimer.BattleSpeed } ");
    }

    private static void GlobalSpeedCommand () {
        Debug.Log ($"Global Speed: { GlobalTimer.SpeedValue } ");
    }

    private static void NormalSpeedCommand () {
        Debug.Log ($"Normal Speed: { GlobalTimer.NormalSpeed } ");
    }
}