using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/// <summary>
/// Joins Scenes Together
/// <see href="https://docs.unity3d.com/Manual/InstantiatingPrefabs.html">Instantiating Prefabs at run time</see>
/// Constructs a Sequence of Platform Prefabs
/// Does NOT handle movement of platforms, speed of movement, triggering of trap platforms, etc
/// For 2D use ONLY!!!
/// </summary>
public class LevelJoiner : MonoBehaviour
{







    [Header("Constructs a Sequence of Platform Prefabs")]
    public GameObject[] platforms;

    [Header("We Spawn Platform Prefabs at a certain location")]
    public Transform spawnPoint;

    // NOTE: Assumes along the X axis
    [Header("Platforms can be Negatively (overlapping) or Positively (gapped) offset when spawned")]
    public float offSet;

    // Where we actually spawn things
    // Calculated with the offSet
    private Vector2 actualSpawnPoint;

    // In-Order, Oldest to Newest, the Last Five Platforms that we Spawned
    private List<GameObject> lastFivePlatforms = new List<GameObject>();

    // For selecting NextPlatform, what Inputs must it have
    private Height[] lastOutputHeights;









    public void Start()
    {
        // Find the Offset Position
        actualSpawnPoint = new Vector2(spawnPoint.position.x - offSet, spawnPoint.position.y);
    }








    /// <summary>
    /// Request a New Segment at the Spawn Location
    /// </summary>
    public GameObject AddSegment()
    {
        // Temporary Debug
        Debug.Log("Adding Next Segment");

        // Find Next Segment
        GameObject nextSegment = NextSegment();

        // Add the Segment at the SpawnPoint
        Instantiate(nextSegment, actualSpawnPoint, Quaternion.identity);

        // Return a reference to the new Segment
        return nextSegment;
    }








    /// <summary>
    /// Randomly, Interestingly, and Correctly choose a new PlatformPrefab to add to the sequence
    /// Requires the Previous Platform, Random
    /// <see href="https://answers.unity.com/questions/1005499/i-want-unity-to-randomly-choose-one-of-3-numbers.html">I want Unity to randomly choose one of 3 numbers</see>
    /// <see href="https://stackoverflow.com/questions/1246918/how-can-i-find-the-last-element-in-a-list">How can I find the last element in a List<>?</see>
    /// <see href="https://stackoverflow.com/questions/2745544/remove-items-from-one-list-in-another">Remove items from one list in another</see>
    /// </summary>
    public GameObject NextSegment()
    {
        // Short-Circuit on the First Platform
        if (lastFivePlatforms.Count == 0)
        {
            return FirstSegment();
        }

        // Find Correct Continuing Sequences
        List<GameObject> validPlatforms = ValidPlatforms();

        // Remove Previously Seen Sequences
        List<GameObject> unseenPlatforms = validPlatforms;
        foreach (GameObject seenPlatform in lastFivePlatforms)
        {
            unseenPlatforms.Remove(seenPlatform);
        }

        // If we have no other options (we have already seen the platform before), just show it again anyways
        if (unseenPlatforms.Count == 0)
        {
            unseenPlatforms = validPlatforms;
        }

        // Randomly pick from remaining platforms
        int randomIndex = Random.Range(0, unseenPlatforms.Count);
        GameObject nextPlatform = platforms[randomIndex];

        // Add Last Sequence to List of Recent Sequences
        lastFivePlatforms.Add(nextPlatform);

        // Remove Oldest Sequence from List of Sequences if Length Above 5
        if (lastFivePlatforms.Count > 5)
        {
            // In Case we somehow accidentally end up with 7 or higher
            while(lastFivePlatforms.Count >= 6)
            {
                // Remove first element each time
                lastFivePlatforms.RemoveAt(0);
            }
        }

        // Set Last Sequence Data (InputHeight, OutputHeight) as Next Sequence
        lastOutputHeights = nextPlatform.GetComponent<LevelData>().outputHeights;

        // Return the Prefab
        return nextPlatform;
    }




    /// <summary>
    /// Valid Platforms must have at least ONE of the output levels as the Last Platform
    /// </summary>
    /// <returns>Correct Continuing Sequences from the Last Platform</returns>
    private List<GameObject> ValidPlatforms()
    {
        // Valid Platforms must have at least ONE of the output levels as the Last Platform
        List<GameObject> validPlatforms = new List<GameObject>();
        foreach (GameObject nextPlatform in platforms)
        {
            if (IsValid(nextPlatform))
            {
                validPlatforms.Add(nextPlatform);
            }
        }

        // Return the List
        return validPlatforms;
    }




    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="nextPlatform">TODO</param>
    /// <returns>TODO</returns>
    private bool IsValid(GameObject nextPlatform)
    {
        // Check Each NextPossiblePlatform's Input Heights
        LevelData nextLevelData = nextPlatform.GetComponent<LevelData>();
        foreach (Height inputHeight in nextLevelData.inputHeights)
        {
            // Check Each LastPlatform's Output Heights
            foreach (Height outputHeight in lastOutputHeights)
            {
                // If any of the heights are the same
                if (inputHeight == outputHeight)
                {
                    // Return it
                    return true;
                }
            }
        }

        // Worst Case, its not valid
        return false;
    }





    /// <summary>
    /// TODO
    /// </summary>
    /// <returns>TODO</returns>
    public GameObject FirstSegment()
    {
        // Randomly Pick a Platform
        int randomIndex = Random.Range(0, platforms.Length);
        GameObject nextPlatform = platforms[randomIndex];

        // Add Last Sequence to List of Recent Sequences
        lastFivePlatforms[0] = nextPlatform;

        // Set Last Sequence Data (InputHeight, OutputHeight) as Next Sequence
        lastOutputHeights = nextPlatform.GetComponent<LevelData>().outputHeights;

        // Return the Prefab
        return nextPlatform;
    }






}
