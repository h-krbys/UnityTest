using System.Collections.Generic;
using UnityEngine;

public class DataPoint
{
    public float time;
    public float x;
    public float y;
    public float z;
    public float c;
}

public class CSVReader : MonoBehaviour
{
    public List<DataPoint> dataPoints = new List<DataPoint>();

    void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            // スクリプト内にデータを直接定義
            dataPoints.Add(new DataPoint { time = 0, x = 0, y = 0, z = 0, c = -0.002f });
            dataPoints.Add(new DataPoint { time = 3, x = 0.1484f, y = 0.1732f, z = 0, c = -0.002f });
            dataPoints.Add(new DataPoint { time = 6, x = 0.1484f, y = 0.1732f, z = 0.1568f, c = -0.002f });
            dataPoints.Add(new DataPoint { time = 9, x = 0.1484f, y = 0.1732f, z = 0.1568f, c = 0.004f });
            dataPoints.Add(new DataPoint { time = 12, x = 0.1484f, y = 0.1732f, z = 0, c = 0.004f });
            dataPoints.Add(new DataPoint { time = 15, x = 0, y = 0, z = 0, c = 0.004f });
            dataPoints.Add(new DataPoint { time = 18, x = 0, y = 0, z = 0, c = -0.0002f });
        }
    }
}
