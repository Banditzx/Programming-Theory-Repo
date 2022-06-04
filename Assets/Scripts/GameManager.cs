using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> respawnList;
    [SerializeField] private List<GameObject> vehicles;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RespawnTrafic());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator RespawnTrafic()
    {
        var interval = Random.Range(3, 7);
        var vehicleIndex = Random.Range(0, vehicles.Count);
        var respawnPointIndex = Random.Range(0, respawnList.Count);
        yield return new WaitForSeconds(interval);

        var path = respawnPointIndex == 1 ? Quaternion.Euler(0, 90, 0) : Quaternion.Euler(0, -90, 0);
        Instantiate(vehicles[vehicleIndex], respawnList[respawnPointIndex].transform.position, path);
        StartCoroutine(RespawnTrafic());
    }
}
