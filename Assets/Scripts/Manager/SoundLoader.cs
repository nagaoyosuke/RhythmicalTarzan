using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//sound.csにse,bgmを読み込ませる
//seの場合はsound.loadse,bgmはsound.loadbgm
//se再生させるときはplayse("hogehogehoege")
//https://qiita.com/2dgames_jp/items/20360f9797c7e8b166bc

//読み込まれない時はファイル名を日本語から英語にしたらなおるときがある。

public class SoundLoader : MonoBehaviour {

	void Awake () {
        //20190228豊田
        //se3種類追加
        //20190818豊田　追加
        //https://soundeffect-lab.info/sound/anime/

        Sound.LoadSe("arayotto", "arayotto");
        Sound.LoadSe("norinori", "norinori");
        Sound.LoadSe("ahaha", "ahaha");
        Sound.LoadSe("cool", "cool");
        Sound.LoadSe("hoi", "hoi");

        Sound.LoadSe("water", "waterdrop_sound");
        Sound.LoadSe("button_push", "button_sound");
        Sound.LoadSe("tap", "tap_sound");


        Sound.LoadBgm("Play1", "game_music");
        Sound.LoadBgm("Play2", "Play2");

        Sound.LoadBgm("Result1", "titleandresult_music");
        Sound.LoadBgm("Result2", "Result2(Slow)");
        Sound.LoadBgm("Result3", "Result2(Fast)");
        Sound.LoadBgm("Result4", "Result3");


        //2020/01/05 長尾
        Sound.LoadSe("Hanabi", "Hanabi");   //かっしーの扉サウンド けいぶ
    }
}
