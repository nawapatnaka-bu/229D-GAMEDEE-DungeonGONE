using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Transform leftPos;
    public Transform rightPos;

    private Transform currentTarget;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentTarget = rightPos;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        Vector3 newPos = Vector3.MoveTowards(rb.position, currentTarget.position, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        float distance = Vector3.Distance(rb.position, currentTarget.position);
        if (distance  < 0.05f)
        {
            currentTarget = (currentTarget == rightPos) ? leftPos : rightPos;
        }
        if (currentTarget == rightPos)
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        else
            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
    }
}
