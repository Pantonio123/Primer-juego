using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void Empezar(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );


    }
    public void SalirDelJuego(){

        Application.Quit();

    }
}
