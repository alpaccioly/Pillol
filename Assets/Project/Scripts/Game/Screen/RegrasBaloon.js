#pragma strict

var pop_spd : float;

function Start () {
    transform.localScale.x = 0.0;
    transform.localScale.y = 0.0;
}

function Update () {
    transform.localScale.x = transform.localScale.x + pop_spd;
    transform.localScale.y = transform.localScale.y + pop_spd;
    
    if(transform.localScale.x > 1){
        pop_spd = 0;
    }
      
}