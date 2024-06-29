using UnityEngine;

[CreateAssetMenu(fileName = "RunningConfig", menuName = "Scriptable Objects/RunningConfig")]
public class RunningConfig : ScriptableObject
{
    [field: SerializeField, Range(1, 100)] public int GoodStuffPoints { get; private set; }
    [field: SerializeField, Range(1, 100)] public int BadStuffPoints { get; private set; }
    [field: SerializeField, Range(1, 100)] public float Speed { get; private set; }
    [field: SerializeField, Range(0, 1)] public float SpeedIncreaseRate { get; private set; }
    [field: SerializeField, Range(1, 100)] public float JumpForce { get; private set; }
    [field: SerializeField, Range(1, 100)] public int AmountOfSpawnItems { get; private set; }
    [field: SerializeField, Range(-100, 100)] public float SpawnHeight { get; private set; }
    [field: SerializeField, Range(1, 100)] public float MinDistanceBetweenSpawns { get; private set; }
    [field: SerializeField, Range(1, 100)] public float PauseAfterFinishing { get; private set; }

}
