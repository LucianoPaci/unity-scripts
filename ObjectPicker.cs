using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class ObjectPicker : MonoBehaviour
{
    public GameObject obj, player;
    private bool looking = false;
    public float minDistance = 10.0f;
    private float distance;
    // Use this for initialization
    void Start()
    {
        looking = false;
    }
    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, obj.transform.position);
        if (looking)
        {
            if (distance <= minDistance)
            {
                if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("BottomTrigger"))
                {
                    obj.SetActive(false);
                }
            }
        }
        GetComponent<Renderer>().material.color = (looking && distance <= minDistance) ?
      Color.green : Color.red;
    }
    #region IGvrGazeResponder implementation
    /// Called when the user is looking on a GameObject with this script,
    /// as long as it is set to an appropriate layer (see GvrGaze).
    public void OnGazeEnter()
    {
        looking = true;
    }
    /// Called when the user stops looking on the GameObject, after OnGazeEnter
    /// /// was already called.
    public void OnGazeExit()
    {
        looking = false;
    }
    /// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
    public void OnGazeTrigger()
    {
        if (distance <= minDistance)
        {
            obj.SetActive(false);
        }
    }
    #endregion
}