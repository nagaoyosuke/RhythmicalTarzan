using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲームの進行度やスコアの保存などのフラグ周りをここで管理する(02/20yosuke)
/// </summary>
public static class Save{

    /// <summary>
    ///02/20の時点で仮決めされてるのを書いたから変更されるかも(02/20yosuke)
    /// </summary>
    public enum MainGameFlag{
        /// <summary>
        /// ステージ名やズテージ全体を表示する
        /// </summary>
        STARTCAMERA,
        /// <summary>
        /// 最初に共通の短いカメラ演出
        /// </summary>
        STARTMOVE,
        /// <summary>
        /// タップで始まるのを待つ
        /// </summary>
        STARTWAIT,
        /// <summary>
        /// タップされてから投げられるまで
        /// </summary>
        THROWMOVE,
        /// <summary>
        /// 投げられてる時
        /// </summary>
        THROW,
        /// <summary>
        /// 落ちてからスローモーションになるまで
        /// </summary>
        FALLING,
        /// <summary>
        /// スローモーション開始
        /// </summary>
        SLOWSTART,
        /// <summary>
        /// 受け身入力開始
        /// </summary>
        UKEMI,
        /// <summary>
        /// 受け身成功失敗時のアニメーション開始
        /// </summary>
        UKEMIANIMETION,
        /// <summary>
        /// スローモーション終了
        /// </summary>
        SLOWEND,
        /// <summary>
        /// 受け身アニメーション終わったあとの演出開始
        /// </summary>
        UKEMIEFFECT,

        /// <summary>
        /// 追加受け身のスローモーション開始
        /// </summary>
        ADDSLOWSTART,
        /// <summary>
        /// 追加受け身成功失敗時のアニメーション開始
        /// </summary>
        ADDUKEMIANIMETION,
        /// <summary>
        /// 追加受け身入力開始
        /// </summary>
        ADDUKEMI,
        /// <summary>
        /// 追加受け身スローモーション終了
        /// </summary>
        ADDSLOWEND,
        /// <summary>
        /// 追加受け身アニメーション終わったあとの演出開始
        /// </summary>
        ADDUKEMIEFFECT,

        /// <summary>
        /// ２回目以降のカメラ演出開始
        /// </summary>
        MORECAMERA,
        /// <summary>
        /// スローモーション終了後の派生アニメーション開始
        /// </summary>
        ENDANIMETION,
        /// <summary>
        /// スローモーションから結果表示までの間
        /// </summary>
        ENDCAMERA,
        /// <summary>
        /// リザルト表示
        /// </summary>
        RESULT,
    };

    /// <summary>
    /// メインゲームの進行度
    /// </summary>
    public static MainGameFlag maingameFlag = MainGameFlag.STARTCAMERA;

    /// <summary>
    /// ハイスコア以外を初期化する。初めから遊ぶときに使う
    /// </summary>
    public static void ReSet(){
        
        FlagReSet();
    }

    /// <summary>
    /// メインゲームの初期化,ステージ変わった時とかに使う
    /// </summary>
    public static void FlagReSet(){
        
    }

    /// <summary>
    /// ２回目以降に投げられる前にリセットするときに使う
    /// </summary>
    public static void ThrowReSet()
    {
        
    }

    /// <summary>
    /// 追加受け身前にリセットするために使う
    /// </summary>
    public static void AddUkemiReSet()
    {
        
    }

    public static void PointReset()
    {
       
    }
}
