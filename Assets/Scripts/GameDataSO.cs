using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObject/GameData", order = 0)]
public class GameDataSO : ScriptableObject
{
    [Header("Acceleration Forces")]
    [SerializeField] private float gravity;
    [SerializeField] Vector3 acceleration= Vector3.zero;

    public float _gravity => gravity;
    public Vector3 Acceleration => acceleration;
}
