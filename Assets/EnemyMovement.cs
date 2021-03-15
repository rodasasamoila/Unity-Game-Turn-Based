using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public Vector2 targetLocation;
    public string Name;
    // Start is called before the first frame update
    void Start()
    {
        targetLocation = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        CombatProcessor.Instance.enemies.Add(this);
        name = this.gameObject.name;

    }

    // Update is called once per frame
    void Update()
    {
        if (targetLocation.y != gameObject.transform.position.y)
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

    public void followPlayer(Vector3 position)
    {

        targetLocation = new Vector2(
            (int)UnityEngine.Random.Range(this.gameObject.transform.position.x - 2, this.gameObject.transform.position.x + 2),
            (int)UnityEngine.Random.Range(this.gameObject.transform.position.y - 2, this.gameObject.transform.position.y + 2)
            );

        if (checkIfPlayerIsClose(position))
        {
            Console.WriteLine("Player was killed");
        }

    }

    public bool checkIfPlayerIsClose(Vector3 position)
    {
        if ((this.gameObject.transform.position.x - player.transform.position.x <= 1 && this.gameObject.transform.position.x - player.transform.position.x >= -1)
           && (this.gameObject.transform.position.y - player.transform.position.y <= 1 && this.gameObject.transform.position.y - player.transform.position.y >= -1))
        {
           // Destroy(player);
            return true;
        }
        return false;
    }
    void OnMouseUp()
    {

        if(checkIfPlayerIsClose(player.gameObject.transform.position))
        {
            CombatProcessor.Instance.RemoveKilledEnemy(this);
            Destroy(this.gameObject);
        }       
    }
}
