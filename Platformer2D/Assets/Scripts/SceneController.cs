using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject levelTransition;
    public GameObject fruitsCollection;
    public static int fruitsCollected;

    public TextMeshProUGUI textFruitsTotal;     //Variable de texto en la UI
    public TextMeshProUGUI textFruitsCollected; //Variable de texto en la UI

    public AudioSource buttonSound;

    private void Start()
    {
        fruitsCollected = 0;
        textFruitsTotal.text = fruitsCollection.gameObject.transform.childCount.ToString();
    }

    //FRUITS MANAGEMENT
    public void checkFruitsRemaining()  //Comprobar cuantas frutas se han recogido
    {
        Debug.Log("Has recogido" + fruitsCollected + " frutas");
        textFruitsCollected.text = fruitsCollected.ToString(); 
        if (int.Parse(textFruitsTotal.text) == fruitsCollected)
        {
            Debug.Log("Has recogido todas las frutas!");
            levelTransition.SetActive(true);
            Invoke("changeScene", 1);
        }
    }

    void changeScene()
    {
        if (SceneManager.GetActiveScene().buildIndex==3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    //UI MANAGEMENT
 
    public void startGame() //Comenzar el juego
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level001");
        if (buttonSound)
        {
            buttonSound.Play();
        }
    }

    public void quitGame() //Salir del juego, solo funciona al montar el juego en un ejecutable
    {
        if (buttonSound)
        {
            buttonSound.Play();
        }
        Application.Quit();
    }

    public void CambiarVolumen(float volumen)
    {
        AudioListener.volume = volumen;
    }
}



