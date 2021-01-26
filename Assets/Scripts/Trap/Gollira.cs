using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gollira : MonoBehaviour
{
    [SerializeField]
    private Animator ani;

    [SerializeField]
    private AnimationFlag aniFlag;

    [SerializeField]
    private GameObject YashiPre;

    [SerializeField]
    private Transform YashiRespone;

    [SerializeField]
    private FixedJoint HandJoint;

    [SerializeField]
    private int startFrame;

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

    //private int grapFrame = 60;
    //private int throwFrame = 82;

    private bool isThrowing = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayClass.DelayCoroutin(startFrame, () => isThrowing = false));
    }

    // Update is called once per frame
    void Update()
    {
        if (isThrowing)
            return;

        ThrowStart();
    }

    void ThrowStart()
    {
        isThrowing = true;
        StartCoroutine(Throw());
    }

    IEnumerator Throw()
    {
        ani.SetBool("Throw", true);
        yield return new WaitForFixedUpdate();
        ani.SetBool("Throw", false);

        yield return new WaitUntil(() => aniFlag.isFlag1);

        var yashi = Instantiate(YashiPre);
        yashi.transform.position = YashiRespone.position;
        yashi.transform.eulerAngles = YashiRespone.eulerAngles;

        HandJoint.connectedBody = yashi.GetComponentInChildren<Rigidbody>();

        yield return new WaitUntil(() => aniFlag.isFlag2);

        HandJoint.connectedBody = null;

        StartCoroutine(FlyingYashi(yashi));

        yield return new WaitForSeconds(3.0f);
        isThrowing = false;

    }

    IEnumerator FlyingYashi(GameObject yashi)
    {
        var y = 0.0f;
        var x = -(t / 2);

        var temp = 0.0f;
        var startMeter = (float)Save.GollMeter;

        x += 1;

        var time = 0;

        while (true)
        {
            yield return new WaitForFixedUpdate();

            time++;
            if (time > 200)
            {
              break;
            }

            Vector3 pos = yashi.transform.localPosition;

            var m = t / 2;
            float p = 5.0f * t * t / 20;
            var k = (-((x + m) * (x - m))) / p * hight;
            //移動量計算
            y = k - temp;
            temp = k;
            x += 1;


            pos.y += y;
            pos.x += wight / t;

            yashi.transform.localPosition = pos;

        }

        Destroy(yashi);
    } 


}
