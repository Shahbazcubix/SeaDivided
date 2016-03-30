using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FzAND : FuzzyTerm {

	private IList<FuzzyTerm> m_Terms = new List<FuzzyTerm>(4);

	~FzAND() {
		m_Terms.Clear ();
	}

	public FzAND(FzAND fa) {
		foreach (FuzzyTerm ft in fa.m_Terms) {
			m_Terms.Add(ft.Clone ());
		}
	}

	public FzAND(FuzzyTerm op1, FuzzyTerm op2) {
		m_Terms.Add(op1.Clone());
		m_Terms.Add(op2.Clone());
	}

	public FzAND(FuzzyTerm op1, FuzzyTerm op2, FuzzyTerm op3) {
		m_Terms.Add(op1.Clone());
		m_Terms.Add(op2.Clone());
		m_Terms.Add(op3.Clone());
	}
	
	/**
     * ctor using four terms
     */
	public FzAND(FuzzyTerm op1, FuzzyTerm op2, FuzzyTerm op3, FuzzyTerm op4) {
		m_Terms.Add(op1.Clone());
		m_Terms.Add(op2.Clone());
		m_Terms.Add(op3.Clone());
		m_Terms.Add(op4.Clone());
	}
	
	/**
     * virtual ctor
     */

	public override FuzzyTerm Clone() {
		return new FzAND(this);
	}

	public override double GetDOM() {
		double smallest = double.MaxValue;
		foreach (FuzzyTerm ft in m_Terms) {
			if (ft.GetDOM() < smallest) {
				smallest = ft.GetDOM ();
			}
		}
		return smallest;
	}

	public override void ClearDOM() {
		foreach (FuzzyTerm ft in m_Terms) {
			ft.ClearDOM();
		}
	}

	public override void ORwithDOM(double val) {
		foreach (FuzzyTerm ft in m_Terms) {
			ft.ORwithDOM(val);
		}
	}
}
