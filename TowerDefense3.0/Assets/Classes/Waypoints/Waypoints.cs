using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [Header("List Refrences")]
    public List<Transform> waypoints = new List<Transform>();
    public GameObject waypointContainer; 

    [Header ("Speed Refrences")]
    public float speed = 5f;

    // Private 
    private int index = 0;
    private void Awake()
    {
        waypointContainer = GameObject.Find("WaypointContainer");

        foreach (Transform waypoint in waypointContainer.transform)
        {
            waypoints.Add(waypoint);
        }
    }

    private void Update()
    {
        MoveToWayPoint();
    }

    private void MoveToWayPoint()
    {
        // De enemy beweegt naar de waypoint in de lijst.
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, speed * Time.deltaTime);
        // De Enemy kijkt naar de waypoint en draait er naar toe. 
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, waypoints[index].position - transform.position, speed * Time.deltaTime, 0));

        // Bereken het punt van de enemy naar de volgende waypoint
        if (Vector3.Distance(transform.position, waypoints[waypoints.Count - 1].position) < 0.01f)
        {
            Destroy(gameObject);
            GameObject.Find("PlayerLives").GetComponent<PlayerHealth>().TakeDamageHealth();
        }

        // als de waypoint is aangeraakt met de enemy dan gaat de enemy naar de volgende in de list
        else if (Vector3.Distance(transform.position, waypoints[index].position) < 0.01f)
        {
            index++;
        }
    }
}
