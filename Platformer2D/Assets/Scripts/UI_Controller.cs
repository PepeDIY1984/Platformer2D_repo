using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UI_Controller : MonoBehaviour
{

    public GameObject panelOptions;

    public AudioSource sound;

    //UI MANAGEMENT
    public void showOptionsPanel() //Mostrar panel de opciones
    {
        Time.timeScale = 0;
        panelOptions.SetActive(true);
        sound.Play();
    }

    public void hideOptionsPanel() //Ocultar panel de opciones
    {
        Time.timeScale = 1;
        panelOptions.SetActive(false);
        sound.Play();
    }

    public void gotoStartScreen() //Ir a la pantalla inicial
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level_Start");
        sound.Play();
    }

    public void quitGame() //Salir del juego, solo funciona al montar el juego en un ejecutable
    {
        Application.Quit();
        sound.Play();
    }
}
