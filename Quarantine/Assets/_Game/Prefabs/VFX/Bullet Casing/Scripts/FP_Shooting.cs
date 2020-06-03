using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FP_Shooting : MonoBehaviour {

    public GameObject Cardridge;


    private void test()
    {
    }

    public void Shoot()
    {
        Collider playerCollider = FindObjectOfType<PlayerCharacterController>().GetComponent<Collider>();
        var shell = Instantiate(Cardridge, transform.position, Quaternion.identity);
        Physics.IgnoreCollision(playerCollider, shell.GetComponentInChildren<Collider>());
        shell.GetComponentInChildren<Rigidbody>().AddForce(50 * Vector3.up + (50 * -Vector3.forward));
        Destroy(shell, 15f);
    }

    public double Shoot(int time, double test, double test2)
    {
        Collider playerCollider = FindObjectOfType<PlayerCharacterController>().GetComponent<Collider>();
        var shell = Instantiate(Cardridge, transform.position, Quaternion.identity);
        Physics.IgnoreCollision(playerCollider, shell.GetComponentInChildren<Collider>());
        shell.GetComponentInChildren<Rigidbody>().AddForce(50 * Vector3.up + (50 * -Vector3.forward));
        Destroy(shell, time);

        return 1;
    }
}

