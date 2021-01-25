using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMStart : MonoBehaviour
{
    [SerializeField]
    private string BGMname;

    // Start is called before the first frame update
    void Start()
    {
        Sound.StopBgm();
        Sound.PlayBgm(BGMname);
    }

}
