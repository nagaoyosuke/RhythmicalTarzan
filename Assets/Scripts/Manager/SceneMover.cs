using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMover : MonoBehaviour
{
    
    public void GoSelectScenes(string scene_name)
    {
        MySceneManager.SelectScene(scene_name);
    }

    public void PlaySelectSE(string se_name)
    {
        Sound.PlaySe(se_name,1);
    }

    public void PlaySelectBGM(string bgm_name)
    {
        Sound.PlayBgm(bgm_name);
    }

    public void ResetScore()
    {
        Save.ReSet();
    }
}
