using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStatsSO : ScriptableObject
{
    [SerializeField]
    private float life;
    [SerializeField]
    private float score;
    [SerializeField]
    private float atkSpeed;

    public float Life
    {
        get { return life; }
        set { life = value; }
    }
    public float Score
    {
        get { return score; }
        set { score = value; }
    }
    public float AtkSpeed
    {
        get { return atkSpeed; }
        set { atkSpeed = value; }
    }
}
