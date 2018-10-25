using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPManager : MinigameManager
{
    public GameObject AI;
    public GameObject AI_ani_cube;
    public GameObject[] maps;
    


	void Start()
    {
        setMinigame();
    }

    void setMinigame()
    {
        GameObject map = Instantiate(maps[Random.Range(0, maps.Length)]);
        //맵 생성 

        int AISpawnAmount = eight_Players ? 100 : 50;
        for (int i = 0; i < AISpawnAmount; i++)
        {
            GameObject ai = Instantiate(AI);
            GameObject aiBody =  ai.transform.GetChild(0).gameObject;

            GameObject ani_cube = Instantiate(AI_ani_cube, new Vector3(0f, -100f, 0f), Quaternion.Euler(0f, 0f, 0f));
            aiBody.GetComponent<AI_controller>().anim = ani_cube.GetComponent<Animator>();

            legFrontmov[] a = aiBody.GetComponentsInChildren<legFrontmov>();
            legBackmov[] b = aiBody.GetComponentsInChildren<legBackmov>();
            for (int j = 0; j < a.Length; j++)
                a[j].objetivo = ani_cube.transform;
            for (int j = 0; j < b.Length; j++)
                b[j].objectRotation = ani_cube.transform;

            aiBody.transform.position = new Vector3(Random.Range(map.GetComponent<MeshCollider>().bounds.min.x, map.GetComponent<MeshCollider>().bounds.max.x), aiBody.transform.position.y, Random.Range(map.GetComponent<MeshCollider>().bounds.min.z, map.GetComponent<MeshCollider>().bounds.max.z));
            aiBody.transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), -90f);
        }
        //NPC 생성
    }
}
