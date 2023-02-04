using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;
public class MolotowThrower : PlayerSkill
{
    
    [SerializeField] private List<Molotow> molotowObjects;
    [SerializeField] private float throwDistance;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateSkill();
        }
    }
    [ContextMenu("ActivateSkill ")]
    public override void ActivateSkill()
    {
        var spawnAmount = Mathf.RoundToInt(skillFeature.Value);
        Disableolotows();
        StartCoroutine(ThrowMolotowsCor(spawnAmount));
    }

    private IEnumerator ThrowMolotowsCor(int spawnAmount)
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            molotowObjects[i].gameObject.SetActive(true);
            molotowObjects[i].transform.position = PlayerWrapper.instance.transform.position ;

            Vector3 molotowEndPosition = GetRandomCircle();

            molotowObjects[i].transform.DOJump(molotowEndPosition,1,1,.5f);
            yield return new WaitForSeconds(.2f);


        }
    }

    private Vector3 GetRandomCircle()
    {
        var randompointdirection = Random.insideUnitCircle.normalized;
        var point= throwDistance* randompointdirection;
        return new Vector3(PlayerWrapper.instance.transform.position.x + point.x, 1f, PlayerWrapper.instance.transform.position.z + point.y);


    }

    private void Disableolotows()
    {
        for (int i = 0; i < molotowObjects.Count; i++)
        {
            molotowObjects[i].transform.localPosition = Vector3.zero;
            molotowObjects[i].gameObject.SetActive(false);

        }
    }
}
