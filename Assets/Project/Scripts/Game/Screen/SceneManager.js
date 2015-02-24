#pragma strict

//var blue1 : GameObject;
//var ooo : GameObject;

//var y : float;

static var selected : int;
static var player : int;

static var playersNames = {
	"1": "PufPowMain",
	"2": "PufPowNega",
	"3": "PufPowGordo",
	"4": "PufPowNego",
	"5": "PufPowPequena",
	"6": "PufPowGalego",
	"7": "PufPowPunk",
	"8": "PufPowGarotaLoira",
	"9": "PufPowBichinho",
	"10": "PufPowNerd"
};

// reds are odds, blues are evens
static var players : Array = new Array(0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

function Start () {
    player = 0;
}

static function updatePlayers() {
	if (player > 10)
		return;
		
	players[player] = selected;
}

function Update () {    
    //Debug.Log(selected);
    
    //print(selected);
    
    //y = blue1.GetComponent(CharSheet).x;

    //blue1.GetComponent(SpriteRenderer).sprite = sprite1;
    //blue1.transform.position.x = blue1.transform.position.x + y;
    //ooo.transform.position.x = ooo.transform.position.x + blue1.GetComponent(CharSheet).x;        
}
