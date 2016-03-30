using UnityEngine;
using System.Collections;

public class FzSet : FuzzyTerm {

	public FuzzySet m_Set;

	public FzSet(FuzzySet fs) {
		m_Set = fs;
	}

	private FzSet(FzSet con) {
		m_Set = con.m_Set;
	}

	public override FuzzyTerm Clone() {
		return (FuzzyTerm)new FzSet (this);
	}

	public override double GetDOM() {
		return m_Set.GetDOM ();
	}

	public override void ClearDOM() {
		m_Set.ClearDOM ();
	}

	public override void ORwithDOM(double val) {
		m_Set.ORwithDOM (val);
	}


}
