using UnityEngine;

/// <summary>
/// A collecting game object
/// </summary>
public class Collector : MonoBehaviour
{
	#region Fields

    // targeting support
    SortedList<Target> targets = new SortedList<Target>();
    Target targetPickup = null;
    GameObject targetPickupObject;
    
    // movement support
    const float BaseImpulseForceMagnitude = 2.0f;
    const float ImpulseForceIncrement = 0.3f;

    // saved for efficiency
    Rigidbody2D rb2d;

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start() {
        // center collector in screen
        Transform objectTransform = transform;
        Vector3 position = objectTransform.position;

        position.x = 0;
        position.y = 0;
        position.z = 0;

        objectTransform.position = position;

        // save reference for efficiency
        rb2d = GetComponent<Rigidbody2D>();

        // add as listener for pickup spawned event
        EventManager.AddListener(HandlePickupSpawnedEvent);
    }

    /// <summary>
    /// Called when another object is within a trigger collider
    /// attached to this object
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay2D(Collider2D other) {
        // only respond if the collision is with the target pickup
        if (other.gameObject != targetPickupObject)
            return;

        // remove collected pickup from list of targets and game
        int targetPickupIndex = targets.IndexOf(targetPickup);
        GameObject deadTarget = targets[targetPickupIndex].GameObject;
        targets.RemoveAt(targetPickupIndex);
        Destroy(deadTarget);
        
        // go to next target if there is one
        rb2d.velocity = Vector2.zero;

        if (targets.Count > 0)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                targets[i].UpdateDistance(transform.position);
            }

            targets.Sort();
            SetTarget(targets[^1]);
        }
        else
        {
            targetPickup = null;
        }
    }

    /// <summary>
    /// Starts the teddy bear moving toward the target pickup
    /// </summary>
    void GoToTargetPickup() {
        if (targetPickupObject == null)
            return;

        Vector3 targetPosition = targetPickupObject.transform.position;
        Vector3 objectPosition = transform.position;

        Vector2 direction = new Vector2(
            targetPosition.x - objectPosition.x,
            targetPosition.y - objectPosition.y);

        direction.Normalize();
        rb2d.velocity = Vector2.zero;
        float forceAmount = ImpulseForceIncrement * targets.Count + BaseImpulseForceMagnitude;
        rb2d.AddForce(direction * forceAmount, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Sets the target pickup to the provided pickup
    /// </summary>
    /// <param name="pickup">Pickup.</param>
    void SetTarget(Target pickup) {
        targetPickup = pickup;
        targetPickupObject = targetPickup.GameObject;
        GoToTargetPickup();
    }

    void HandlePickupSpawnedEvent(GameObject pickupObject) {
        targets.Add(new Target(pickupObject, transform.position));

        float targetPickupDistance = Mathf.Infinity;

        if (targetPickupObject != null)
        {
            targetPickupDistance = Vector3.Distance(targetPickupObject.transform.position, transform.position);
        }

        if (targets[^1].Distance < targetPickupDistance)
        {
            SetTarget(targets[^1]);
        }
    }

	#endregion
}