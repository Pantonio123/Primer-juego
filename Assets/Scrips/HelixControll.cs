using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HelixControll : MonoBehaviour
{

    private Vector2 lasTapPosition;
    private Vector3 startRotation;
    public Transform topTransform;
    public Transform goalTransform;
    public GameObject helixLevelPrefab;

    public List<Stage> allStages = new List<Stage>();

    public float helixDistance;

    private List<GameObject> spawnedLevels = new List<GameObject>();

    private void Awake()
    {
        startRotation = transform.localEulerAngles;
        helixDistance = topTransform.localPosition.y - (goalTransform.localPosition.y + .1f);
        LoadStage(0);
    }


    void Update()
    {

        if (Input.GetMouseButton(0)){

            Vector2 currentTapPosition = Input.mousePosition;

            if(lasTapPosition == Vector2.zero){
                lasTapPosition = currentTapPosition;
            }

            float distance = lasTapPosition.x - currentTapPosition.x;
            lasTapPosition = currentTapPosition;

            transform.Rotate(Vector3.up * distance);

        }

        if(Input.GetMouseButtonUp(0)){

            lasTapPosition = Vector2.zero;
        }


    }


    public void LoadStage(int stageNumber){

        Stage stage = allStages[Mathf.Clamp(stageNumber, 0, allStages.Count-1)];

        if (stage == null){

            Debug.Log("No Stage");
            return;
        }

        Camera.main.backgroundColor = allStages [stageNumber].stageBackgroundColor;
        FindAnyObjectByType <BallControll>().GetComponent<Renderer>().material.color = allStages [stageNumber].stageBallColor;
        transform.localEulerAngles = startRotation;


        foreach (GameObject go in spawnedLevels){
            Destroy(go);
        }

        float levelDistance = helixDistance/stage.levels.Count;

        float spawnPosY = topTransform.localPosition.y;


        for (int i = 0; i < stage.levels.Count; i++)
        {
            spawnPosY -= levelDistance;
            
            GameObject level = Instantiate(helixLevelPrefab, transform);

            level.transform.localPosition = new Vector3(0, spawnPosY, 0);

            spawnedLevels.Add(level);

            int partsToDisable = 12-stage.levels[i].partCount;

            List<GameObject> disableParts = new List<GameObject>();

            while (disableParts.Count < partsToDisable)
            {
                GameObject randomPart = level.transform.GetChild(Random.Range(0, level.transform.childCount)).gameObject;

                if(!disableParts.Contains(randomPart)){
                    randomPart.SetActive(false);
                    disableParts.Add(randomPart);
                }
            }

            List<GameObject> leftParts = new List<GameObject> ();

            foreach (Transform t in level.transform)
            {
                t.GetComponent<Renderer>().material.color = allStages[stageNumber].stageLevelPartColor;

                if (t.gameObject.activeInHierarchy)
                {
                    leftParts.Add(t.gameObject);
                }
            }

            List<GameObject> deathparts = new List<GameObject>();

            while (deathparts.Count < stage.levels[i].deathPartcount)
            {
                GameObject randomPart = leftParts[(Random.Range(0, leftParts.Count))];

                if (!deathparts.Contains(randomPart))
                {
                    randomPart.gameObject.AddComponent<DeathPart>();
                    deathparts.Add(randomPart);
                }
            }


        }

    }
}
