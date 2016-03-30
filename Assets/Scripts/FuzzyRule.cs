using UnityEngine;
using System.Collections;

public class FuzzyRule {

	private FuzzyTerm m_pAntecedent;

	private FuzzyTerm m_pConsequence;

	private FuzzyRule(FuzzyRule fr) {
	}

	public FuzzyRule(FuzzyTerm ant, FuzzyTerm con) {
		m_pAntecedent = ant.Clone ();
		m_pConsequence = con.Clone ();
	}

	~FuzzyRule() {
		m_pAntecedent = null;
		m_pConsequence = null;
	}

	public void SetConfidenceOfConsequentToZero() {
		m_pConsequence.ClearDOM ();
	}

	public void Calculate() {
		m_pConsequence.ORwithDOM (m_pAntecedent.GetDOM ());

	}

}
