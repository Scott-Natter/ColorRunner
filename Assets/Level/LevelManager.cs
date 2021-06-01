using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Handles requesting new Platforms from the LevelJoiner
/// Sits in the Level and detects when the last platform has passed the threshold
/// Also Moves the platforms and Deletes the Platforms
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class LevelManager : MonoBehaviour
{





    [Header("Level Joiner Control Object in Scene")]
    public GameObject levelJoiner;

    // The Level Joiner Component we make requests to
    private LevelJoiner mainLevelJoiner;

    [Header("How quickly the platforms move from right to left")]
    public float moveSpeed;

    // The Segment just ahead of the player
    private GameObject nextSegment;

    // The semgent the player is on Right Now
    private GameObject currentSegment;

    // The Segment just after the player
    private GameObject lastSegment;

    // Track all platforms that need moving
    private List<GameObject> platforms = new List<GameObject>();





    /// <summary>
    /// TODO
    /// </summary>
    public void Start()
    {
        // Find the Level Joiner
        mainLevelJoiner = levelJoiner.GetComponent<LevelJoiner>();

        // Perform Initial Startup
        currentSegment = mainLevelJoiner.AddSegment();

        // Add Next Segment to List
        platforms.Add(currentSegment);
    }



    /// <summary>
    /// Moves the platforms along
    /// <see href="https://forum.unity.com/threads/moving-a-sprite-upwards-via-a-script.695992/">Moving a sprite upwards via a script</see>
    /// </summary>
    public void Update()
    {
        // Move Each Platform
        foreach (GameObject platform in platforms)
        {
            platform.transform.position = new Vector2(platform.transform.position.x - moveSpeed * Time.deltaTime, platform.transform.position.y);
        }
    }




    /// <summary>
    /// TODO
    /// NOTICE this is ABSURDLY lazy and needs to be refined further
    /// </summary>
    /// <param name="collision">TODO</param>
    public void OnCollisionExit2D(Collision2D collision)
    {
        // Check if it was not the current level
        if (collision.gameObject == currentSegment)
        {
            return;
        }

        // Remove Oldest Element from Platforms
        platforms.Remove(lastSegment);

        // Delete the Last Segment
        Destroy(lastSegment);

        // Update Last Segment
        lastSegment = currentSegment;

        // Update Current Segment
        currentSegment = nextSegment;

        // Update Next Segment (Also spawns it)
        nextSegment = mainLevelJoiner.AddSegment();

        // Add Next Segment to List
        platforms.Add(nextSegment);
    }
}
