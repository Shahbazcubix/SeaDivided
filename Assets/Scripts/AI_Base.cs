using UnityEngine;
using System.Collections;

public abstract class AI_Base : MonoBehaviour {

	protected abstract void initializeFuzzyModule ();

	public FuzzyModule m_FuzzyModule = new FuzzyModule();

	public FuzzyModule m_FuzzyModule2 = new FuzzyModule();

	protected double m_dTimeNextAvailable;

	protected double m_dLastDesirabilityScore;

	protected double m_dIdealRange;

	public abstract double[] GetDesirability (double DistToTarget, double DistToMate, double hunger, double libido, double coldness, int i);



	// Use this for initialization
	void Awake () {
		initializeFuzzyModule ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
