using UnityEngine;

namespace Mini_Games.BenchPress
{
    public class BarType : MonoBehaviour
    {
        [field: SerializeField] public int Score { get; private set; } = 10;
    }
}