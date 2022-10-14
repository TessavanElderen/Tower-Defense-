using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class Waypoints : MonoBehaviour
{
    [Header("Lists")]
    [SerializeField] private List<Transform> waypoints = new List<Transform>();
    
    private int index = 0;
    
    [SerializeField] private float speed = 5f;
    private void Awake()
    {
        foreach(GameObject waypoint in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            waypoints.Add(waypoint.transform);
        }
    }

    private void Update()
    {
        MoveToWayPoint();
    }

    private void MoveToWayPoint()
    {
        // De enemy beweegt naar de waypoint in de lijst.
        transform.position = Vector3.MoveTowards(transform.position, 
            waypoints[index].position, 
            speed * Time.deltaTime);
        // De Enemy kijkt naar de waypoint en draait er naar toe. 
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards
            (transform.forward, waypoints[index].position - transform.position, 
            speed * Time.deltaTime, 0)); 

        // Bereken het punt van de enemy naar de volgende waypoint
        if (Vector3.Distance(transform.position, waypoints[waypoints.Count - 1].position) < 0.01f) 
        {
            Destroy(gameObject);
            
        }
        // als de waypoint is aangeraakt met de enemy dan gaat de enemy naar de volgende in de list
        else if (Vector3.Distance(transform.position, waypoints[index].position) < 0.01f) 
        {
            index++;
        }
    }
}
