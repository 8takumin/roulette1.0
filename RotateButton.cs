using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateButton: MonoBehaviour
{
    public Vector3 initialRotationSpeed = new Vector3(0f, 0f, 1500f); // 初期回転速度
    public float decelerationRate = 0.994f; // 減速率（1未満の値）
    public float minRotationSpeed = 5f; // 回転を停止するための最小速度
    private Vector3 rotationSpeed; // 現在の回転速度を格納する変数
    private bool isRotating = false; // 回転中かどうかのフラグ

    void Start()
    {
        rotationSpeed = Vector3.zero; // 初期状態では回転速度をゼロに設定
    }

    void Update()
    {
        if (isRotating)
        {
            // オブジェクトを回転させる
            transform.Rotate(rotationSpeed * Time.deltaTime);

            // 徐々に回転速度を減少させる
            rotationSpeed *= decelerationRate;

            // 回転速度が一定値以下になったら停止する
            if (rotationSpeed.magnitude < minRotationSpeed)
            {
                rotationSpeed = Vector3.zero; // 回転を停止
                isRotating = false; // 回転フラグを解除
            }
        }
    }

    // スタートボタンを押したときに呼び出すメソッド
    public void StartRotation()
    {
        if (!isRotating)
        {
            rotationSpeed = initialRotationSpeed; // 初期回転速度を設定
            isRotating = true; // 回転フラグをセット
        }
    }
}