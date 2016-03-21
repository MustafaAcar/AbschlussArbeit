using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameStates currentGameState { get; private set; } 

    public enum GameStates
    {
        Dead,
        Running,
        Pause      
    }

    void Awake()
    {
       // Singelton
       if(instance == null)
        {
            instance = this;
        }
       else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

   
    // Update is called once per frame
    void Update()
    {
        switch (currentGameState)
        {
            case GameStates.Dead: // State of Death
                // to do
            break;

            case GameStates.Running: // State of Running
                // to do
            break;

            case GameStates.Pause: // State of Pause
                // to do
            break;

        }
    }

    public void Die() // Changes the Gamestate to Dead
    {
        if(currentGameState != GameStates.Dead)
        {
            currentGameState = GameStates.Dead;
        }
    }

    public void Restart() // Reloading of current Scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   

}
