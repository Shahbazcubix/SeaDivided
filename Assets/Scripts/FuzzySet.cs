using UnityEngine;
using System.Collections;
using System;

public abstract class FuzzySet : ICloneable { 

	protected double m_dDOM;

	protected double m_dRepresentativeValue;

	public FuzzySet(double RepVal) {
		m_dDOM = 0.0d;
		m_dRepresentativeValue = RepVal;
	}

	public abstract double CalculateDOM (double val);

	public void ORwithDOM(double val) {
		if (val > m_dDOM) {
			m_dDOM = val;
		}
	}

	public double GetRepresentativeVal() {
		return m_dRepresentativeValue;
	}

	public void ClearDOM() {
		m_dDOM = 0.0d;
	}

	public void SetDOM(double val) {
		if ((val <= 1) && (val >= 0)) {
			//Debug.Log ("<FuzzySet::SetDOM>: invalid value");
		} 
		m_dDOM = val;
	}

	public double GetDOM() {
		return m_dDOM;
	}

	public FuzzySet clone() {
		return (FuzzySet)base.MemberwiseClone ();
	}

	public object Clone() {
		return (FuzzySet) this.MemberwiseClone ();	 
	}
}
