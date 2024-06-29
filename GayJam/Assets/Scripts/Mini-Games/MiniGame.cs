using UnityEngine;

namespace Mini_Games
{
    public class MiniGame : MonoBehaviour
    {
        [SerializeField] private GameObject _miniGame;

        public void StartMiniGame()
        {
            _miniGame.gameObject.SetActive(true);
        }
    }
}