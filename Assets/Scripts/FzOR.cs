using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FzOR : FuzzyTerm {

	private IList<FuzzyTerm> m_Terms = new List<FuzzyTerm> (4);

	~FzOR() {
		m_Terms.Clear ();
	}

	public FzOR(FzOR fa) {
		foreach (FuzzyTerm ft in fa.m_Terms) {
			m_Terms.Add(ft.Clone ());
		}
	}

	public FzOR(FuzzyTerm op1, FuzzyTerm op2) {
		m_Terms.Add(op1.Clone());
		m_Terms.Add(op2.Clone());
	}
	
	/**
     * ctor using three terms
     */
	public FzOR(FuzzyTerm op1, FuzzyTerm op2, FuzzyTerm op3) {
		m_Terms.Add(op1.Clone());
		m_Terms.Add(op2.Clone());
		m_Terms.Add(op3.Clone());
	}
	
	/**
     * ctor using four terms
     */
	public FzOR(FuzzyTerm op1, FuzzyTerm op2, FuzzyTerm op3, FuzzyTerm op4) {
		m_Terms.Add(op1.Clone());
		m_Terms.Add(op2.Clone());
		m_Terms.Add(op3.Clone());
		m_Terms.Add(op4.Clone());
	}
	
	//virtual ctor
	public override FuzzyTerm Clone() {
		return new FzOR(this);
	}

	public override double GetDOM() {
		double largest = float.MinValue;

		foreach (FuzzyTerm ft in m_Terms) {
			if (ft.GetDOM() > largest) {
				largest = ft.GetDOM();
			}
		}
		return largest;
	}

	public override void ClearDOM() {
		Debug.Log ("<FzOR::ClearDOM>: invalid context");
	}

	public override void ORwithDOM(double val) {
		Debug.Log ("<FzOR::OrwithDOM>: invalid context");
	}

}
