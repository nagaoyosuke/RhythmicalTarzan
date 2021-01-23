using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pose : MonoBehaviour
{
    [SerializeField]
    private Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        //Save.GollMeter = 120;
        ScoreCheck();
    }

    void ScoreCheck()
    {
        var m = Save.GollMeter;
        string s = "";

        if (m < 100)
            s = "Bad";
        else if (100 <= m && m < 200)
            s = "Soso";
        else
            s = "Good";

        ani.SetBool(s, true);

        StartCoroutine(DelayClass.DelayCoroutin(1, () => ani.SetBool(s, false)));
    }
}
