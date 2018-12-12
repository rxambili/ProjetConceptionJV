using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    // Player
    public Stats currentPlayerStats;
    public List<Trait> currentPlayerTraits;
    public int nbOrbes;
    public int nbSlots = 3;

    public Personnage[] survivants;
    

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        
        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    void InitGame()
    {
        currentPlayerStats = new Stats();
        currentPlayerTraits = new List<Trait>();


    }
}
