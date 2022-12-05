using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils
{
    public static bool SpeedupEffectActive
    {
        get { return GetSpeedupEffectMonitor().SpeedupEffectActive; }
    }

    public static float SpeedupFactor
    {
        get { return GetSpeedupEffectMonitor().SpeedupFactor; }
    }

    public static float SpeedupTimeLeft
    {
        get { return GetSpeedupEffectMonitor().SpeedupTimeLeft; }
    }

    static SpeedupEffectMonitor GetSpeedupEffectMonitor()
    {
        return Camera.main.GetComponent<SpeedupEffectMonitor>();
    }
}
