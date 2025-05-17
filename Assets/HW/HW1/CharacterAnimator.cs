using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Transform lookTarget;
    Vector3 lastLookTargetPosition; 
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on this GameObject.");
        }
    }
    void Update()
    {
        animator.SetFloat("Speed", Input.GetAxis("Vertical"));
        animator.SetFloat("Direction", Input.GetAxis("Horizontal"));
    }

    void OnAnimatorIK(int layerIndex)
    {
        if (lookTarget != null)
        {
            Vector3 currentLookPosition = lookTarget.position;
            if (currentLookPosition != lastLookTargetPosition)
            {
                animator.SetLookAtWeight(1);
                animator.SetLookAtPosition(currentLookPosition);
                lastLookTargetPosition = currentLookPosition;
            }
        }
    }
}

/*
1. What is the cost of calling GetComponent() in every frame? 
GetComponent() is expensive on CPU and should be cached.
2. How can we reduce unnecessary calls to SetLookAtPosition()? 
We cache the last position and only call SetLookAtPosition() if the position has changed.
3. What performance issues would show in Profiler or Timeline view? 
The profiler would show spikes in CPU usage when GetComponent() is called frequently, and the Timeline view would show inconsistent frame times due to the overhead of these calls.
*/
