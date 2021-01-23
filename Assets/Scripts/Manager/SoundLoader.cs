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

        Sound.LoadSe("taiko01", "drum-japanese1");
        Sound.LoadSe("taiko02", "drum-japanese2");
        Sound.LoadSe("osu01", "mens-ou1");
        Sound.LoadSe("dora01", "dora01");
        Sound.LoadSe("dora02", "solemnity1");
        Sound.LoadSe("syakin", "ukemi_effect_sound01");
        Sound.LoadSe("bakuhatu", "bomb");
        Sound.LoadSe("keikoku01", "hyoushigi2");
        Sound.LoadSe("keikoku02", "tsukkomi-1");

        Sound.LoadSe("text-impact01", "text-impact1");
        Sound.LoadSe("tori01", "milvus-migrans-cry1");

        Sound.LoadSe("computer01", "recollection1");
        Sound.LoadSe("computer02", "data-analysis2");
        Sound.LoadSe("computer03", "data-analysis1");
        Sound.LoadSe("alien01", "alien1");

        Sound.LoadSe("hero01", "hero1");
        Sound.LoadSe("beshi", "feed1");
        Sound.LoadSe("ufo", "madness1");

        Sound.LoadSe("sceneswitch02", "sceneswitch2");

        Sound.LoadSe("yeah01","mens-yeah1");
        Sound.LoadSe("itawari01", "kick-middle1");
        Sound.LoadSe("cheer01", "cheer01");
        Sound.LoadSe("shutter", "shuttersound");

        Sound.LoadSe("walk01", "walk-asphalt2");
        Sound.LoadSe("dash01", "dash-asphalt2");

        Sound.LoadSe("walk02", "walk3s");
        Sound.LoadSe("dash02", "dash3s");


        //http://notanomori.net/sound/search/江戸っ子/
        //20190616
        //credit : Nota no Mori 
        Sound.LoadSe("wasshoi", "minoru_voice01");
        Sound.LoadSe("soiya", "minoru_voice02");
        Sound.LoadSe("seiya", "minoru_voice03");
        Sound.LoadSe("yo", "minoru_voice04");
        Sound.LoadSe("hoi", "minoru_voice05");
        Sound.LoadSe("hun", "minoru_voice06");


        Sound.LoadSe("ukemi01", "ukemi01");
        Sound.LoadSe("waterdive", "splash-big");
        Sound.LoadSe("suzume", "passer-montanus-cry1");

        //20190810
        //https://on-jin.com/kiyaku.php
        Sound.LoadSe("asioto01", "footsteps01");
        Sound.LoadSe("asioto02", "footsteps02");
        Sound.LoadSe("asioto03", "footsteps03");



        Sound.LoadBgm("Play1", "Play1");
        Sound.LoadBgm("Play2", "Play2");

        Sound.LoadBgm("Result1", "Result1");
        Sound.LoadBgm("Result2", "Result2(Slow)");
        Sound.LoadBgm("Result3", "Result2(Fast)");
        Sound.LoadBgm("Result4", "Result3");


        //2020/01/05 長尾
        Sound.LoadSe("Hanabi", "Hanabi");   //かっしーの扉サウンド けいぶ
    }
}
