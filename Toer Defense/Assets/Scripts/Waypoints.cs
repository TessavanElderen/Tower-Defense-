using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [Header("Lists")]
    [SerializeField] List<Transform> waypoints = new List<Transform>();
    private int index = 0;
    
    [SerializeField] float speed = 5f;

    [SerializeField] Transform target;

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
    void MoveToWayPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
            waypoints[index].position, 
            speed * Time.deltaTime); // De enemy beweegt naar de waypoint in de lijst.
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards
            (transform.forward, waypoints[index].position - transform.position, 
            speed * Time.deltaTime, 0)); // De Enemy kijkt naar de waypoint en draait er naar toe. 

        if (Vector3.Distance(transform.position, waypoints[waypoints.Count - 1].position) < 0.01f)
        {
           Destroy(gameObject);
        }
        else if(Vector3.Distance(transform.position, waypoints[index].position) < 0.01f)
        {
            index++;
        }
    }
}
