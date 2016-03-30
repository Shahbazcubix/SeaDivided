using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FuzzyModule {
	
	
	Dictionary<string, FuzzyVariable> m_Variables = new Dictionary<string, FuzzyVariable>();
	
	public enum DefuzzifyMethod {
		max_av, 
		centroid
	};
	
	public static readonly int NumSamples = 15;
	
	private IList<FuzzyRule> m_Rules = new List<FuzzyRule>();
	
	private void SetConfidencesOfConsequentsToZero() {
		foreach (FuzzyRule fr in m_Rules) {
			fr.SetConfidenceOfConsequentToZero(); //sets m_dDOM = 0.0d
		}
	}
	
	~FuzzyModule() {
		m_Variables.Clear();
		m_Rules.Clear ();
	}
	
	public FuzzyVariable CreateFLV(string VarName) {
		FuzzyVariable fv;
		m_Variables.Add (VarName, new FuzzyVariable ());
		m_Variables.TryGetValue(VarName, out fv);
		return fv;
	}
	
	public void AddRule (FuzzyTerm antecedent, FuzzyTerm consequence) {
		m_Rules.Add (new FuzzyRule (antecedent, consequence));
	}
	
	public void Fuzzify(string NameOfFLV, double val) {
		if (m_Variables.ContainsKey(NameOfFLV))
		{
			FuzzyVariable f;
			m_Variables.TryGetValue(NameOfFLV, out f);
			f.Fuzzify(val);
		}
	}
	
	public double DeFuzzify(string NameOfFLV, DefuzzifyMethod method) {
		if (m_Variables.ContainsKey(NameOfFLV))
		{
			SetConfidencesOfConsequentsToZero ();
			
			foreach(FuzzyRule fr in m_Rules)
			{
				fr.Calculate();
			}
			
			switch(method) {
			case DefuzzifyMethod.centroid:
				FuzzyVariable fv;
				m_Variables.TryGetValue(NameOfFLV, out fv);  
				return fv.DefuzzifyCentroid(NumSamples);
				
			case DefuzzifyMethod.max_av:
				FuzzyVariable f;
				m_Variables.TryGetValue(NameOfFLV, out f);
				return f.DeFuzzifyMaxAv();
			}
			return 0.0f;
		}
		return 0.0f;
		
	}
	
	public void WriteAllDOMs() {
		foreach (KeyValuePair<string, FuzzyVariable> kvp in m_Variables) {
			//Debug.Log ("\n----------------------");
			//Debug.Log (kvp.Key + "\n");
			kvp.Value.WriteDOMs();
		}
	}
	
}
