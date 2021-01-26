using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCheck : MonoBehaviour
{
    [SerializeField]
    private GameObject Tarzan;

    private bool isEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd)
            return;
        if (Tarzan.transform.position.y < -1.7f)
            Water();
        
    }

    void Water()
    {
        Sound.PlaySe("water");
        StartCoroutine(GameOver());
    }

    public IEnumerator GameOver()
    {
        isEnd = true;
        Sound.StopBgm();
        yield return new WaitForSeconds(1.0f);
        Sound.PlayBgm("Result1");
        MySceneManager.SelectScene("Result");
    }
}
