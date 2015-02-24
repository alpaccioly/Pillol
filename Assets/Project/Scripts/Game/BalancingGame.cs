using UnityEngine;
using System.Collections;

namespace GameUtils{
    [System.Serializable]
    public class GeneralConstants
    {
        public float MasterDamage;
        public float ArmaPowerInfluenceDamage;
        public float DistanceInfluenceDamage;
        
        public float MasterAcerto;
        public float ArmaPoderInfluenceAcerto;
        public float DistanceInfluenceAcerto;
    }

    [System.Serializable]
    public class ArmaParams
    {
        public string Name;
        public float Power;
    }

    [System.Serializable]
    public class CharacterParams
    {
        public string Name;
        
        [Range(0.0F, 1000.0F)]
        public float Life;
        
        [Range(0.0F, 10.0F)]
        public float Habilidade;
        
        [Range(0.0F, 10.0F)]
        public float Defesa;
        
        [Range(2.0F, 10.0F)]
        public float FrequenciaAtaqueMin;
        
        [Range(2.0F, 12.0F)]
        public float FrequenciaAtaqueMax;
        
    }

    public class BalancingGame : MonoBehaviour
    {
        public bool SaveChangesOnStatic = false;
        public GeneralConstants general; 
        public CharacterParams[] personagens;
        public ArmaParams[] armas;

        public static GeneralConstants General; 
        public static CharacterParams[] Personagens;
        public static ArmaParams[] Armas;
	
        public void Awake(){
            LoadOnStatic();
        }
        void Update()
        {
            if (Time.frameCount%20==0 && SaveChangesOnStatic)
            {
                LoadOnStatic();
            }
        }
        public void LoadOnStatic()
        {
            Armas = this.armas;
            General = this.general;
            Personagens = this.personagens;
        }

        public static CharacterParams GetCharParams(string name)
        {
            foreach (CharacterParams c in Personagens)
            {
                if(c.Name==name)
                    return c;
            }
            return null;
        }
    }
}