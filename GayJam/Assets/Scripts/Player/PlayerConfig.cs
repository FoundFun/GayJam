using UnityEngine;

namespace Player.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfigs", menuName = "Player/PlayerConfigs", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; } = 5;
        [field: SerializeField] public float RadiusSelect { get; private set; } = 1;
    }
}