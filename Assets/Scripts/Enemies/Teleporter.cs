using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : Enemy
{

    public GameObject wizard;

    //used for height and width of screen for portal spawning
    //private int screenHeight;
    //private int screenWidth;

    //used for wizards initial position
    private float startx;
    private float starty;

    private float secondPointx;
    private float secondPointy;

    private float thirdPointx;
    private float thirdPointy;

    private float curPositionx;
    private float curPositiony;

    public float teleRate = 2;

    private float timer = 0;

    public override void Attack()
    {
        //throw new System.NotImplementedException();
    }

    public override bool canAttack()
    {
        return false;
    }

    public override bool IsKnockedOut()
    {
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        base.koTime = 8f;
        base.attackCooldown = 4f;
        base.damage = 20;
        base.moveSpeed = 60f;

        //screenHeight = Screen.currentResolution.height;
        //screenWidth = Screen.currentResolution.width;
        //27
        Camera cam = Camera.main;

        startx = Random.Range(-cam.orthographicSize, cam.orthographicSize);
        starty = Random.Range(-cam.orthographicSize, cam.orthographicSize);

        curPositionx = startx;
        curPositiony = starty;

        calculatePoints();

        spawnWizard();
    }

    // Update is called once per frame
    new void Update()
    {   
        if (timer < teleRate)
        {
            timer += Time.deltaTime;
        } else{
            if (curPositionx == startx && curPositiony == starty)
            {
                curPositionx = secondPointx;
                curPositiony = secondPointy;
                wizard.transform.position = new Vector3(curPositionx, curPositiony, 0);
                timer = 0;
            } 
            else if (curPositionx == secondPointx && curPositiony == secondPointy) {
                curPositionx = thirdPointx; 
                curPositiony = thirdPointy;
                wizard.transform.position = new Vector3(curPositionx, curPositiony, 0);
                timer = 0;
            }
            else if (curPositionx == thirdPointx && curPositiony == thirdPointy)
            {
                curPositionx = startx;
                curPositiony = starty;
                wizard.transform.position = new Vector3(curPositionx, curPositiony, 0);
                timer = 0;
            }
        }

        base.Update();
    }

    void spawnWizard(){
        wizard.transform.position = new Vector3(curPositionx, curPositiony, 0);
    }

    void calculatePoints(){
        float startAngle = Mathf.Atan(starty / startx);
        if (startx < 0)
        {
            startAngle += Mathf.PI;
        }

        float radius = Mathf.Sqrt(Mathf.Pow(starty, 2) + Mathf.Pow(startx, 2));
        
        secondPointx = Mathf.Cos(startAngle + ((2*Mathf.PI)/3)) * radius;
        secondPointy = Mathf.Sin(startAngle + ((2*Mathf.PI)/3)) * radius;

        thirdPointx = Mathf.Cos(startAngle + ((4*Mathf.PI)/3)) * radius;
        thirdPointy = Mathf.Sin(startAngle + ((4 * Mathf.PI) / 3)) * radius;
    }
}
