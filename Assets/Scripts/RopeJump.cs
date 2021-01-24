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


    public IEnumerator DownMove(Transform t)
    {

        status.ChangeAnimetion("Grap");

        var t_y = Tarzan.transform.position.y;
        var g_t = t.position.y;
        var y = t_y;
        var add = 0.1f;

        if (t_y >= g_t)
            add *= -1.0f;

        if(t.gameObject == null)
        {
            status.state = PlayerStatus.State.ROPE;
            yield break;
        }


        while (true)
        {
            Tarzan.transform.position += new Vector3(0, add, 0);
            t_y = Tarzan.transform.position.y;

            if (add < 0)
                if (t_y < g_t)
                    break;
            if (add > 0)
                if (t_y > g_t)
                    break;

            yield return new WaitForFixedUpdate();
        }

        status.state = PlayerStatus.State.ROPE;
        print("bbb");

    }

    void JumpStart()
    {
        status.state = PlayerStatus.State.JUMP;
        Tarzan.transform.parent = null;
        status.ChangeAnimetion("Jump");
        status.ChangeRBFreeze(RigidbodyConstraints.FreezeAll);
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

            Vector3 pos = Tarzan.transform.localPosition;

            var m = t / 2;
            float p = 5.0f * t * t / 20;
            var k = (-((z + m) * (z - m))) / p * hight;
            //移動量計算
            y = k - temp;
            temp = k;
            z += 1;


            pos.y += y;
            pos.z += wight / t;

            Tarzan.transform.localPosition = pos;

        }
    }    
}
