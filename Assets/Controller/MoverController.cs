using UnityEngine;
using UnityEngine.Animations;

public enum Direction { Positive, Negative }

public class MoverController : MonoBehaviour
{
    public CSVReader csvReader;          // CSVデータを持つスクリプト
    public float transitionTime = 1.0f;  // 移動にかかる時間（秒）

    public enum Axis { X, Y, Z, C }       // 移動方向を選択する列
    public Axis referenceAxis = Axis.X;  // 参照する座標の列
    public Direction moveDirection = Direction.Positive; // 移動方向（正・負）

    private int currentIndex = 0;        // 現在のインデックス
    private float elapsedTime = 0f;      // 経過時間

    void Update()
    {
        if (currentIndex < csvReader.dataPoints.Count - 1)
        {
            elapsedTime += Time.deltaTime;

            DataPoint currentPoint = csvReader.dataPoints[currentIndex];
            DataPoint nextPoint = csvReader.dataPoints[currentIndex + 1];

            // 現在の時間に基づいて補間の進行度を計算
            float t = elapsedTime / transitionTime;

            // 補間
            Vector3 startPosition = GetVector3(currentPoint);
            Vector3 endPosition = GetVector3(nextPoint);
            transform.position = transform.parent.position + Vector3.Lerp(startPosition, endPosition, t);

            // 移動時間が経過したら次のポイントへ
            if (elapsedTime >= transitionTime)
            {
                currentIndex++;
                elapsedTime = 0f; // 経過時間をリセット
            }
        }
    }

    // 参照する列に基づいてVector3を取得するメソッド
    private Vector3 GetVector3(DataPoint point)
    {
        Vector3 result = Vector3.zero;

        switch (referenceAxis)
        {
            case Axis.X:
                result = new Vector3(0, 0, point.x); // Y, Zは0に設定
                break;
            case Axis.Y:
                result = new Vector3(point.y, 0, 0); // X, Zは0に設定
                break;
            case Axis.Z:
                result = new Vector3(0, point.z, 0); // X, Yは0に設定
                break;
            case Axis.C:
                result = new Vector3(point.c, 0, 0); // 例として、Cはtを参照
                break;
        }

        // 移動方向を考慮
        if (moveDirection == Direction.Negative)
        {
            result = new Vector3(-result.x, -result.y, -result.z);
        }

        return result;
    }
}
