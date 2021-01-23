using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMover : MonoBehaviour
{
    
    public void GoSelectScenes(string scene_name)
    {
        MySceneManager.SelectScene(scene_name);
    }
}
