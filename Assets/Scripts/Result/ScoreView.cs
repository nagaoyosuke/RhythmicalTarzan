using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Text ScoreText;

    [SerializeField]
    private bool isStartChange;

    // Start is called before the first frame update
    void Start()
    {
        if (isStartChange)
            TextChange();
    }

    public void TextChange()
    {
        ScoreText.text = Save.GollMeter.ToString() + "m";
    }
}
