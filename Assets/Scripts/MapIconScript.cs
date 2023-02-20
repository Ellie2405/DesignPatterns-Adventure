using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIconScript : MonoBehaviour
{
    //the object this minimap icon is tracking
    public GameObject WorldObject;
    void Start()
    {
        PickupScript.Picked += RemoveIcon;
    }

    //imitate object position
    private void FixedUpdate()
    {
        transform.position = new Vector3(WorldObject.transform.position.x + 10, WorldObject.transform.position.z + 10) * 10;
    }

    //if object gets destroyed, removes map icon
    public void RemoveIcon(GameObject go)
    {
        if (WorldObject == go)
            Destroy(gameObject);
    }
}
