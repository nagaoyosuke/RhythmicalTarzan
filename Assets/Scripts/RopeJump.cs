using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeJump : MonoBehaviour
{
    [SerializeField]
    private GameObject Tarzan;
    [SerializeField]
    private PlayerStatus status;

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
        if (status.state != PlayerStatus.State.ROPE)
            return;

        if (Input.GetKeyDown("space"))
        {
            JumpStart();
        }

        if (Input.GetKeyDown("p"))
        {
            wight *= -1;
        }
    }

    /// <summary>
    /// 120:18
    /// 60:9
    /// 20:3
    void JumpStart()
    {
        status.state = PlayerStatus.State.JUMP;
        Tarzan.transform.parent = null;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        var y = 0.0f;
        var z = -(t / 2);

        var temp = 0.0f;

        z += 1;

        while (true)
        {
            yield return new WaitForFixedUpdate();

            if (status.state != PlayerStatus.State.JUMP)
            {
                yield break;
            }

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

        }
    }    
}
