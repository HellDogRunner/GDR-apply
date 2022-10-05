using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(LineRenderer))]
public class MovingScript : MonoBehaviour
{
    [SerializeField] List<Vector3> waypoints = new List<Vector3>();
    [SerializeField] LayerMask floor;
    private int _currentWP;
    private NavMeshAgent _agent;
    private LineRenderer Lr;
    private Vector3 _startpos;
    // 
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        Lr = GetComponent<LineRenderer>();
        _startpos = gameObject.transform.position;
        _currentWP = 0;      
    }

    void Update()
    {
        click();
        move();
    }
    private void click() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(myRay,out hitInfo,100,floor))
            {
                waypoints.Add(hitInfo.point);
                Lr.positionCount = waypoints.Count;
                Lr.positionCount++;
                Lr.SetPosition(Lr.positionCount - 1, hitInfo.point);
                Lr.SetPosition(0, _startpos);
            }
        }
    
    }
    private void move()
    {
        if (waypoints.Count == 0) return;       
        if (Vector3.Distance(waypoints[_currentWP],
                            _agent.transform.position) < 1.0f)
        {
            _currentWP++;
            if (_currentWP >= waypoints.Count)
            {
                _currentWP = 0;
                waypoints.Clear();
                Lr.positionCount = 0;
                _startpos = _agent.transform.position;
                return;
            }

        }
        _agent.SetDestination(waypoints[_currentWP]);
    }
}

