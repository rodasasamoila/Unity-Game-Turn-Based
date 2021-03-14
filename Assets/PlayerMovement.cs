using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 targetLocation;
    public Vector2 yAxisTargetLocation;
    // Start is called before the first frame update
    void Start()
    {
        CombatProcessor.Instance.player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //xtarget x=0 y=1
        if(targetLocation.y!=gameObject.transform.position.y)
        {
            gameObject.transform.position = Vector2.MoveTowards(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y),
                   new Vector2(gameObject.transform.position.x, targetLocation.y), 3 * Time.deltaTime);
        }
        else
        {
            gameObject.transform.position = Vector2.MoveTowards(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y),
                   targetLocation, 3 * Time.deltaTime);
        }
    }

    public void Killed()
    {
        Destroy(this.gameObject);
    }
    public void moveOnClick(Vector3 position)
    {
        if (hasStamina(gameObject.transform.position, position))
        {

            //gameObject.transform.position = new Vector3(position.x, position.y, -1);

            targetLocation = new Vector2(position.x,position.y);
            CombatProcessor.Instance.TurnCombat(this.gameObject);

        }
    }
    //check if enough stamina is available
    public bool hasStamina(Vector3 currentPosition, Vector3 position)
    {
        if (!(currentPosition.x - position.x <= PlayerStats.Instance.Stamina && currentPosition.x - position.x >= -PlayerStats.Instance.Stamina))
            return false;
        if (!(currentPosition.y - position.y <= PlayerStats.Instance.Stamina && currentPosition.y - position.y >= -PlayerStats.Instance.Stamina))
            return false;
        return true;
    }
}
