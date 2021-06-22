using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void EnterDifficultySelection()
    {
        SceneManager.LoadScene("GameMode");
    }
}
