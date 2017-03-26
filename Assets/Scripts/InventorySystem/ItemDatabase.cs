using UnityEngine;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour {
    private List<Item> database = new List<Item>();
    private JsonData itemData;

    private void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();
    }

    private void ConstructItemDatabase ()
    {
        for(int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["id"], itemData[i]["title"].ToString(),
				(int)itemData[i]["stats"]["power"], (int)itemData[i]["stats"]["defence"], (int)itemData[i]["stats"]["vitality"],
                itemData[i]["description"].ToString(), (bool)itemData[i]["stackable"], (bool)itemData[i]["perishable"],
                itemData[i]["slug"].ToString(), itemData[i]["gameObjectPath"].ToString()
			));
        }
    }

    public Item FetchItemById(int ID)
    {
        for(int i = 0; i < database.Count; i++)
        {
            if(database[i].ID == ID)
                return database[i];
        }
        return null;
    }
}

public class Item {
    public int ID { get; set; }
    public string Title { get; set; }
    public int Power { get; set; }
    public int Defence { get; set; }
    public int Vitality { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
	public bool Perishable { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }
	public GameObject gameObject { get; set; }
	
    public Item() {
        this.ID = -1;
    }

    public Item(int id, string title, int power, int defence, int vitality, string description, bool stackable, bool perishable, string slug, string gameObjectPath)
    {
        this.ID = id;
        this.Title = title;
        this.Power = power; 
        this.Defence = defence; 
        this.Vitality = vitality; 
        this.Description = description; 
        this.Stackable = stackable; 
		this.Perishable = perishable; 
        this.Slug = slug;

		if(Resources.Load<Sprite>("Sprites/Items/"+slug) == null)
			Debug.Log("Le sprite associé à " + slug + " est introuvable dans le path Sprites/Items/"+slug);
		this.Sprite = Resources.Load<Sprite>("Sprites/Items/"+slug);

		if(Resources.Load<GameObject>("Prefabs/PickableObjects/"+gameObjectPath) == null)
			Debug.Log("Le GameObjet associé à " + slug + " est introuvable dans le path Prefabs/PickableObjects/"+gameObjectPath);
		else {
			this.gameObject = Resources.Load<GameObject>("Prefabs/PickableObjects/"+gameObjectPath);

			ItemPickable gameObjID = gameObject.GetComponent<ItemPickable>();
			if(gameObjID == null)
				Debug.Log("Le GameObjet associé à " + slug + " ne possede pas de script ItemPickable !");
			else {
				if(gameObjID.ID != id && gameObjID.ID != -1)
					Debug.Log("Attention, modification d'une ID deja existante pour l'objet "+slug+". Ancienne ID : "+gameObjID.ID+", Nouvelle ID :"+id);
				gameObjID.ID = id;
			}
		}		
    }
}
