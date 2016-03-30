using UnityEngine;
using System.Collections;

public class FzVery : FuzzyTerm {

	private FuzzySet m_Set;

	private FzVery (FzVery inst) {
		m_Set = inst.m_Set;
	}

	public FzVery(FzSet ft) {
		m_Set = ft.m_Set.clone ();
	}

	public override double GetDOM() {
		return m_Set.GetDOM () * m_Set.GetDOM ();
	}

	public override FuzzyTerm Clone() {
		return new FzVery (this);
	}

	public override void ClearDOM() {
		m_Set.ClearDOM ();
	}

	public override void ORwithDOM(double val) {
		m_Set.ORwithDOM (val * val);
	}
}
