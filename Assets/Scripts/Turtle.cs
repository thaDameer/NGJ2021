using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
public class Turtle : MonoBehaviour
{
    [SerializeField] private Animator turtleAnimator;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private LayerMask layerMask;
    private bool isWalking;
    private Vector3 endPosition;
    bool TryGetWaterPosition(out Vector3 waterPos)
    {
        RaycastHit hit;
        Collider[] collider = Physics.OverlapSphere(transform.position, 50, layerMask);
        if (collider.Length > 0)
        {
            var random = Random.Range(0, collider.Length - 1);
            Vector3 waterPosition = collider[random].transform.position;
            waterPosition.y = transform.position.y;
            waterPos = waterPosition;
            return true;
        }

        waterPos = Vector3.zero;
        return false;
    }

    public void SpawnTurtle()
    {
        //DO animation?
        EggSpawner.Instance.AddHatchedTurtle(this);
        UIManager.Instance.UpdateHatchedCounter();
        StartCoroutine(SpawnRoutine_CO());
    }

    IEnumerator SpawnRoutine_CO()
    {
        turtleAnimator.SetTrigger("Spawn");
        yield return new WaitForSeconds(0.5f);
        if(TryGetWaterPosition(out Vector3 waterPos))
        {
            endPosition = waterPos;
            isWalking = true;
            agent.SetDestination(endPosition);
        }
    }
    
}
