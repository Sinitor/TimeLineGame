using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected private Transform target;
    [SerializeField] protected private float speed = 2f;
    [SerializeField] protected private int damage;
    [SerializeField] protected private Vector3 dir;
    public void Move() //Projectile movement and rotation
    {
        float distanceThisFrame = speed * Time.deltaTime;
        var angleDirection = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angleDirection, Vector3.forward);

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
}
