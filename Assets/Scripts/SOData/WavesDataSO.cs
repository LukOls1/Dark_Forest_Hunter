using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WavesDataSO : ScriptableObject
{
    [SerializeField]
    private int wavesNumber;
    [SerializeField]
    private int enemyNumber;

    public int WavesNumber
    {
        get { return wavesNumber; }
        set { wavesNumber = value; }
    }
    public int EnemyNumber
    {
        get { return enemyNumber; }
        set { enemyNumber = value; }
    }
}
