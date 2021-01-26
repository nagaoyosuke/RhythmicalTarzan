using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public enum State
    {
        JUMP,
        GRAP,
        ROPE,
        EVENT
    }

    public State state = State.ROPE;

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Animator ani;
    [SerializeField]
    private GameOverCheck gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeRBFreeze(RigidbodyConstraints constraints)
    {
        rb.constraints = constraints;
    }

    public void ChangeAnimetion(string key)
    {
        ani.SetBool(key,true);
        StartCoroutine(DelayClass.DelayCoroutin(1,() => ani.SetBool(key, false)));
    }
}
