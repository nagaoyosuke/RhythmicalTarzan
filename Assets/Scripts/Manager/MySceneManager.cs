using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : SingletonMonoBehaviour<MySceneManager> {

	public enum Scenes
    {
        Title,
        Main,
        Result
    }

	public static void GoTitle(){
		SceneManager.LoadScene("Title");
	}

    public static void GoMain()
    {
        //SceneManager.LoadScene("Main");
        SceneManager.LoadScene("CameraMove1");
    }

	public static void GoResult(){
		SceneManager.LoadScene("Result");
	}

    public static void SelectScene(string scene_name)
    {
        switch (scene_name)
        {
            case "Title":
                GoTitle();
                break;
            case "Main":
                GoMain();
                break;
            case "Result":
                GoResult();
                break;
            default:
                print(scene_name + "シーンはないよ");
                break;
        }
    }
}
