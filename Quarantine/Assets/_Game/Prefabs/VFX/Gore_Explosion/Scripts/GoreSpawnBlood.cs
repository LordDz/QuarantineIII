using UnityEngine;
using System.Collections;

public class GoreSpawnBlood : MonoBehaviour
{
    private bool isActive = true;
    public GameObject objToSpawn;
    private Rigidbody body;

    private const float cooldownWait = 0.1f;
    private float cooldown = 0f;
    private int layerMask;
    // Use this for initialization
    void Start()
    {
        layerMask = 1 << 0;
        body = GetComponent<Rigidbody>();

        if (body)
        {
            PlayerCharacterController plr = FindObjectOfType<PlayerCharacterController>();
            Collider playerCollider = plr.GetComponent<Collider>();
            Physics.IgnoreCollision(playerCollider, GetComponent<Collider>());

            foreach(Collider collider in GetComponentsInChildren<Collider>())
            {
                Physics.IgnoreCollision(playerCollider, collider);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive && body && cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                isActive = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isActive && collision.transform.CompareTag("Level"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity, layerMask))
            {
                Vector3 pos = new Vector3(hit.transform.position.x, hit.transform.position.y + 0.253f, hit.transform.position.z);
                Instantiate(objToSpawn, pos, Quaternion.Euler(new Vector3(90, transform.eulerAngles.y, 0)));

                if (body)
                {
                    if (body.velocity != Vector3.zero)
                    {
                        cooldown = cooldownWait;
                        isActive = false;
                    }
                    else
                    {
                        gameObject.SetActive(false);
                    }
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
