using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DoorCollision : MonoBehaviour
{
    [SerializeField] private GameObject[] keys;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && keys.All(key => !key.activeSelf))
        {
            Debug.Log("Level Complete!");
            player.SetActive(false);
        }

        else
        {
            Debug.Log("Door is locked!");
        }
    }
}
