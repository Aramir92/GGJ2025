using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    private static PlayerSpawnPoint instance;

    private void OnEnable()
    {
        instance = this;
    }

    public static Vector3 GetSpawnPosition()
    {
        return instance.transform.position;
    }
}
