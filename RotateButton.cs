using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateButton : MonoBehaviour
{
    public Vector3 minRotationSpeed = new Vector3(0f, 0f, 1400f); // 最小回転速度
    public Vector3 maxRotationSpeed = new Vector3(0f, 0f, 1700f); // 最大回転速度
    public float minDecelerationRate = 0.996f; // 最小減速率
    public float maxDecelerationRate = 0.999f; // 最大減速率
    public float minRotationSpeedThreshold = 5f; // 回転を停止するための最小速度
    private Vector3 rotationSpeed; // 現在の回転速度を格納する変数
    private float decelerationRate; // 現在の減速率を格納する変数
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
            if (rotationSpeed.magnitude < minRotationSpeedThreshold)
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
            // z軸の初期回転速度をランダムに設定
            float randomZ = Random.Range(minRotationSpeed.z, maxRotationSpeed.z);
            rotationSpeed = new Vector3(0f, 0f, randomZ);

            // 減速率をランダムに設定
            decelerationRate = Random.Range(minDecelerationRate, maxDecelerationRate);

            isRotating = true; // 回転フラグをセット
        }
    }
}