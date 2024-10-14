using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneViewLikeCameraControl : MonoBehaviour
{
    public float rotateSpeed = 1.0f; // 右クリックでの回転速度
    public float panSpeed = 0.5f;    // ホイール押し込みでの平行移動速度
    public float zoomSpeed = 10.0f;  // ホイールスクロールでのズーム速度

    private Vector3 lastMousePos;    // マウスの最後の位置を記録

    void Update()
    {
        // 右クリックを押しながらのカメラ回転
        if (Input.GetMouseButton(1)) // 右クリック
        {
            RotateCamera();
        }

        // ホイール押し込みによる平行移動
        if (Input.GetMouseButton(2)) // マウスホイール押し込み
        {
            PanCamera();
        }

        // マウスホイールでズームイン・ズームアウト
        ZoomCamera();
    }

    // カメラの回転
    void RotateCamera()
    {
        // 現在のマウス位置を取得
        Vector3 mouseDelta = Input.mousePosition - lastMousePos;
        float rotationX = mouseDelta.x * rotateSpeed;
        float rotationY = mouseDelta.y * rotateSpeed;

        // カメラの水平回転と垂直回転を適用
        transform.Rotate(Vector3.up, rotationX, Space.World);
        transform.Rotate(Vector3.right, -rotationY, Space.Self);

        // マウス位置を更新
        lastMousePos = Input.mousePosition;
    }

    // カメラの平行移動
    void PanCamera()
    {
        // 現在のマウス位置を取得
        Vector3 mouseDelta = Input.mousePosition - lastMousePos;

        // カメラの右方向と上方向に沿って平行移動
        Vector3 move = transform.right * -mouseDelta.x * panSpeed + transform.up * -mouseDelta.y * panSpeed;
        transform.Translate(move, Space.World);

        // マウス位置を更新
        lastMousePos = Input.mousePosition;
    }

    // カメラのズーム
    void ZoomCamera()
    {
        // マウスホイールの入力を取得
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // カメラの前後移動でズームを実現
        transform.Translate(Vector3.forward * scroll * zoomSpeed, Space.Self);
    }

    // マウス位置の初期化
    void LateUpdate()
    {
        // 毎フレーム最後にマウス位置を更新
        lastMousePos = Input.mousePosition;
    }
}

