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
    [SerializeField]
    private int startWaves;
    [SerializeField]
    private int startEnemy;

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
    public int StartWaves
    {
        get { return startWaves; }
        set { startWaves = value; }
    }
    public int StartEnemy
    {
        get { return startEnemy; }
        set { startEnemy = value; }
    }
}
