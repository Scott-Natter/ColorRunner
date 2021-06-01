using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Measures height for LevelData
/// <see href="https://stackoverflow.com/questions/12386029/separate-class-for-enums">Separate class for enums? [closed]</see>
/// </summary>
public enum Height
{
    high,
    medium,
    low
}

/// <summary>
/// Contains Various Metadata for this Level
/// </summary>
public class LevelData : MonoBehaviour
{

    [Header("How you can enter this Level")]
    [Space(10)]
    [Header("are done building the level.")]
    [Header("Please fill this data once you")]
    [Header("tell if the platforms you added are valid.")]
    [Header("NOTICE: This is a MANUAL Data Script, it CANNOT")]
    public Height[] inputHeights;

    [Header("How you can exit this Level")]
    public Height[] outputHeights;
}
