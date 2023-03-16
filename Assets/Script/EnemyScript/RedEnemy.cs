using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedEnemy : EnemyBase
{
    public Transform Player;
    public Transform PatrolRoute;
    public List<Transform> Locations;
    private int locationIndex = 0;
    public NavMeshAgent agent;
    private Vector3 offset = new Vector3(0f, 0f, 5f);
    private Vector3 offset2 = new Vector3(0f, 5f, 0f);
    
    public float maxDistance;
    public float maxRotate;

    public float speedUpDown = 1;
    public float distanceUpDown = 1;





    private void Start()
    {
        agent.GetComponent<NavMeshAgent>();
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    //Dedicato a interrompere il suo Patrol per venire a disturbare il player finchè in zona
    private void Update()
    {
        //rotate around player
        Vector3 mov = new Vector3(transform.position.x, Mathf.Sin(speedUpDown * Time.time) * distanceUpDown, transform.position.z) + offset2;
        transform.position = mov;

        float distanceToPlayer = Vector3.Distance(Player.position, transform.position);
        Vector3 playerPosition = Player.position + offset;
        if (distanceToPlayer < maxDistance)
        {

            transform.LookAt(Player);
            //agent.destination = playerPosition;
            transform.RotateAround(playerPosition, Vector3.up, maxRotate * Time.deltaTime);



        }
        else if (agent.remainingDistance < 0.2f && !agent.pathPending && distanceToPlayer > maxDistance)
        {
            MoveToNextPatrolLocation();
        }

    }


    private void InitializePatrolRoute()
    {
        foreach (Transform child in PatrolRoute)
        {
            Locations.Add(child);
        }
    }

    private void MoveToNextPatrolLocation()
    {
        if (Locations.Count == 0)
            return;
        agent.destination = Locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % Locations.Count;
    }


}
