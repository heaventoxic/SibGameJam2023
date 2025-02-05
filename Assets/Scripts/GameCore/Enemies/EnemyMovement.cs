using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    #region Public Variables

    [HideInInspector] public List<Waypoint> movePoints;

    #endregion

    #region Private Variables

    int currentPointIndex;
    bool clockwiseMovement = true;
    bool canMove = true;
    NavMeshAgent agent;

    #endregion

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SequentalWaypointsMovement()
    {
        if (canMove == false) return;

        if (movePoints.Count == 0)
            return;

        if (Vector3.Distance(transform.position, movePoints[currentPointIndex].transform.position) > 2f)
        {
            agent.SetDestination(movePoints[currentPointIndex].transform.position);
        }
        else
        {
            if (movePoints[currentPointIndex].NeedStay)
            {
                StartCoroutine(WaitOnPoint(movePoints[currentPointIndex].StayTime));
            }

            if (clockwiseMovement == true)
            {
                if (currentPointIndex == movePoints.Count - 1)
                {
                    clockwiseMovement = false;
                    return;
                }
                currentPointIndex++;
            }
            else if (clockwiseMovement == false)
            {
                if (currentPointIndex == 0)
                {
                    clockwiseMovement = true;
                    return;
                }
                currentPointIndex--;
            }
        }
    }

    public void MoveToTarget(Transform target)
    {
        agent.SetDestination(target.position);
    }

    private IEnumerator WaitOnPoint(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }
}