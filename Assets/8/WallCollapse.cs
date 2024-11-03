using UnityEngine;

public class WallCollapse : MonoBehaviour
{
    public Transform player;               // Reference to the player's Transform
    public GameObject[] collapseStages;     // Array of GameObjects for each wall collapse stage
    public float collapseDistance = 5f;     // Distance at which the wall fully collapses

    void Start()
    {
        // Initially, set only the full wall (first stage) to be active
        for (int i = 0; i < collapseStages.Length; i++)
        {
            collapseStages[i].SetActive(i == 0);
        }
    }

    void Update()
    {
        // Calculate the distance between the player and the wall
        float distance = Vector2.Distance(player.position, transform.position);

        // Determine which collapse stage to display based on the player's distance
        if (distance <= collapseDistance)
        {
            // Determine the appropriate stage index based on how close the player is
            int stageIndex = (int)Mathf.Lerp(0, collapseStages.Length - 1, 1 - (distance / collapseDistance));
            
            // Clamp the stage index to be within valid bounds
            stageIndex = Mathf.Clamp(stageIndex, 0, collapseStages.Length - 1);

            // Activate only the relevant collapse stage
            for (int i = 0; i < collapseStages.Length; i++)
            {
                collapseStages[i].SetActive(i == stageIndex);
            }
        }
    }
}
