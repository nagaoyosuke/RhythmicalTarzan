using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonChenge : MonoBehaviour
{
    [SerializeField]
    private Image NowImage;

    [SerializeField]
    private Sprite ChengeImage;

    public void Click()
    {
        var ima = NowImage.sprite;
        NowImage.sprite = ChengeImage;

        StartCoroutine(DelayClass.DelayCoroutin(10, () => NowImage.sprite = ima));

    }
}
