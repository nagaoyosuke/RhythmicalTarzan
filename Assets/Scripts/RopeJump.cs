using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeJump : MonoBehaviour
{
    [SerializeField]
    private GameObject Tarzan;

    private bool isJump = false;

    /// <summary>
    /// ジャンプにかける時間(Frame)
    /// </summary>
    [SerializeField]
    private int t = 60;
    /// <summary>
    /// 最大の高さ
    /// </summary>
    [SerializeField]
    private float hight = 3.0f;
    /// <summary>
    /// 移動動先までの距離
    /// </summary>
    [SerializeField]
    private float wight = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isJump)
            return;

        if (Input.GetKeyDown("space"))
        {
            JumpStart();
        }
    }

    /// <summary>
    /// 120:18
    /// 60:9
    /// 20:3
    void JumpStart()
    {
        isJump = true;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        var y = 0.0f;
        var z = -(t / 2);

       

        var temp = 0.0f;

        z += 1;

        for (int i = 0; i < t; i++)
        {
            yield return new WaitForFixedUpdate();

            Vector3 pos = Tarzan.transform.position;

            var m = t / 2;
            float p = 5.0f * t * t / 20;
            var k = (-((z + m) * (z - m))) / p * hight;
            //移動量計算
            y = k - temp;
            temp = k;
            z += 1;


            pos.y += y;
            pos.z += wight / t;
           
            Tarzan.transform.position = pos;
            print(pos.y -0.96f);

        }

        isJump = false;

    }
}
