using UnityEngine;
using UnityEngine.AI;

public class NPCMover : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform roamCenter;
    [SerializeField] private float roamRadius = 10f;
    [SerializeField] private float waitAtDestination = 2f;
    [SerializeField] private int maxDestinationAttempts = 30;
    [SerializeField, Range(0.1f, 1f)] private float animationSpeed = 0.75f;

    private NavMeshAgent agent;
    private Animator animator;
    private float waitTimer;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (agent == null)
        {
            Debug.LogError($"{name}: falta el componente NavMeshAgent.", this);
        }

        if (animator == null)
        {
            Debug.LogError($"{name}: falta el componente Animator.", this);
            return;
        }

        animator.applyRootMotion = false;
        animator.speed = animationSpeed;
    }

    private void Start()
    {
        if (agent == null)
        {
            return;
        }

        if (target != null)
        {
            agent.SetDestination(target.position);
            return;
        }

        SetRandomDestination();
    }

    private void Update()
    {
        if (agent == null)
        {
            return;
        }

        if (target == null && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            waitTimer -= Time.deltaTime;

            if (waitTimer <= 0f)
            {
                SetRandomDestination();
            }
        }

        if (animator == null)
        {
            return;
        }

        float speed = agent.velocity.magnitude;

        if (HasParameter("Speed", AnimatorControllerParameterType.Float))
        {
            animator.SetFloat("Speed", speed);
        }

        if (HasParameter("MotionSpeed", AnimatorControllerParameterType.Float))
        {
            animator.SetFloat("MotionSpeed", speed);
        }

        if (HasParameter("Grounded", AnimatorControllerParameterType.Bool))
        {
            animator.SetBool("Grounded", true);
        }

        if (HasParameter("FreeFall", AnimatorControllerParameterType.Bool))
        {
            animator.SetBool("FreeFall", false);
        }
    }

    private void SetRandomDestination()
    {
        if (!agent.isOnNavMesh)
        {
            Debug.LogError($"{name}: el NPC no está colocado sobre un NavMesh.", this);
            return;
        }

        Vector3 center = roamCenter == null ? transform.position : roamCenter.position;

        for (int attempt = 0; attempt < maxDestinationAttempts; attempt++)
        {
            Vector3 randomOffset = Random.insideUnitSphere * roamRadius;
            Vector3 candidate = center + randomOffset;

            if (NavMesh.SamplePosition(candidate, out NavMeshHit hit, 2f, NavMesh.AllAreas))
            {
                agent.isStopped = false;
                agent.SetDestination(hit.position);
                waitTimer = waitAtDestination;
                return;
            }
        }

        Debug.LogError($"{name}: no se encontró un destino válido dentro del área de movimiento.", this);
    }

    private bool HasParameter(string parameterName, AnimatorControllerParameterType parameterType)
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.name == parameterName && parameter.type == parameterType)
            {
                return true;
            }
        }

        return false;
    }
}