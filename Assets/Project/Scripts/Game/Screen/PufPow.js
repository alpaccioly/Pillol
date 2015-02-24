#pragma strict

var pop_spd : float;
var check : int = 0;
var checkT : int = 0;

function Start () {
    transform.localScale.x = 0.0;
    transform.localScale.y = 0.0;
}

function Update () {
    if(Time.time > 2){
        checkT = 1;
    }

    if(checkT){
        transform.localScale.x = transform.localScale.x + pop_spd;
        transform.localScale.y = transform.localScale.y + pop_spd;
        
        if(transform.localScale.x > 0.3){
            pop_spd = -pop_spd;
            check = 1;
        }
        
        if(check == 1 && transform.localScale.x <= 0.23){
            pop_spd = -pop_spd;
            check = 2;
        }
        
        if(check == 2 && transform.localScale.x >= 0.25039){
            pop_spd = 0;
        }
    }
}