using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Text ScoreText;

    [SerializeField]
    private bool isStartChange;

    private Selectable<int> selectable = new Selectable<int>();

    // Start is called before the first frame update
    void Start()
    {
        selectable.mChanged += s =>
        {
            TextChange();
        };
        selectable.SetValueWithoutCallback(Save.GollMeter);
        if (isStartChange)
            TextChange();
    }

    void Update()
    {
        selectable.SetValueIfNotEqual(Save.GollMeter);

    }

    public void TextChange()
    {
        ScoreText.text = Save.GollMeter.ToString() + "m";
    }
}
