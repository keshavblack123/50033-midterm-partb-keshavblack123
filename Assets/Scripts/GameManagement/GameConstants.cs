using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConstants", menuName = "ScriptableObjects/GameConstants", order = 1)]
public class GameConstants : ScriptableObject
{
    // lives
    public int maxLives;

    public int speed;
    public int maxSpeed;
    public int upSpeed;
    public Vector3 pinkmanStartingPosition;

}
