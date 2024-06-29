using UnityEngine;

namespace Mini_Games.PullUp
{
    [CreateAssetMenu(fileName = "PullUpConfig", menuName = "Scriptable Objects/PullUpConfig")]
    public class PullUpConfig : ScriptableObject
    {
        [field: SerializeField] public float TimerDurationDay1 { get; private set; } = 10;
        [field: SerializeField] public float TimerDurationDay2 { get; private set; } = 12;
        [field: SerializeField] public float TimerDurationDay3 { get; private set; } = 14;
        [field: SerializeField] public float TimerDurationDay4 { get; private set; } = 16;
        [field: SerializeField] public float TimerDurationDay5 { get; private set; } = 18;
        [field: SerializeField] public float TimerDurationDay6 { get; private set; } = 20;
        [field: SerializeField] public float TimerDurationDay7 { get; private set; } = 25;
    }
}
