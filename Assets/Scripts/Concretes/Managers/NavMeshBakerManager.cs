using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBakerManager : MonoBehaviour
{
    [SerializeField]
    NavMeshSurface[] navMeshSurfaces2;
    //List<NavMeshSurface> navMeshSurfaces = new List<NavMeshSurface>;
    GameObject[] gameObjects2;
    // Start is called before the first frame update
    [SerializeField] GameObject g1;
    [SerializeField] NavMeshSurface ns1;
    void Start()
    {
        //gameObjects2 = GameObject.FindGameObjectsWithTag("deskTag");
        //foreach (NavMeshSurface item in gameObjects2)
        //{

        ////}
        //gameObjects2 = GameObject.FindGameObjectsWithTag("deskTag");
        //Debug.Log(gameObjects2.Length);


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            dene();
        }
    }
    private void dene()
    {

        ns1.BuildNavMesh();
    }

}
