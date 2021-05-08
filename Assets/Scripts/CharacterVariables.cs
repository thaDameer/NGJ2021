using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character variable",menuName = "CharacterVariable")]
public class CharacterVariables : ScriptableObject
{
   public float maxMovementSpeed;
   public float minMovementSpeed;
   public float maxEnergy;
   public float minEnergy;
   public float rotationSpeed;
}
