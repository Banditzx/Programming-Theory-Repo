using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> respawnList;
    [SerializeField] private List<GameObject> vehicles;

    [SerializeField] private List<GameObject> characters;
    [SerializeField] private GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RespawnTrafic());
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Awake()
    {
        CreateCharacter();
    }

    private void CreateCharacter()
    {
        character = characters[StoreManager.Instance.characterIndex];
        var player = Instantiate(character, new Vector3(100, 0.1f, 100), character.transform.rotation);
        player.gameObject.SetActive(true);
        player.AddComponent<PlayerController>();
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
