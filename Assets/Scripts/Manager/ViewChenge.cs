using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// あるフラグの時だけ表示したいものを管理するクラス
/// </summary>
public class ViewChenge : MonoBehaviour
{
    [SerializeField]
    private MonoBehaviour[] components;

    [SerializeField]
    private Save.MainGameFlag ViewFlag;

    [SerializeField]
    private Save.MainGameFlag HideFlag;

    private bool isChenge;
    
    // Start is called before the first frame update
    void Awake()
    {
        if(ViewFlag != Save.maingameFlag)
        {
            Chenge(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!isChenge)
        {
            if (ViewFlag == Save.maingameFlag)
            {
                Chenge(true);
            }
        }
        if (isChenge)
        {
            if (HideFlag == Save.maingameFlag)
            {
                Chenge(false);
            }
        }
    }

    void Chenge(bool value)
    {
        isChenge = value;

        foreach (MonoBehaviour mono in components)
        {
            mono.enabled = value;
        }
    }
}
