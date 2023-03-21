using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedEnemy : EnemyBase
{
    
    public Transform m_patrolRoute;  //the rout for the enemy 
    public List<Transform> m_locations; // location for the enemy 
    private int M_LocationIndex = 0; //location index
    public NavMeshAgent m_agent; //agent 

    private Vector3 m_Offset = new Vector3(0f, 0f, 5f);
    private Vector3 m_Offset2 = new Vector3(0f, 5f, 0f);
    
    
    
    //public float maxRotate;

    public float speedUpDown = 1;
    public float distanceUpDown = 1;

    



    private void Start()
    {
        m_agent.GetComponent<NavMeshAgent>();
        
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    //Dedicated to interrupting his Patrol to come and disturb the player while in the area
    private void Update()
    {
        
        //rotate around player
        Vector3 mov = new Vector3(transform.position.x, Mathf.Sin(speedUpDown * Time.time) * distanceUpDown, transform.position.z) + m_Offset2; //used with sin for swinging
        transform.position = mov;

        float distanceToPlayer = Vector3.Distance(m_player.position, transform.position); //distance from the player 
        Vector3 playerPosition = m_player.position - m_Offset; //distance from enemy to player + offset
        if (distanceToPlayer < m_maxDistance)
        {
            
            transform.LookAt(m_player); //enemy always look to the player
            m_agent.destination = playerPosition;
            //transform.RotateAround(playerPosition, Vector3.up, maxRotate * Time.deltaTime);
            m_EnemyWeapon.Shooting(); //shooting
            


        }
        else if (m_agent.remainingDistance < 0.2f && !m_agent.pathPending && distanceToPlayer > m_maxDistance)
        {
            MoveToNextPatrolLocation();
        }

    }


    //InitializePatrolRoute for the agent
    private void InitializePatrolRoute()
    {
        foreach (Transform child in m_patrolRoute)
        {
            m_locations.Add(child);
        }
    }

    //MoveToNextPatrolLocation for the agent 
    private void MoveToNextPatrolLocation()
    {
        if (m_locations.Count == 0)
            return;
        m_agent.destination = m_locations[M_LocationIndex].position;
        M_LocationIndex = (M_LocationIndex + 1) % m_locations.Count;
    }



   



}
