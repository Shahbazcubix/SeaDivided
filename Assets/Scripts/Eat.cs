using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Eat : AI_Base {
	
	private string words = "";
	public List<GameObject> m_Vehicles = new List<GameObject> ();

	protected override void initializeFuzzyModule() {
		FuzzyVariable DistToTarget = m_FuzzyModule.CreateFLV ("DistToTarget");

		//FzSet is a fuzzy set!!!
		FzSet Target_Close = DistToTarget.AddLeftShoulderSet("eTarget_Close", 0, 250, 500);
		FzSet Target_Medium = DistToTarget.AddTriangularSet("eTarget_Medium", 250, 500, 750);
		FzSet Target_Far = DistToTarget.AddRightShoulderSet("eTarget_Far", 500, 750, 1000);
		
		FuzzyVariable DistToMate = m_FuzzyModule.CreateFLV ("DistToMate");
		FzSet Mate_Close = DistToMate.AddLeftShoulderSet("mTarget_Close", 0, 250, 500);
		FzSet Mate_Medium = DistToMate.AddTriangularSet("mTarget_Medium", 250, 500, 750);
		FzSet Mate_Far = DistToMate.AddRightShoulderSet("mTarget_Far", 500, 750, 1000);
		
		FuzzyVariable Hunger = m_FuzzyModule.CreateFLV("Hunger");
		FzSet VeryHungry = Hunger.AddRightShoulderSet("VeryHungry", 50, 75, 100);
		FzSet Hungry = Hunger.AddTriangularSet("Hungry", 25, 50, 75);
		FzSet NotHungry = Hunger.AddLeftShoulderSet("NotHungry", 0, 25, 50);
		
		
		FuzzyVariable Libido = m_FuzzyModule.CreateFLV("Libido");
		FzSet HighLibido = Libido.AddRightShoulderSet("HighLibido", 50, 75, 100);
		FzSet MediumLibido = Libido.AddTriangularSet("MediumLibido", 25, 50, 75);
		FzSet NoLibido = Libido.AddLeftShoulderSet("NoLibido", 0, 25, 50);
		
		FuzzyVariable Desirability = m_FuzzyModule.CreateFLV("Desirability");
		FzSet VeryDesirable = Desirability.AddRightShoulderSet("VeryDesirable", 50, 75, 100);
		FzSet Desirable = Desirability.AddTriangularSet("Desirable", 25, 50, 75);
		FzSet Undesirable = Desirability.AddLeftShoulderSet("Undesirable", 0, 25, 50);
		
		
		FuzzyVariable Sex = m_FuzzyModule.CreateFLV("Sex");
		FzSet HighSex = Sex.AddRightShoulderSet("HighSex", 50, 75, 100);
		FzSet MediumSex = Sex.AddTriangularSet("MediumSex", 25, 50, 75);
		FzSet NoSex = Sex.AddLeftShoulderSet("NoSex", 0, 25, 50);



		//temperature
		FuzzyVariable Temperature = m_FuzzyModule2.CreateFLV ("Temperature");

		FzSet hot = Temperature.AddLeftShoulderSet("hot", 0, 250, 500);
		FzSet warm = Temperature.AddTriangularSet("warm", 250, 500, 750);
		FzSet cold = Temperature.AddRightShoulderSet("cold", 500, 750, 1000);

		FuzzyVariable Hunger2 = m_FuzzyModule2.CreateFLV("Hunger2");
		FzSet VeryHungry2 = Hunger2.AddRightShoulderSet("VeryHungry", 50, 75, 100);
		FzSet Hungry2 = Hunger2.AddTriangularSet("Hungry", 25, 50, 75);
		FzSet NotHungry2 = Hunger2.AddLeftShoulderSet("NotHungry", 0, 25, 50);

		FuzzyVariable Libido2 = m_FuzzyModule2.CreateFLV("Libido2");
		FzSet HighLibido2 = Libido2.AddRightShoulderSet("HighLibido", 50, 75, 100);
		FzSet MediumLibido2 = Libido2.AddTriangularSet("MediumLibido", 25, 50, 75);
		FzSet NoLibido2 = Libido2.AddLeftShoulderSet("NoLibido", 0, 25, 50);

		FuzzyVariable Desirability2 = m_FuzzyModule2.CreateFLV("Desirability2");
		FzSet VeryDesirable2 = Desirability2.AddRightShoulderSet("VeryDesirable", 50, 75, 100);
		FzSet Desirable2 = Desirability2.AddTriangularSet("Desirable", 25, 50, 75);
		FzSet Undesirable2 = Desirability2.AddLeftShoulderSet("Undesirable", 0, 25, 50);

		FuzzyVariable Sex2 = m_FuzzyModule2.CreateFLV("Sex2");
		FzSet HighSex2 = Sex2.AddRightShoulderSet("HighSex", 50, 75, 100);
		FzSet MediumSex2 = Sex2.AddTriangularSet("MediumSex", 25, 50, 75);
		FzSet NoSex2 = Sex2.AddLeftShoulderSet("NoSex", 0, 25, 50);

		//Temperature Rules
		m_FuzzyModule2.AddRule (new FzAND (hot, VeryHungry2), Undesirable2);
		m_FuzzyModule2.AddRule (new FzAND (hot, Hungry2), Undesirable2);
		m_FuzzyModule2.AddRule (new FzAND (hot, NotHungry2), Undesirable2);

		m_FuzzyModule2.AddRule (new FzAND (warm, VeryHungry2), VeryDesirable2);
		m_FuzzyModule2.AddRule (new FzAND (warm, Hungry2), VeryDesirable2);
		m_FuzzyModule2.AddRule (new FzAND (warm, NotHungry2), Desirable2);

		m_FuzzyModule2.AddRule (new FzAND (cold, VeryHungry2), Desirable2);
		m_FuzzyModule2.AddRule (new FzAND (cold, Hungry2), Undesirable2);
		m_FuzzyModule2.AddRule (new FzAND (cold, NotHungry2), Undesirable2);


		m_FuzzyModule2.AddRule (new FzAND (hot, HighLibido2), NoSex2);
		m_FuzzyModule2.AddRule (new FzAND (hot, MediumLibido2), NoSex2);
		m_FuzzyModule2.AddRule (new FzAND (hot, NoLibido2), NoSex2);

		m_FuzzyModule2.AddRule (new FzAND (warm, HighLibido2), MediumSex2);
		m_FuzzyModule2.AddRule (new FzAND (warm, MediumLibido2), NoSex2);
		m_FuzzyModule2.AddRule (new FzAND (warm, NoLibido2), NoSex2);

		m_FuzzyModule2.AddRule (new FzAND (cold, HighLibido2), HighSex2);
		m_FuzzyModule2.AddRule (new FzAND (cold, MediumLibido2), HighSex2);
		m_FuzzyModule2.AddRule (new FzAND (cold, NoLibido2), NoSex2);



		//food
		//antecedents and consequents are FzSet isntances, so Clone() uses FzSet member function Clone().
		m_FuzzyModule.AddRule(new FzAND(Target_Close, HighLibido, VeryHungry), VeryDesirable);//done
		m_FuzzyModule.AddRule(new FzAND(Target_Close, MediumLibido, VeryHungry), VeryDesirable);//done
		m_FuzzyModule.AddRule(new FzAND(Target_Close, NoLibido, VeryHungry), VeryDesirable);//done
		
		m_FuzzyModule.AddRule(new FzAND(Target_Close, HighLibido, Hungry), Desirable);//done
		m_FuzzyModule.AddRule(new FzAND(Target_Close,MediumLibido, Hungry), Desirable);//done
		m_FuzzyModule.AddRule(new FzAND(Target_Close, NoLibido, Hungry), VeryDesirable);//done
		
		m_FuzzyModule.AddRule(new FzAND(Target_Close, HighLibido, NotHungry), Undesirable);//done
		m_FuzzyModule.AddRule(new FzAND(Target_Close, MediumLibido, NotHungry), Undesirable);//done
		m_FuzzyModule.AddRule(new FzAND(Target_Close, NoLibido, NotHungry), Undesirable);//done
		
		m_FuzzyModule.AddRule(new FzAND(Target_Medium, HighLibido, VeryHungry), Desirable);//done
		m_FuzzyModule.AddRule(new FzAND(Target_Medium, MediumLibido, VeryHungry), VeryDesirable);//done
		m_FuzzyModule.AddRule(new FzAND(Target_Medium, NoLibido, VeryHungry), VeryDesirable);//done
		
		m_FuzzyModule.AddRule(new FzAND(Target_Medium, HighLibido, Hungry), Desirable);//done
		m_FuzzyModule.AddRule(new FzAND(Target_Medium, MediumLibido, Hungry), Desirable);//done
		m_FuzzyModule.AddRule(new FzAND(Target_Medium, NoLibido, Hungry), VeryDesirable);//done
		
		m_FuzzyModule.AddRule(new FzAND(Target_Medium, HighLibido, NotHungry), Undesirable);//done
		m_FuzzyModule.AddRule(new FzAND(Target_Medium, MediumLibido, NotHungry), Undesirable);//done
		m_FuzzyModule.AddRule(new FzAND(Target_Medium, NoLibido, NotHungry), Undesirable);//done
		
		m_FuzzyModule.AddRule(new FzAND(Target_Far, HighLibido, VeryHungry), VeryDesirable);//done
		m_FuzzyModule.AddRule(new FzAND(Target_Far, MediumLibido, VeryHungry), VeryDesirable);//done
		m_FuzzyModule.AddRule(new FzAND(Target_Far, NoLibido, VeryHungry), VeryDesirable);//done
		
		m_FuzzyModule.AddRule(new FzAND(Target_Far, HighLibido, Hungry),Desirable);//done
		m_FuzzyModule.AddRule(new FzAND(Target_Far, MediumLibido, Hungry),Desirable);//done
		m_FuzzyModule.AddRule(new FzAND(Target_Far, NoLibido, Hungry), VeryDesirable);//done
		
		m_FuzzyModule.AddRule(new FzAND(Target_Far, HighLibido, NotHungry),Undesirable);//done
		m_FuzzyModule.AddRule(new FzAND(Target_Far, MediumLibido, NotHungry), Undesirable);//done
		m_FuzzyModule.AddRule(new FzAND(Target_Far, NoLibido, NotHungry), Undesirable);//done
		
		//sex
		m_FuzzyModule.AddRule(new FzAND(Mate_Close, VeryHungry, HighLibido), MediumSex);//done
		m_FuzzyModule.AddRule(new FzAND(Mate_Close, VeryHungry, MediumLibido), MediumSex);//done
		m_FuzzyModule.AddRule(new FzAND(Mate_Close, VeryHungry, NoLibido), NoSex);//done
		
		m_FuzzyModule.AddRule(new FzAND(Mate_Close, Hungry, HighLibido), HighSex);//done
		m_FuzzyModule.AddRule(new FzAND(Mate_Close, Hungry, MediumLibido), MediumSex);//done
		m_FuzzyModule.AddRule(new FzAND(Mate_Close, Hungry, NoLibido), NoSex);//done
		
		m_FuzzyModule.AddRule(new FzAND(Mate_Close, NotHungry, HighLibido), HighSex);//done
		m_FuzzyModule.AddRule(new FzAND(Mate_Close, NotHungry, MediumLibido), HighSex);//done
		m_FuzzyModule.AddRule(new FzAND(Mate_Close, NotHungry, NoLibido), NoSex);//done
		
		
		m_FuzzyModule.AddRule(new FzAND(Mate_Medium, VeryHungry, HighLibido), MediumSex); ///done
		m_FuzzyModule.AddRule(new FzAND(Mate_Medium, VeryHungry, MediumLibido), NoSex);//done
		m_FuzzyModule.AddRule(new FzAND(Mate_Medium, VeryHungry, NoLibido), NoSex);//done
		
		m_FuzzyModule.AddRule(new FzAND(Mate_Medium, Hungry, HighLibido), HighSex);//done
		m_FuzzyModule.AddRule(new FzAND(Mate_Medium, Hungry, MediumLibido), MediumSex);//done
		m_FuzzyModule.AddRule(new FzAND(Mate_Medium, Hungry, NoLibido), NoSex);//done
		
		m_FuzzyModule.AddRule(new FzAND(Mate_Medium, NotHungry, HighLibido), HighSex);//done
		m_FuzzyModule.AddRule(new FzAND(Mate_Medium, NotHungry, MediumLibido), MediumSex);//done
		m_FuzzyModule.AddRule(new FzAND(Mate_Medium, NotHungry, NoLibido), NoSex);//done
		
		m_FuzzyModule.AddRule(new FzAND(Mate_Far, VeryHungry, HighLibido), MediumSex);//done
		m_FuzzyModule.AddRule(new FzAND(Mate_Far, VeryHungry, MediumLibido), NoSex);//done
		m_FuzzyModule.AddRule(new FzAND(Mate_Far, VeryHungry, NoLibido), NoSex);//done
		
		m_FuzzyModule.AddRule(new FzAND(Mate_Far, Hungry, HighLibido), MediumSex);//done
		m_FuzzyModule.AddRule(new FzAND(Mate_Far, Hungry, MediumLibido), MediumSex);//done
		m_FuzzyModule.AddRule(new FzAND(Mate_Far, Hungry, NoLibido), NoSex);//done
		
		m_FuzzyModule.AddRule(new FzAND(Mate_Far, NotHungry, HighLibido), HighSex);//done
		m_FuzzyModule.AddRule(new FzAND(Mate_Far, NotHungry, MediumLibido), MediumSex);//done
		m_FuzzyModule.AddRule(new FzAND(Mate_Far, NotHungry, NoLibido), NoSex);//done
	}
	
	public override double[] GetDesirability(double DistToTarget, double DistToMate, double hunger, double libido, double coldness, int i) {
		double[] values = new double[2];
		double[] values2 = new double[2];

		m_Vehicles = GameObject.Find ("Container").GetComponent<CellSpacePartition> ().getVehicles ();

		m_FuzzyModule2.Fuzzify ("Temperature", coldness);
		m_FuzzyModule2.Fuzzify ("Hunger2", hunger);
		m_FuzzyModule2.Fuzzify ("Libido2", libido);

		values2 [0] = m_FuzzyModule2.DeFuzzify ("Desirability2", FuzzyModule.DefuzzifyMethod.max_av);//hunger
		values2[1] = m_FuzzyModule2.DeFuzzify ("Sex2", FuzzyModule.DefuzzifyMethod.max_av); //libido

		m_Vehicles [i].GetComponent<BallBounce> ().setHunger ((float) values2 [0]);
		m_Vehicles [i].GetComponent<BallBounce> ().setLibido ((float) values2 [1]);

		m_FuzzyModule.Fuzzify ("DistToTarget", DistToTarget);
		//m_FuzzyModule.WriteAllDOMs ();
		m_FuzzyModule.Fuzzify ("DistToMate", DistToMate);
		//m_FuzzyModule.WriteAllDOMs ();
		m_FuzzyModule.Fuzzify ("Hunger", values2[0]);
		//m_FuzzyModule.WriteAllDOMs ();
		m_FuzzyModule.Fuzzify ("Libido",  values2[1]);
		
		
		values[0] = m_FuzzyModule.DeFuzzify("Desirability", FuzzyModule.DefuzzifyMethod.max_av);
		
		//Debug.Log ("Desirability to Eat!!!");
		
		//m_FuzzyModule.WriteAllDOMs ();
		
		values[1] = m_FuzzyModule.DeFuzzify("Sex", FuzzyModule.DefuzzifyMethod.max_av);
		
		//Debug.Log ("Desirability to Mate!!!");
		
		//m_FuzzyModule.WriteAllDOMs ();
		
		//Debug.Log ("Sex: " + temp);
		
		return values;
		
	}
	
	public string getWords() {
		return words;
	}
}
