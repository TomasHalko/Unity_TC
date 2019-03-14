using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameHandler : MonoBehaviour
{
    // Bar Hooks
    [SerializeField] public actualHealthBar healthBar;
    [SerializeField] public actualEnergyBar energyBar;
    
    // Unity Hooks
    private coilStats C;
    private upgradeSystem uS;
    private proceduralSpawning pS;

    // Game Handling Variables
    private bool gameHasEnded = false;
    private float restartDelay = 2f;
    public int numberOfEnemies = 0;
    public bool nextDay = false;
    public bool wasSpawned = false;
    public bool isPaused = false;

    // Start is called before the-first frame update
    void Start() {
        C = FindObjectOfType<coilStats>();
        pS = FindObjectOfType<proceduralSpawning>();
        uS = FindObjectOfType<upgradeSystem>();
        energyBar.SetSize(2f);
        healthBar.SetSize(2f);
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

        else if ((numberOfEnemies == 0) && (wasSpawned == true) && (nextDay == true) && (isPaused == false)) 
        {
            isPaused = true;
            uS.upgradeMenuActive();
            pS.dayNumber += 1;
            nextDay = false;
            pS.difficultyIndex = 0;
        }
    }

    private void EndGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
