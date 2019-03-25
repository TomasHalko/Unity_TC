using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameHandler : MonoBehaviour
{   
    // Unity Hooks
    private coilStats C;
    private upgradeSystem uS;
    private proceduralSpawning pS;

    // Game Handling Variables
    private bool gameHasEnded = false;
    private float restartDelay = 2f;
    public int numberOfEnemies = 0;
    public int enemiesKilled = 0;
    public bool waveFinished;

    // Start is called before the-first frame update
    void Start() {
        C = FindObjectOfType<coilStats>();
        pS = FindObjectOfType<proceduralSpawning>();
        uS = FindObjectOfType<upgradeSystem>();
        numberOfEnemies = 0;
    }

    private void Update()
    {
        if (C.coilHealth == 0)
        {
            if (gameHasEnded == false)
            {
                gameHasEnded = true;
                Invoke("EndGame", restartDelay);
            }
        }

        else if ((numberOfEnemies == 0) && (enemiesKilled == 10)) 
        {
            uS.upgradeMenuActive();
            pS.dayNumber += 1;
            pS.difficultyIndex = 0;
        }
    }

    private void EndGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
