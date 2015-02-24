function OnMouseDown()
{
	var players : String = "";
	for (var i : int = 0; i < SceneManager.players.length; i++)
	{
		if (i > 0)
			players = players + ",";
		var n : int = i + 1;
		players = players + SceneManager.playersNames["" + n];
	}
	
	PlayerPrefs.SetString("Characters", players);
    Application.LoadLevel("MainScene");
}