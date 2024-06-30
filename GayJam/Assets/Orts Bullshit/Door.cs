using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int gymIndex = 1;

    public void Enter()
    {
        SceneManager.LoadScene(gymIndex);
    }
}
