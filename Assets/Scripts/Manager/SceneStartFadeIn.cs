using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//各scene内のCanvasのPanelにアタッチするスクリプト
//読み込まれるとScreenFaderのisFadeinをTrueにする。
//そしてPanelのImageは真っ黒で画面を覆い尽くすから邪魔なのでデフォルトでenabledをfalseにしてあるから
//それをtrueにしてる

public class SceneStartFadeIn : MonoBehaviour {

	public bool isWait;

	void Awake () {
		if (isWait) {
			return;
		}

		this.gameObject.GetComponent<ScreenFader> ().isFadeIn = true;
		this.gameObject.GetComponent<Image> ().enabled = true;
	}

	IEnumerator Wait(){

		yield return new WaitForSeconds(2f/60f);
		this.gameObject.GetComponent<ScreenFader> ().isFadeIn = true;
		this.gameObject.GetComponent<Image> ().enabled = true;
	}
}
