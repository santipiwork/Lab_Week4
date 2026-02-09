using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SolutionOne : MonoBehaviour
{
    // base elements in the inspector
    public string characterName = "Sir John";
    public string characterClass = "paladin"; 
    public int level = 1;                     
    public int conScore = 10;                 
    public string race = "human";             
    public string feat = "";                  
    public bool hpAverage = false;            

    // private variables that will be used for calculations
    private int hp = 0;                       
    private int conMod = 0;                   

    // Dictionary of max dice for each class
    private Dictionary<string, int> classHitDice = new Dictionary<string, int>()
    {
        {"barbarian", 12},
        {"bard", 8},
        {"cleric", 8},
        {"druid", 8},
        {"fighter", 10},
        {"monk", 8},
        {"paladin", 10},
        {"ranger", 10},
        {"rogue", 8},
        {"sorcerer", 6},
        {"warlock", 8},
        {"wizard", 6},
        {"artificer", 8}
    };

    // Dictionary of averaged HP for each class
    private Dictionary<string, double> classAverageHit = new Dictionary<string, double>()
    {
        {"barbarian", 6.5},
        {"bard", 4.5},
        {"cleric", 4.5},
        {"druid", 4.5},
        {"fighter", 5.5},
        {"monk", 4.5},
        {"paladin", 5.5},
        {"ranger", 5.5},
        {"rogue", 4.5},
        {"sorcerer", 3.5},
        {"warlock", 4.5},
        {"wizard", 3.5},
        {"artificer", 4.5}
    };

    // Dictionary for race HP bonus per level
    private Dictionary<string, int> raceHPBonus = new Dictionary<string, int>()
    {
        {"dwarf", 2},
        {"orc", 1},
        {"goliath", 1}
    };

    void Start()
    {
        CalculateHP();
    }

    void CalculateHP()
    {
        // lowercase everything to make sure no errors from case
        characterClass = characterClass.ToLower();
        race = race.ToLower();
        feat = feat.ToLower();

        // calculates the constitution modifier
        conMod = (conScore - 10) / 2; 

        // if hp avarage is true then runs the hp avarage calc
        if (hpAverage)
        {
            // calculates using dictionary expected value for each level
            if (classAverageHit.ContainsKey(characterClass))
            {
                hp = (int)((classAverageHit[characterClass] * level) + (conMod * level));
            }
            // calculates if the user messed up the class and still gives value
            else
            {
                Debug.LogWarning("Class not found! Using d6 average.");
                hp = (int)((3.5 * level) + (conMod * level));
            }
        }
        // else that runs only when hp avarage isn't true
        else
        {
            // calculates using dictionary for hit die for each level
            for (int i = 0; i < level; i++)
            {
                //if funcion that rolls the die and runs as many times as level exists with an else just in case user messes up class 
                int dieRoll = 0;
                if (classHitDice.ContainsKey(characterClass))
                {
                    dieRoll = Random.Range(1, classHitDice[characterClass] + 1); // Inclusive
                }
                else
                {
                    Debug.LogWarning("Class not found! Using d6 roll.");
                    dieRoll = Random.Range(1, 7);
                }
                // hp is changed and added per level using the roll and constitution mod
                hp += dieRoll + conMod;
            }
        }

        // if the race is part of the dictionary it adds the value if not then skips this part
        if (raceHPBonus.ContainsKey(race))
        {
            hp += raceHPBonus[race] * level;
        }

        // checks feats and then adds their bonus to health
        if (feat.Contains("tough")) hp += 2 * level;
        if (feat.Contains("stout")) hp += 1 * level;

        // debug log output that changes depennding on all the variables 
        Debug.Log($"My character {characterName} is a level {level} {characterClass} with a CON score of {conScore} and is of {race} race.");

        if (feat.Contains("tough"))
            Debug.Log("Has Tough feat.");
        else if (feat.Contains("stout"))
            Debug.Log("Has Stout feat.");
        else
            Debug.Log("No Tough/Stout feat.");

        if (hpAverage)
            Debug.Log("I want the HP averaged.");
        else
            Debug.Log("I want the HP rolled.");

        Debug.Log($"Maximum HP: {hp}");
    }
}
