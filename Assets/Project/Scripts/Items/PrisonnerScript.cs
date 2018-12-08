using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PrisonnerScript : MonoBehaviour {

    public Personnage perso;
    public float destroyDistance = 50f;
    public Transform escapePoint;
    bool isInRange;
    bool isReleased;
    Animator anim;
    NavMeshAgent navAgent;
    Transform player;

    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Action") && isInRange && !isReleased)
        {
            List<Personnage> tempSurvivants = new List<Personnage>(GameManager.instance.survivants);
            tempSurvivants.Add(perso);
            GameManager.instance.survivants = tempSurvivants.ToArray();
            anim.SetTrigger("Release");
            navAgent.SetDestination(escapePoint.position);
            isReleased = true;
        }
        if (isReleased)
        {
            if (!navAgent.pathPending)
            {
                if (navAgent.remainingDistance <= navAgent.stoppingDistance)
                {
                    if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f)
                    {
                        Destroy(gameObject);
                    }
                } else
                {
                    if (Vector3.Distance(transform.position, player.position) >= destroyDistance)
                    {
                        Destroy(gameObject);
                    }
                }
            }
            
        }
    }

    private void FixedUpdate()
    {
        if (!isReleased)
        {
            transform.LookAt(player);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInRange = false;
        }
    }
}
