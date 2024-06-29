using Mini_Games.PullUp;
using Player;
using TMPro;
using UnityEngine;

namespace Mini_Games.BenchPress
{
    public class BenchPress : MonoBehaviour
    {
        [SerializeField] private TMP_Text _pointText;
        [SerializeField] private TMP_Text _approach;
        [SerializeField] private PullUpConfig _config;
        [SerializeField] private PlayerMover _playerMover;
    }
}