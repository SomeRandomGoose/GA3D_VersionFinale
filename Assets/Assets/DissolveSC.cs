using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveSC : MonoBehaviour
{
    public bool can_dissolve;
    public float dissolveSpeed;
    public float initDiss = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {

                if (hitInfo.collider.gameObject == this.gameObject)
                {
                    if (!can_dissolve)
                    {
                        initDiss = 0;
                        GetComponent<MeshRenderer>().material.SetFloat("DT", 0);
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                        

                    can_dissolve = true;
             
                }
              

            }
        }
    }

    private void FixedUpdate()
    {
        DissolveSofa();
    }
    void DissolveSofa()
    {
        if(can_dissolve)
        {
            print("Oh Yeah~");
            GetComponent<MeshRenderer>().material.SetFloat("DT", initDiss);
            initDiss += 1 * dissolveSpeed * Time.deltaTime;


            if(initDiss > 1)
            {
                //gameObject.GetComponent<AudioSource>().Stop();
                can_dissolve = false;
            }
        }
    }

    private void OnMouseEnter()
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
    }
    private void OnMouseExit()
    {
        Color color = new Color32(241, 157, 157, 255);
        GetComponent<MeshRenderer>().material.SetColor("_Color", color);
    }
}
