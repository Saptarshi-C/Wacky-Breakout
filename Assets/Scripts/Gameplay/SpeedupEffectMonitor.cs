using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupEffectMonitor : MonoBehaviour
{
    Timer speedupTimer;
    float speedupFactor;

    public bool SpeedupEffectActive
    {
        get { return speedupTimer.Running; }
    }

    public float SpeedupFactor
    {
        get { return speedupFactor; }
    }

    public float SpeedupTimeLeft
    {
        get { return speedupTimer.SecondsLeft; }
    }


    // Start is called before the first frame update
    void Start()
    {
        speedupTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedupEffectActivatedListener(SpeedupEffectActivatedHandler);
    }

    // Update is called once per frame
    void Update()
    {
        if(speedupTimer.Finished)
        {
            speedupTimer.Stop();
            speedupFactor = 1f;
        }
    }

    void SpeedupEffectActivatedHandler(float duration, float speedupFactor)
    {
        if(!speedupTimer.Running)
        {
            this.speedupFactor = speedupFactor;
            speedupTimer.Duration = duration;
            speedupTimer.Run();
        }
        else
        {
            speedupTimer.AddTime(duration);
        }
    }
}
