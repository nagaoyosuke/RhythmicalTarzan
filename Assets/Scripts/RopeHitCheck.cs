using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeHitCheck : MonoBehaviour
{
    [SerializeField]
    private GameObject Tarzan;
    [SerializeField]
    private PlayerStatus status;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private FixedJoint fixedJoint;
    [SerializeField]
    private RopeJump ropeJump;
    [SerializeField]
    private TuruShaker turuShaker;

    private Queue<GameObject> LastRope = new Queue<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Rope")
            return;
        if (status.state != PlayerStatus.State.JUMP)
            return;

        status.state = PlayerStatus.State.GRAP;

        Tarzan.transform.localEulerAngles = Vector3.zero;
        status.ChangeRBFreeze(RigidbodyConstraints.None);
        status.ChangeRBFreeze(RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ);

        if (turuShaker == null)
        {
            print("turumanager is null");
            turuShaker = GameObject.FindWithTag("Manager").GetComponent<TuruShaker>();
        }

        var p = other.GetComponentInParent<ParentCheck>().gameObject;


        LastRope.Enqueue(p);
        //hingeJoint.connectedBody = other.GetComponent<Rigidbody>();
        //fixedJoint.connectedBody = other.GetComponent<Rigidbody>();
        fixedJoint = other.GetComponent<FixedJoint>();
        fixedJoint.connectedBody = rb;
        //Tarzan.transform.parent = other.transform;
        var t = p.GetComponentInChildren<Mannaka>().gameObject;
        SetLastRope(p, "DontRope");
        StartCoroutine(RopeWait(t));
    }

    void SetLastRope(GameObject Rope, string tag_neme)
    {

        if (Rope == null)
            Rope = LastRope.Dequeue();

        foreach(SphereCollider g in Rope.GetComponentsInChildren<SphereCollider>())
        {
            g.gameObject.tag = tag_neme;
        }
    }

    IEnumerator RopeWait(GameObject p)
    {
        yield return new WaitForFixedUpdate();
        var f = fixedJoint.transform.parent.GetComponent<Rigidbody>();
        if (f == null)
            fixedJoint.connectedBody = null;
        else
            fixedJoint.connectedBody = f;

        yield return StartCoroutine(ropeJump.DownMove(p.GetComponentInChildren<Mannaka>().transform));
        fixedJoint = p.GetComponent<FixedJoint>();
        fixedJoint.connectedBody = rb;
        turuShaker.ChangeTarget(p.GetComponentInChildren<Sakittyo>().gameObject);

        yield return new WaitUntil(() => status.state == PlayerStatus.State.JUMP);
        //hingeJoint.connectedBody = null;
        f = fixedJoint.transform.parent.GetComponent<Rigidbody>();
        if (f == null)
            fixedJoint.connectedBody = null;
        else
            fixedJoint.connectedBody = f;

        yield return new WaitUntil(() => status.state == PlayerStatus.State.ROPE);
        SetLastRope(null, "Rope");
    }
}
