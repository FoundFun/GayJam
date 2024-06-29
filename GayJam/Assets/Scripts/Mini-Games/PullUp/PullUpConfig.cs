using UnityEngine;

[CreateAssetMenu(fileName = "PullUpConfig", menuName = "Scriptable Objects/PullUpConfig")]
public class PullUpConfig : ScriptableObject
{
    [field: SerializeField, Range (1, 100)] public float TimerDuration {  get; private set; }
}
