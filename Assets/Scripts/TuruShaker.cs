using System.Collections;
using System.Collections.Generic;
using StateManager;
using UnityEngine;

/// <summary>
/// つるを揺らす
/// </summary>
public class TuruShaker : MonoBehaviour
{
    [SerializeField]
    a _touch_manager;
    private float _screenWidth = 0;
    private float _screenHeight = 0;

    //ゲーム画面の中心
    private Vector2 _screenCenterPosition;

    public GameObject sphire10;
    private Rigidbody _rigid;

    private float _shakePower = 0.1f;

    // 初期化
    private void Start()
    {
        //this._touch_manager = new a();

        _screenWidth = Screen.width;
        _screenHeight = Screen.height;
        _screenCenterPosition = new Vector2(_screenWidth / 2, _screenHeight / 2);

        _rigid = sphire10.GetComponent<Rigidbody>();
    }

    // 更新
    private void Update()
    {
        this._touch_manager.update();
        
        if (this._touch_manager._touch_flag)
        {
            var v = _rigid.velocity;
            //画面右半分がタップされた場合右に揺らす
            if (this._touch_manager._touch_position.x >= _screenCenterPosition.x)
            {
                //_rigid.AddForce(new Vector3(0, 0, _shakePower));
                _rigid.velocity += new Vector3(0, 0, _shakePower);
            }
            else
            {
                //_rigid.AddForce(new Vector3(0, 0, -_shakePower));
                _rigid.velocity += new Vector3(0, 0, -_shakePower);
            }
        }
    }
}