using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FuzzyVariable : MonoBehaviour {
	
	public FuzzyLogicGui flg;
	
	private Dictionary<string, FuzzySet> m_MemberSets = new Dictionary<string, FuzzySet>();
	
	private Dictionary<string, double> domDictionary = new Dictionary<string, double> ();
	
	
	
	void awake() {
		
	}
	
	
	private FuzzyVariable(FuzzyVariable fv) {
		Debug.Log ("Unsupported operation");
	}
	
	private double m_dMinRange;
	private double m_dMaxRange;
	
	private void AdjustRangeToFit(double minBound, double maxBound) {
		if (minBound < m_dMinRange) {
			m_dMinRange = minBound;
		}
		if (maxBound > m_dMaxRange) {
			m_dMaxRange = maxBound;
		}
	}
	
	~FuzzyVariable() {
		m_MemberSets.Clear ();
	}
	
	public FuzzyVariable() {
		m_dMinRange = 0.0d;
		m_dMaxRange = 0.0d;
	}
	
	public FzSet AddLeftShoulderSet(string name,
	                                double minBound,
	                                double peak,
	                                double maxBound) {
		m_MemberSets.Add (name, new FuzzySet_LeftShoulder (peak, peak - minBound, maxBound - peak));
		
		AdjustRangeToFit (minBound, maxBound);
		
		FuzzySet fs;
		m_MemberSets.TryGetValue (name, out fs);
		return new FzSet (fs);
	}
	
	public FzSet AddRightShoulderSet(string name,
	                                 double minBound,
	                                 double peak,
	                                 double maxBound) {
		m_MemberSets.Add (name, new FuzzySet_RightShoulder (peak, peak - minBound, maxBound - peak));
		
		AdjustRangeToFit (minBound, maxBound);
		
		FuzzySet fs;
		m_MemberSets.TryGetValue (name, out fs);
		return new FzSet (fs);
		
	}
	
	public FzSet AddTriangularSet(string name,
	                              double minBound,
	                              double peak,
	                              double maxBound) {
		m_MemberSets.Add (name, new FuzzySet_Triangle (peak, peak - minBound, maxBound - peak));
		
		AdjustRangeToFit (minBound, maxBound);
		
		FuzzySet fs;
		m_MemberSets.TryGetValue (name, out fs);
		return new FzSet (fs);
		
	}
	
	public FzSet AddSingletonSet(string name,
	                             double minBound,
	                             double peak,
	                             double maxBound) {
		m_MemberSets.Add (name, new FuzzySet_Singleton (peak, peak - minBound, maxBound - peak));
		
		AdjustRangeToFit (minBound, maxBound);
		
		FuzzySet fs;
		m_MemberSets.TryGetValue (name, out fs);
		return new FzSet (fs);
		
	}
	
	public void Fuzzify(double val) {
		if (val >= m_dMinRange && val <= m_dMaxRange) {
			//    Debug.Log ("<FuzzyVariable::Fuzzify>: value out of range");
		}
		foreach (KeyValuePair<string, FuzzySet> kvp in m_MemberSets) {
			kvp.Value.SetDOM(kvp.Value.CalculateDOM(val));
		}
		
	}
	
	public double DeFuzzifyMaxAv() {
		double bottom = 0.0d;
		double top = 0.0d;
		foreach (KeyValuePair<string, FuzzySet> kvp in m_MemberSets) {
			bottom += kvp.Value.GetDOM();
			top += kvp.Value.GetRepresentativeVal() * kvp.Value.GetDOM();
		}
		
		if (isEqual (0.0d, bottom)) {
			return 0.0d;
		}
		
		return top / bottom;
	}
	
	public double DefuzzifyCentroid(int NumSamples) {
		double StepSize = (m_dMaxRange - m_dMinRange) / (double)NumSamples;
		
		double TotalArea = 0.0d;
		double SumOfMoments = 0.0d;
		
		for (int samp = 1; samp <= NumSamples; ++samp) {
			foreach (KeyValuePair<string, FuzzySet> kvp in m_MemberSets) {
				double contribution = Mathf.Min ((float)kvp.Value.CalculateDOM(m_dMinRange + samp * StepSize),
				                                 (float)kvp.Value.GetDOM());
				
				TotalArea += contribution;
				
				SumOfMoments += (m_dMinRange + samp * StepSize) * contribution;
			}
			
		}
		
		if (isEqual (0.0d, TotalArea)) {
			return 0.0d;
		}
		
		return (SumOfMoments / TotalArea);
		
	}
	
	public void WriteDOMs() {
		
		//domDictionary.Clear ();
		double temp;
		
		domDictionary = GameObject.Find ("Container").gameObject.GetComponent<CellSpacePartition> ().getDictionary ();
		flg = GameObject.Find ("Main Camera").gameObject.GetComponent<FuzzyLogicGui> ();
		
		foreach (KeyValuePair<string, FuzzySet> kvp in m_MemberSets) {
			//Debug.Log ("\n" + kvp.Key + " " + kvp.Value.GetDOM ());
			
			
			if(flg.getBoolDictionary()) {
				domDictionary.Add (kvp.Key, kvp.Value.GetDOM());
			}
			
			//domDictionary.TryGetValue(kvp.Key, out temp);
			//Debug.Log (kvp.Key);
			//            Debug.Log ("Here are test values: " + temp);
		}
		//Debug.Log ("\n Min Range: " + m_dMinRange + "\nMax Range: " + m_dMaxRange);
	}
	
	
	
	public bool isEqual(double a, double b) {
		if (Mathf.Abs ((float)a - (float)b) < 0.000000000001d)
			return true;
		
		return false;
		
	}
	
	
	
}
