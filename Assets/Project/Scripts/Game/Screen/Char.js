#pragma strict

//var Character : GameObject;

var id : int;

var sprite0 : Sprite;
var sprite1 : Sprite;
var sprite2 : Sprite;
var sprite3 : Sprite;
var sprite4 : Sprite;
var sprite5 : Sprite;
var sprite6 : Sprite;
var sprite7 : Sprite;
var sprite8 : Sprite;
var sprite9 : Sprite;
var sprite10 : Sprite;

function Start () {
    //Character.GetComponent(SpriteRenderer).sprite = null;
}

function Update () {

    if(id == SceneManager.player){
        switch(SceneManager.selected){
            case 1: gameObject.GetComponent(SpriteRenderer).sprite = sprite1;
                    break;
            case 2: gameObject.GetComponent(SpriteRenderer).sprite = sprite2;
                    break;
            case 3: gameObject.GetComponent(SpriteRenderer).sprite = sprite3;
                    break;                    
            case 4: gameObject.GetComponent(SpriteRenderer).sprite = sprite4;
                    break;
            case 5: gameObject.GetComponent(SpriteRenderer).sprite = sprite5;
                    break;
            case 6: gameObject.GetComponent(SpriteRenderer).sprite = sprite6;
                    break;
            case 7: gameObject.GetComponent(SpriteRenderer).sprite = sprite7;
                    break;
            case 8: gameObject.GetComponent(SpriteRenderer).sprite = sprite8;
                    break;
            case 9: gameObject.GetComponent(SpriteRenderer).sprite = sprite9;
                    break;                    
            case 10: gameObject.GetComponent(SpriteRenderer).sprite = sprite10;
                    break;
            default: gameObject.GetComponent(SpriteRenderer).sprite = sprite0;
                     break;
                    
                    
        }
    }

}

function OnMouseDown()
{
    gameObject.GetComponent(SpriteRenderer).sprite = sprite0;
    SceneManager.player = 0;
}