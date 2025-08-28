using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public GameObject player;
    public float speed;
    public float distanceBetween;

    private float distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position); // Gets the distance between the first point (tf.position) and the second point (player.tf.position)
        Vector2 direction = player.transform.position - transform.position; // Finds the position between the player and the enemy and uses the value as a direction (-1 to 1)

        if(distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

    }
}
