using System;
/// <summary>
/// 選択中の値を管理するクラス
/// </summary>
public class Selectable<T>
{
	private T mValue;   // 選択中の値
	/// <summary>
	/// <para>値を取得または設定します</para>
	/// <para>値の設定後に mChanged イベントが呼び出されます</para>
	/// </summary>
	public T Value
	{
		get { return mValue; }
		set
		{
			mValue = value;
			OnChanged( mValue );
		}
	}
	/// <summary>
	/// 値が変更された時に呼び出されます
	/// </summary>
	#pragma warning disable 0067
	public Action<T> mChanged;
	#pragma warning restore 0067
	/// <summary>
	/// コンストラクタ
	/// </summary>
	public Selectable()
	{
		mValue = default( T );
	}
	/// <summary>
	/// コンストラクタ
	/// </summary>
	public Selectable( T value )
	{
		mValue = value;
	}
	/// <summary>
	/// <para>値を設定します</para>
	/// <para>値の設定後に mChanged イベントは呼び出されません</para>
	/// </summary>
	public void SetValueWithoutCallback( T value )
	{
		mValue = value;
	}
	/// <summary>
	/// <para>値を設定します</para>
	/// <para>値が変更された場合にのみ mChanged イベントが呼び出されます</para>
	/// </summary>
	public void SetValueIfNotEqual( T value )
	{
		if ( mValue.Equals( value ) )
		{
			return;
		}
		mValue = value;
		OnChanged( mValue );
	}
	/// <summary>
	/// 値が変更された時に呼び出されます
	/// </summary>
	private void OnChanged( T value )
	{
		var onChanged = mChanged;
		if ( onChanged == null )
		{
			return;
		}
		onChanged( value );
	}
}
