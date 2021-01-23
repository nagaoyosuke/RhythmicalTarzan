using System.Collections;
using UnityEngine;

public sealed class WaitForSecondsRealtime : CustomYieldInstruction
{
    private float waitTime;

    public override bool keepWaiting
    {
        get { return Time.realtimeSinceStartup < waitTime; }
    }

    public WaitForSecondsRealtime(float time)
    {
        waitTime = Time.realtimeSinceStartup + time;
    }
}