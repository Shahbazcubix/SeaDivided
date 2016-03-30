using UnityEngine;
using System.Collections;
using System;

public class FzFairly : FuzzyTerm {

	private FuzzySet m_Set;

	private FzFairly(FzFairly inst) {
		m_Set = inst.m_Set;
	}

	public FzFairly (FzSet ft) {
		m_Set = ft.m_Set.clone();
	}

	public override double GetDOM() {
		return Mathf.Sqrt ((float)m_Set.GetDOM ());
	}

	public override FuzzyTerm Clone() {
		return new FzFairly (this);
	}

	public override void ClearDOM() {
		m_Set.ClearDOM ();
	}

	public override void ORwithDOM(double val) {
		m_Set.ORwithDOM(Mathf.Sqrt ((float)val));
	}
}
