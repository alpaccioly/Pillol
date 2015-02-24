#pragma strict

    var way : float;
    var accel : float;
    var vel : float;
    var velX : float;
    var check : int;
    var height0 : float;
    var stop : int = 0;
    var tempo : float;
    var delay : float;

function Start () {
    height0 = transform.position.y;
    check = 0;
    
    accel = -0.001;
    vel = 0.1;
}

function Update () {

    if(!stop){
        
        if(!check && transform.position.x > -10){
            check = 1;
        }
        
        vel = vel + accel;
        
        if((transform.position.x > 11 || transform.position.x < -11) && check){
            way = -way;
            vel = -vel;  
            stop = 1;
            tempo = Time.time;
        }
        
        transform.position = Vector3(transform.position.x + velX * way, transform.position.y + vel, transform.position.z);
        
        transform.Rotate(0, 0, -way * 50 * Time.deltaTime, Space.World);
    }
    
    if(stop){
        if(Time.time > tempo + delay){
            stop = 0;
        }
    
    }
}

