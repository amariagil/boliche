using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/level1"); // Troque pelo nome da sua cena principal
    }

 
    public void QuitGame()
    {
        Debug.Log("Saindo do jogo!");
        Application.Quit();
    }
}
