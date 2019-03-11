using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameHandler : MonoBehaviour
{
    [SerializeField] public actualHealthBar healthBar;
    [SerializeField] public actualEnergyBar energyBar;

    private coilStats C;
    private upgradeSystem uS;
    private proceduralSpawning pS;
    private bool gameHasEnded = false;
    private float restartDelay = 2f;
    public int numberOfEnemies = 0;
    public bool nextDay = false;
    public bool wasSpawned = false;

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

        else if ((numberOfEnemies == 0) && (wasSpawned == true) && (nextDay == true)) 
        {
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
