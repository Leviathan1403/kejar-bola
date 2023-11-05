using UnityEngine;

public class ScoreGet : MonoBehaviour
{
    public float score;
    public bool Touch;
    public float jikan;
    public float longestTouch = 0;

    public float tessttime;

    private void Update()
    {
        tessttime += Time.deltaTime;
        // Check if the player is touching the ball (collider is triggered).
        if (Touch)
        {
            jikan += Time.deltaTime;
            score += 0.5f;
            if(jikan > 2)
            {
                score += 1f;
            }

            else if (jikan > 5)
            {
                score += 5f;
            }
        }
        
        if (jikan > longestTouch)
        {
            longestTouch = jikan;
        }
        jikan = 0;

        // Update the player's score based on how long they touch the ball.
        // Debug.Log(jikan);
    }
}