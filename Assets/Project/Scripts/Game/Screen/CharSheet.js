#pragma strict

//var SceneManager : GameObject;
var charNumber : int;

function Start () {
    
}

function Update () {
    
    
    
}

function OnMouseDown()
{
    SceneManager.selected = charNumber;
    SceneManager.updatePlayers();
    SceneManager.player++;
}