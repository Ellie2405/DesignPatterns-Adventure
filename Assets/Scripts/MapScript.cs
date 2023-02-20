using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MapScript : MonoBehaviour
{
    [SerializeField] List<MapIconScript> MapObjects;
    [SerializeField] MapIconScript EnemyIcon;
    [SerializeField] MapIconScript PickupIcon;
    [SerializeField] MapIconScript PlayerIcon;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitDelay());
    }

    //initialize all objects on the map, this has to happen with slight delay to make sure gamemanager knows all objects
    void Init()
    {
        MapIconScript instance;
        foreach (var item in GameManager.Instance.Enemies)
        {
            MapObjects.Add(Instantiate(EnemyIcon, item.transform.position + new Vector3(100, 100, 0), Quaternion.identity, transform));
            MapObjects[index].WorldObject = item;
            index++;
        }
        foreach (var item in GameManager.Instance.Pickups)
        {
            MapObjects.Add(Instantiate(PickupIcon, item.transform.position, Quaternion.identity, transform));
            MapObjects[index].WorldObject = item;
            index++;
        }
        instance = Instantiate(PlayerIcon, GameManager.Instance.Player.transform.position, Quaternion.identity, transform);
        instance.WorldObject = GameManager.Instance.Player;
    }

    IEnumerator InitDelay()
    {
        yield return new WaitForSeconds(.1f);
        Init();
    }
}
