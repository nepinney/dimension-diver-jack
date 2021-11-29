using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using TMPro;

public class buttonControllers : MonoBehaviour
{

    public GameObject blackScreen;
    public GameObject player;
    public GameObject tree;
    public GameObject door;
    public GameObject messageField;
    public GameObject messageBox;
    public Tilemap tilemap;
    public TextMeshPro text;
    Scene currentScene;
    string sceneName;

    // dig method allowed only in level 1
    public void dig(){
        // get the current scene
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if(sceneName == "1"){
            player = GameObject.Find("Player");
            // if player location matches location allowed to dig
            if(player.transform.position.x <= 36 && player.transform.position.x >= 31){
                tilemap = GameObject.Find("Level1Ground").GetComponent<Tilemap> ();
                // remove the tiles
                tilemap.SetTile(new Vector3Int(23,-8,0), null);
                tilemap.SetTile(new Vector3Int(24,-8,0), null);
            } else {
                // if not in a location that allows digging
                messageBox = GameObject.Find("MessageBox");
                messageBox.SetActive(true);
                messageField = GameObject.Find("MessageText");
                messageField.GetComponent<TextMeshProUGUI>().text = "Can't Dig Here";
                Debug.Log("Can't Dig Here");
            }
        } else {
                // display message if not near in a digging level
                messageBox = GameObject.Find("MessageBox");
                messageBox.SetActive(true);
                messageField = GameObject.Find("MessageText");
                messageField.GetComponent<TextMeshProUGUI>().text = "Can't Dig in This Level";
                Debug.Log("Can't Dig in this scene");
        }

    }

    // flashlight implemented for level 3 only
    public void turnOnLight(){
        // get the current scene
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if(sceneName == "3"){
            // remove the black screen
            blackScreen = GameObject.Find("blackScreen1");
            blackScreen.SetActive(false);
        } else {
            // if not in a level that requires a flashlight
            messageBox = GameObject.Find("MessageBox");
            messageBox.SetActive(true);
            messageField = GameObject.Find("MessageText");
            messageField.GetComponent<TextMeshProUGUI>().text = "No Use for a Flashlight";
            Debug.Log("No use for a flashlight");
        }
    }

    // axe implemented for level 4 only
    public void chop(){
        // get the current scene
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if(sceneName == "4"){
            player = GameObject.Find("Player");
            // if player is near each tree obstacle, hide it
            // player will be able to pass through
            if(player.transform.position.x <= 7 && player.transform.position.x >= 2){
                tree = GameObject.Find("Tree Obstacle 1");
                tree.SetActive(false);
            } else if(player.transform.position.x <= 21 && player.transform.position.x >= 16){
                tree = GameObject.Find("Tree Obstacle 2");
                tree.SetActive(false);
            } else if(player.transform.position.x <= 61 && player.transform.position.x >= 55){
                tree = GameObject.Find("Tree Obstacle 3");
                tree.SetActive(false);
            } else if (player.transform.position.x <= 95 && player.transform.position.x >= 90){
                tree = GameObject.Find("Tree Obstacle 4");
                tree.SetActive(false);
            } else if (player.transform.position.x <= 113 && player.transform.position.x >= 107){
                tree = GameObject.Find("Tree Obstacle 5");
                tree.SetActive(false);
            } else if (player.transform.position.x <= 151 && player.transform.position.x >= 145){
                tree = GameObject.Find("Tree Obstacle 6");
                tree.SetActive(false);
            } else {
                // display message if not near a tree
                messageBox = GameObject.Find("MessageBox");
                messageBox.SetActive(true);
                messageField = GameObject.Find("MessageText");
                messageField.GetComponent<TextMeshProUGUI>().text = "Not Near a Tree";
                Debug.Log("Not Near a Tree");
            }

        } else {
            // if not in a level that requires axe
            messageBox = GameObject.Find("MessageBox");
            messageBox.SetActive(true);
            messageField = GameObject.Find("MessageText");
            messageField.GetComponent<TextMeshProUGUI>().text = "Nothing to Chop";
            Debug.Log("Nothing to Chop");
        }

    }

    // key implmented for level 1 and 5
    public void unlock(){
        // get the current scene
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if(sceneName == "1"){
            player = GameObject.Find("Player");
            // if player is at location of shed unlock it
            if(player.transform.position.x <= 81 && player.transform.position.x >= 78){
                door = GameObject.Find("Shed");
                // hide shed
                // player can pass through
                door.SetActive(false);
            } else {
                // if not near a door
                messageBox = GameObject.Find("MessageBox");
                messageBox.SetActive(true);
                messageField = GameObject.Find("MessageText");
                messageField.GetComponent<TextMeshProUGUI>().text = "No Door Found";
                Debug.Log("No door found");
            }
        
        } else if (sceneName == "5"){
            // if player is at location of door open it
            if(player.transform.position.x <= 208 && player.transform.position.x >= 202){
                door = GameObject.Find("level5door");
                // hide door
                // player can pass through
                door.SetActive(false);
            } else {
                // if not near a door
                messageBox = GameObject.Find("MessageBox");
                messageBox.SetActive(true);
                messageField = GameObject.Find("MessageText");
                messageField.GetComponent<TextMeshProUGUI>().text = "No Door Found";
                Debug.Log("No Door Found");
            }
        } else {
            // if not in a level with doors
            messageBox = GameObject.Find("MessageBox");
            messageBox.SetActive(true);
            messageField = GameObject.Find("MessageText");
            messageField.GetComponent<TextMeshProUGUI>().text = "Nothing in Level to Unlock";
            Debug.Log("Nothing in Level to Unlock");
        }
    }
}
